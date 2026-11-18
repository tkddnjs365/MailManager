using System.ComponentModel;
using MailSender.Controls;
using MailSender.Forms;
using MailSender.Models;
using MailSender.Services;

namespace MailSender.Views
{
    /// <summary>
    /// "거래명세서" 화면. 왼쪽에 저장된 명세서 목록(공급일자, 공급받는자, 건수, 전체금액)이 있고,
    /// 더블클릭하면 오른쪽 입력 영역에 불러와 수정할 수 있다.
    /// "저장"은 DB에 저장하고, "PDF로 저장"은 DB에 저장한 뒤 새 PDF를 만든다. (기존 PDF는 유지)
    /// </summary>
    public partial class InvoiceView : UserControl, IRefreshable
    {
        /// <summary>목록에 표시할 전체 명세서 요약 (검색어로 걸러서 보여줌)</summary>
        private List<InvoiceSummary> _all = new();

        /// <summary>입력 영역에 불러와 있는 명세서의 DB 번호. 0이면 아직 저장 전인 새 명세서</summary>
        private long _currentId;

        private DateTime _supplyDate = DateTime.Today;

        /// <summary>값을 화면에 채우는 중에는 자동 계산/자동 채우기가 동작하지 않게 막는 표시</summary>
        private bool _loading;

        /// <summary>그리드의 날짜 선택기 값을 코드로 바꾸는 중에는 셀 값이 바뀌지 않게 막는 표시</summary>
        private bool _datePickerInitializing;

        /// <summary>
        /// 현재 명세서에 적용된 공급자 정보 (저장 당시 내용을 그대로 복사해 보관하는 스냅샷)
        /// </summary>
        private InvoiceSupplier? _snapshot;

        /// <summary>
        /// 화면을 만들고, 공급자가 바뀌면 콤보박스를 새로 읽도록 연결한 뒤 새 명세서 상태로 시작한다.
        /// </summary>
        public InvoiceView()
        {
            InitializeComponent();

            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

            txtSearch.TextChanged += (_, _) => FillList(null);
            txtSupplyDate.Text = _supplyDate.ToString("yyyy-MM-dd");
            cboSupplier.Font = new Font("맑은 고딕", 10F);
            pnlSupplierBorder.Height = 40;
            pnlSupplierBorder.Padding = new Padding(1);
            gridDatePicker.AutoSize = false;
            gridDatePicker.Font = new Font("맑은 고딕", 10F);
            gridItems.RowTemplate.Height = 38;
            gridItems.SizeChanged += (_, _) => PositionDateEditor();
            gridItems.ColumnWidthChanged += (_, _) => PositionDateEditor();
            AppEvents.SuppliersChanged += () => LoadSuppliers(CurrentSupplierKey());

            NewInvoice();
        }

        /// <summary>
        /// 화면이 보여질 때 목록과 공급자를 DB에서 새로 읽는다.
        /// </summary>
        public void RefreshView()
        {
            LoadSuppliers(CurrentSupplierKey());
            RefreshList(_currentId == 0 ? null : _currentId);
        }

        #region 목록 (왼쪽)

        /// <summary>
        /// DB에서 거래명세서 목록을 다시 읽어 표시한다.
        /// </summary>
        /// <param name="selectId">목록에서 선택 표시할 명세서 번호 (없으면 null)</param>
        private void RefreshList(long? selectId)
        {
            try
            {
                _all = AppServices.Invoices.Search();
                FillList(selectId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"거래명세서 목록을 불러오지 못했습니다.\n\n{ex.Message}", "오류");
            }
        }

        /// <summary>
        /// 이미 읽어 둔 목록을 검색어로 걸러서 그리드에 채운다.
        /// </summary>
        private void FillList(long? selectId)
        {
            string q = txtSearch.Text.Trim();

            gridInvoices.Rows.Clear();
            foreach (var s in _all.Where(x => q.Length == 0 || x.BuyerName.Contains(q, StringComparison.OrdinalIgnoreCase)))
            {
                int i = gridInvoices.Rows.Add(s.SupplyDate, s.BuyerName, s.TotalCount, s.TotalAmount.ToString("N0"));
                gridInvoices.Rows[i].Tag = s.Id;
            }

            gridInvoices.ClearSelection();
            if (selectId == null) return;

            foreach (DataGridViewRow row in gridInvoices.Rows)
            {
                if (row.Tag is long id && id == selectId)
                {
                    row.Selected = true;
                    gridInvoices.CurrentCell = row.Cells[0];
                    break;
                }
            }
        }

        /// <summary>
        /// 목록의 행을 클릭하면 그 명세서를 DB에서 읽어 오른쪽 입력 영역에 불러온다.
        /// </summary>
        private void gridInvoices_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || gridInvoices.Rows[e.RowIndex].Tag is not long id) return;

            try
            {
                var data = AppServices.Invoices.Get(id);
                if (data == null)
                {
                    ToastForm.Show(this, "명세서를 찾을 수 없어요", true);
                    RefreshList(null);
                    return;
                }

                LoadInvoice(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"거래명세서를 불러오지 못했습니다.\n\n{ex.Message}", "오류");
            }
        }

        /// <summary>
        /// "새 명세서" 버튼 클릭. 입력 영역을 비운다.
        /// </summary>
        private void btnNew_Click(object? sender, EventArgs e)
        {
            NewInvoice();
            gridInvoices.ClearSelection();
        }
        #endregion

        #region 입력 영역 (오른쪽) 불러오기/초기화

        /// <summary>
        /// 입력 영역을 새 명세서 상태(오늘 날짜, 빈 품목 3줄, 기본 공급자)로 초기화한다.
        /// </summary>
        private void NewInvoice()
        {
            HideDatePicker();

            _loading = true;
            try
            {
                _currentId = 0;
                _supplyDate = DateTime.Today;
                UpdateSupplyDateText();
                txtBuyer.Text = "";

                gridItems.Rows.Clear();
                for (int i = 0; i < 3; i++) gridItems.Rows.Add();
            }
            finally
            {
                _loading = false;
            }

            LoadSuppliers(null);
            RecalcTotals();
            UpdateMode();
        }

        /// <summary>
        /// DB에서 읽은 명세서 한 건을 입력 영역에 채운다.
        /// 공급자 정보는 현재 공급자 목록이 아니라 그 명세서를 저장할 당시의 내용을 보여준다.
        /// </summary>
        private void LoadInvoice(InvoiceData data)
        {
            HideDatePicker();

            _loading = true;
            try
            {
                _currentId = data.Id;
                _supplyDate = data.SupplyDate >= monthCalendarSupply.MinDate && data.SupplyDate <= monthCalendarSupply.MaxDate
                    ? data.SupplyDate.Date
                    : DateTime.Today;
                UpdateSupplyDateText();
                txtBuyer.Text = data.BuyerName;

                _snapshot = new InvoiceSupplier
                {
                    Id = data.SupplierId ?? 0, RegNo = data.RegNo, CompanyName = data.CompanyName,
                    CeoName = data.CeoName, Address = data.Address, BizType = data.BizType, BizItem = data.BizItem,
                    SealImage = data.SealImage,
                };
                ShowSupplierInfo();

                var match = AppServices.Suppliers.Suppliers.FirstOrDefault(s => s.Id == data.SupplierId);
                if (match != null) cboSupplier.SelectedItem = match; else cboSupplier.SelectedIndex = -1;

                gridItems.Rows.Clear();
                foreach (var item in data.Items)
                {
                    gridItems.Rows.Add(NormalizeDate(item.Date), item.Name, item.Spec, item.Amt, item.TaxAmount);
                }
                while (gridItems.Rows.Count < 3) gridItems.Rows.Add();
            }
            finally
            {
                _loading = false;
            }

            RecalcTotals();
            UpdateMode();
        }

        /// <summary>
        /// 날짜 글자를 yyyy-MM-dd 형식으로 통일한다. 날짜로 읽을 수 없으면 원래 글자를 그대로 반환한다.
        /// </summary>
        private static string NormalizeDate(string text) =>
            DateTime.TryParse(text, out var d) ? d.ToString("yyyy-MM-dd") : text;

        /// <summary>
        /// 제목/배지를 "새 명세서(저장 전)" 또는 "명세서 수정(저장됨)" 상태에 맞게 바꾼다.
        /// </summary>
        private void UpdateMode()
        {
            bool saved = _currentId != 0;

            lblEditTitle.Text = saved ? "명세서 수정" : "새 명세서";
            lblBadge.Text = saved ? $"저장됨 #{_currentId}" : "저장 전";
            lblBadge.BackColor = saved ? Ui.OkSoft : Ui.WarnSoft;
            lblBadge.ForeColor = saved ? Ui.Ok : Ui.Warn;
        }
        #endregion

        #region 공급자

        /// <summary>
        /// 공급자 목록을 다시 읽을 때 유지할 공급자 번호를 정한다.
        /// 선택된 공급자가 있으면 그 번호, 저장된 명세서인데 선택이 없으면 -1(저장 당시 정보 유지), 새 명세서면 null(기본 공급자).
        /// </summary>
        private long? CurrentSupplierKey() =>
            cboSupplier.SelectedItem is InvoiceSupplier s ? s.Id : (_currentId != 0 ? -1 : null);

        /// <summary>
        /// DB에서 공급자 목록을 읽어 콤보박스에 채우고 한 명을 선택한다.
        /// </summary>
        /// <param name="keepId">
        /// 선택해 둘 공급자 번호. null이면 기본 공급자(없으면 첫 번째)를 선택한다.
        /// 번호를 줬는데 그 공급자가 지워졌다면 선택 없이 두고, 현재 공급자 정보는 그대로 둔다.
        /// </param>
        private void LoadSuppliers(long? keepId)
        {
            AppServices.Suppliers.Load();
            var list = AppServices.Suppliers.Suppliers;

            bool previous = _loading;
            _loading = true;
            cboSupplier.DataSource = null;
            cboSupplier.DataSource = list;
            _loading = previous;

            InvoiceSupplier? target = keepId != null
                ? list.FirstOrDefault(s => s.Id == keepId)
                : list.FirstOrDefault(s => s.IsDefault) ?? list.FirstOrDefault();

            if (target != null)
            {
                cboSupplier.SelectedItem = target;
                _snapshot = target;
            }
            else
            {
                cboSupplier.SelectedIndex = -1;
                if (keepId == null) _snapshot = null;
            }

            ShowSupplierInfo();
        }

        /// <summary>
        /// 현재 공급자 정보(사업자번호/상호/성명/주소)를 안내 글로 표시한다.
        /// </summary>
        private void ShowSupplierInfo()
        {
            var s = _snapshot;
            lblSupplierInfo.Text = s == null ? "공급자를 선택해 주세요."
                : $"{s.RegNo}\n{s.CompanyName} · {s.CeoName}\n{s.Address}";
        }

        /// <summary>
        /// 콤보박스에서 공급자를 바꾸면 그 공급자 정보를 명세서에 적용한다.
        /// </summary>
        private void cboSupplier_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (_loading) return;

            if (cboSupplier.SelectedItem is InvoiceSupplier s)
            {
                _snapshot = s;
                ShowSupplierInfo();
            }
        }

        private void cboSupplier_DrawItem(object? sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.DrawBackground();
            Font font = e.Font ?? cboSupplier.Font;
            using var brush = new SolidBrush(e.ForeColor);
            e.Graphics.DrawString(cboSupplier.GetItemText(cboSupplier.Items[e.Index]), font, brush,
                e.Bounds.Left + 8, e.Bounds.Top + (e.Bounds.Height - font.Height) / 2);
            e.DrawFocusRectangle();
        }

        /// <summary>
        /// 공급자 선택 상자에 검정 테두리를 그린다.
        /// </summary>
        private void pnlSupplierBorder_Paint(object? sender, PaintEventArgs e)
        {
            using var pen = new Pen(Color.Black);
            e.Graphics.DrawRectangle(pen, 0, 0, pnlSupplierBorder.Width - 1, pnlSupplierBorder.Height - 1);
        }

        private void pnlDatePicker_Paint(object? sender, PaintEventArgs e)
        {
            using var pen = new Pen(Color.FromArgb(209, 213, 219));
            e.Graphics.DrawRectangle(pen, 0, 0, pnlDatePicker.Width - 1, pnlDatePicker.Height - 1);
        }

        private void btnSupplyDateCalendar_Click(object? sender, EventArgs e)
        {
            if (monthCalendarSupply.Visible)
            {
                monthCalendarSupply.Visible = false;
                return;
            }

            monthCalendarSupply.SetDate(_supplyDate);
            monthCalendarSupply.Location = cardEdit.PointToClient(
                pnlDatePicker.PointToScreen(new Point(0, pnlDatePicker.Height)));
            monthCalendarSupply.Visible = true;
            monthCalendarSupply.BringToFront();
        }

        private void monthCalendarSupply_DateSelected(object? sender, DateRangeEventArgs e)
        {
            _supplyDate = e.Start.Date;
            UpdateSupplyDateText();
            monthCalendarSupply.Visible = false;
        }

        private void UpdateSupplyDateText()
        {
            txtSupplyDate.Text = _supplyDate.ToString("yyyy-MM-dd");
        }

        private void gridDatePicker_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)) e.Handled = true;
        }

        /// <summary>
        /// "관리" 버튼 클릭. 관리 화면의 공급자 탭으로 이동한다.
        /// </summary>
        private void btnSupplierMng_Click(object? sender, EventArgs e)
        {
            AppEvents.Navigate("manage", "sup");
        }
        #endregion

        #region 저장 / PDF / 삭제

        /// <summary>
        /// 화면의 입력 내용을 InvoiceData 객체로 모은다. 아무것도 입력하지 않은 빈 줄은 제외한다.
        /// </summary>
        private InvoiceData CollectData()
        {
            gridItems.EndEdit();

            var s = _snapshot ?? new InvoiceSupplier();
            var data = new InvoiceData
            {
                Id = _currentId,
                SupplierId = (cboSupplier.SelectedItem as InvoiceSupplier)?.Id,
                SupplyDate = _supplyDate.Date,
                BuyerName = txtBuyer.Text.Trim(),
                RegNo = s.RegNo, CompanyName = s.CompanyName, CeoName = s.CeoName,
                Address = s.Address, BizType = s.BizType, BizItem = s.BizItem, SealImage = s.SealImage,
            };

            foreach (DataGridViewRow row in gridItems.Rows)
            {
                string date = row.Cells["colItemDate"].Value?.ToString() ?? "";
                string name = row.Cells["colItemName"].Value?.ToString() ?? "";
                string spec = row.Cells["colItemSpec"].Value?.ToString() ?? "";
                string amt = row.Cells["colItemAmt"].Value?.ToString() ?? "";
                string tax = row.Cells["colItemTax"].Value?.ToString() ?? "";

                if (name.Length == 0 && date.Length == 0 && spec.Length == 0 && amt.Length == 0) continue;

                data.Items.Add(new InvoiceItem { Date = date, Name = name, Spec = spec, Amt = amt, TaxAmount = tax });
            }

            // 합계금액 = 공급가액 + 세액 (PDF와 목록의 전체금액에 사용)
            data.Amt = data.GrandTotal.ToString("#,##0");
            return data;
        }

        /// <summary>
        /// 입력 내용을 검사한 뒤 DB에 저장한다. 새 명세서면 추가하고, 불러온 명세서면 수정한다.
        /// </summary>
        /// <param name="data">저장한 명세서 데이터 (Id가 채워져서 반환됨)</param>
        /// <returns>저장에 성공하면 true</returns>
        private bool SaveToDb(out InvoiceData data)
        {
            data = CollectData();

            if (data.BuyerName.Length == 0)
            {
                ToastForm.Show(this, "공급받는자(귀하)를 입력해 주세요", true);
                txtBuyer.Inner.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(data.CompanyName))
            {
                ToastForm.Show(this, "공급자를 선택해 주세요. 없으면 관리에서 등록하세요", true);
                return false;
            }

            try
            {
                data.Id = AppServices.Invoices.Save(data);
                _currentId = data.Id;

                RefreshList(data.Id);
                UpdateMode();
                return true;
            }
            catch (Exception ex)
            {
                Dialogs.Info(FindForm()!, "저장 오류", $"DB에 저장하는 중 오류가 발생했습니다.\n\n{ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// "저장" 버튼 클릭. DB에 저장하고 알림을 띄운다. (화면은 그대로 유지)
        /// </summary>
        private void btnSave_Click(object? sender, EventArgs e)
        {
            if (SaveToDb(out _)) ToastForm.Show(this, "저장했어요");
        }

        /// <summary>
        /// "PDF로 저장" 버튼 클릭. 먼저 DB에 저장하고, 새 PDF 파일을 만든다.
        /// 눌러서 만든 PDF는 매번 새 파일이며 이전에 만든 PDF는 그대로 남는다.
        /// </summary>
        private void btnPdf_Click(object? sender, EventArgs e)
        {
            if (!SaveToDb(out var data)) return;

            string path;
            try
            {
                path = InvoicePdfService.GeneratePdf(data);
            }
            catch (Exception ex)
            {
                Dialogs.Info(FindForm()!, "PDF 오류", $"명세서는 DB에 저장되었지만 PDF 파일 생성에 실패했습니다.\n\n{ex}");
                return;
            }

            lblPdfInfo.Text = "PDF 저장됨: " + Path.GetFileName(path);
            try
            {
                AppServices.Invoices.AddPdf(data.Id, path);
                ToastForm.Show(this, "저장하고 새 PDF를 만들었어요");
            }
            catch (Exception ex)
            {
                Dialogs.Info(FindForm()!, "PDF 이력 저장 오류", $"PDF 파일은 생성했지만 이력을 DB에 저장하지 못했습니다.\n저장된 파일: {path}\n\n{ex.GetType().Name}: {ex.Message}");
            }
        }

        /// <summary>
        /// "삭제" 버튼 클릭. 확인 후 현재 명세서를 DB에서 삭제한다. (이미 만든 PDF 파일은 남음)
        /// </summary>
        private void btnDelete_Click(object? sender, EventArgs e)
        {
            if (_currentId == 0)
            {
                ToastForm.Show(this, "저장된 명세서만 삭제할 수 있어요", true);
                return;
            }

            if (!Dialogs.Confirm(FindForm()!, "명세서를 삭제할까요?", "이미 만든 PDF 파일은 삭제되지 않아요.", "삭제", true)) return;

            try
            {
                AppServices.Invoices.Delete(_currentId);
                NewInvoice();
                RefreshList(null);
                ToastForm.Show(this, "삭제했어요");
            }
            catch (Exception ex)
            {
                Dialogs.Info(FindForm()!, "삭제 오류", ex.Message);
            }
        }
        #endregion

        #region 품목 표 - 행 추가/삭제, 금액 계산

        /// <summary>
        /// "품목 추가" 버튼 클릭. 빈 품목 줄을 한 줄 추가한다.
        /// </summary>
        private void btnAddRow_Click(object? sender, EventArgs e)
        {
            gridItems.Rows.Add();
        }

        /// <summary>
        /// "선택 행 삭제" 버튼 클릭. 선택한 품목 줄을 지우고 합계를 다시 계산한다.
        /// </summary>
        private void btnRemoveRow_Click(object? sender, EventArgs e)
        {
            if (gridItems.CurrentRow == null) return;

            HideDatePicker();
            gridItems.Rows.Remove(gridItems.CurrentRow);
            RecalcTotals();
        }

        /// <summary>
        /// 공급가액을 바꾸면 세액(10%)을 자동 계산하고 합계를 갱신한다.
        /// DB에서 불러오는 중(_loading)에는 저장된 세액이 바뀌지 않도록 동작하지 않는다.
        /// </summary>
        private void gridItems_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            if (_loading || e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (gridItems.Columns[e.ColumnIndex].Name != "colItemAmt") return;

            var row = gridItems.Rows[e.RowIndex];
            string? text = row.Cells["colItemAmt"].Value?.ToString();

            row.Cells["colItemTax"].Value = decimal.TryParse(text?.Replace(",", ""), out decimal amt)
                ? (amt * 0.1m).ToString()
                : null;

            RecalcTotals();
        }

        /// <summary>
        /// 모든 품목의 공급가액/세액을 합쳐서 아래 3개 요약 칸(공급가액, 세액, 합계금액)에 표시한다.
        /// </summary>
        private void RecalcTotals()
        {
            decimal sumAmt = 0, sumTax = 0;

            foreach (DataGridViewRow row in gridItems.Rows)
            {
                if (decimal.TryParse(row.Cells["colItemAmt"].Value?.ToString()?.Replace(",", ""), out var a)) sumAmt += a;
                if (decimal.TryParse(row.Cells["colItemTax"].Value?.ToString()?.Replace(",", ""), out var t)) sumTax += t;
            }

            pnlSum1Val.Text = sumAmt.ToString("#,##0");
            pnlSum2Val.Text = sumTax.ToString("#,##0");
            pnlSum3Val.Text = (sumAmt + sumTax).ToString("#,##0");
        }

        /// <summary>
        /// 공급가액/세액 칸의 숫자를 천 단위 콤마로 보기 좋게 표시한다. (저장되는 값은 그대로)
        /// </summary>
        private void gridItems_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.Value == null) return;

            string col = gridItems.Columns[e.ColumnIndex].Name;
            if (col != "colItemAmt" && col != "colItemTax") return;

            if (decimal.TryParse(e.Value.ToString()?.Replace(",", ""), out var v))
            {
                e.Value = v.ToString("#,##0");
                e.FormattingApplied = true;
            }
        }

        /// <summary>
        /// 값이 바뀌는 즉시 표에 반영되도록 편집을 확정한다.
        /// </summary>
        private void gridItems_CurrentCellDirtyStateChanged(object? sender, EventArgs e)
        {
            if (gridItems.IsCurrentCellDirty)
                gridItems.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
        #endregion

        #region 품목 표 - 날짜 선택

        /// <summary>
        /// 날짜 선택기와 지우기(×) 버튼을 숨긴다.
        /// </summary>
        private void HideDatePicker()
        {
            gridDatePicker.Visible = false;
            gridDateClearButton.Visible = false;
        }

        /// <summary>
        /// 일자 칸을 클릭하면 그 칸 위에 날짜 선택기와 지우기(×) 버튼을 띄운다.
        /// </summary>
        private void gridItems_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var column = gridItems.Columns[e.ColumnIndex];
            if (column.Name != "colItemDate")
            {
                HideDatePicker();
                if (!column.ReadOnly) gridItems.BeginEdit(true);
                return;
            }

            var cell = gridItems.Rows[e.RowIndex].Cells[e.ColumnIndex];

            _datePickerInitializing = true;
            gridDatePicker.Value = DateTime.TryParse(cell.Value?.ToString(), out var d) ? d : DateTime.Today;
            _datePickerInitializing = false;

            gridDatePicker.Visible = true;
            gridDateClearButton.Visible = true;
            PositionDateEditor();
            gridDatePicker.BringToFront();
            gridDateClearButton.BringToFront();
        }

        /// <summary>
        /// 날짜 선택기와 지우기 버튼을 일자 셀의 전체 너비에 맞춘다.
        /// </summary>
        private void PositionDateEditor()
        {
            if (gridItems.CurrentCell is not { } cell || cell.OwningColumn?.Name != "colItemDate") return;

            Rectangle rect = gridItems.GetCellDisplayRectangle(cell.ColumnIndex, cell.RowIndex, true);
            if (rect.Width <= gridDateClearButton.Width || rect.Height <= 0)
            {
                HideDatePicker();
                return;
            }

            int datePickerWidth = rect.Width - gridDateClearButton.Width;
            int editorHeight = Math.Max(rect.Height, gridItems.RowTemplate.Height);
            int editorY = rect.Y - (editorHeight - rect.Height) / 2;
            gridDatePicker.SetBounds(rect.X, editorY, datePickerWidth, editorHeight);
            gridDateClearButton.SetBounds(rect.X + datePickerWidth, editorY, gridDateClearButton.Width, editorHeight);
        }

        /// <summary>
        /// 일자가 아닌 다른 칸으로 이동하면 날짜 선택기를 숨긴다.
        /// </summary>
        private void gridItems_CellEnter(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (gridItems.Columns[e.ColumnIndex].Name != "colItemDate") HideDatePicker();
        }

        /// <summary>
        /// 표를 스크롤하면 날짜 선택기를 숨긴다. (위치가 어긋나는 것을 방지)
        /// </summary>
        private void gridItems_Scroll(object? sender, ScrollEventArgs e)
        {
            HideDatePicker();
        }

        /// <summary>
        /// 날짜 선택기에서 날짜를 바꾸면 현재 일자 칸에 yyyy-MM-dd 형식으로 입력한다.
        /// </summary>
        private void gridDatePicker_ValueChanged(object? sender, EventArgs e)
        {
            if (_datePickerInitializing) return;

            if (gridItems.CurrentCell?.OwningColumn?.Name == "colItemDate")
                gridItems.CurrentCell.Value = gridDatePicker.Value.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// 달력에서 날짜 선택을 마치면 현재 칸에 반영하고 날짜 선택기를 숨긴다.
        /// </summary>
        private void gridDatePicker_CloseUp(object? sender, EventArgs e)
        {
            if (gridItems.CurrentCell?.OwningColumn?.Name == "colItemDate")
                gridItems.CurrentCell.Value = gridDatePicker.Value.ToString("yyyy-MM-dd");

            HideDatePicker();
        }

        /// <summary>
        /// 지우기(×) 버튼을 누르면 현재 일자 칸의 날짜를 비운다.
        /// </summary>
        private void gridDateClearButton_Click(object? sender, EventArgs e)
        {
            if (gridItems.CurrentCell?.OwningColumn?.Name == "colItemDate")
                gridItems.CurrentCell.Value = null;

            HideDatePicker();
        }
        #endregion
    }
}
