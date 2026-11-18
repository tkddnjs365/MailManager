using MailSender.Forms;
using MailSender.Models;
using MailSender.Services;

namespace MailSender.Views
{
    /// <summary>
    /// 관리 > "공급자" 탭. 거래명세서에 들어가는 공급자 정보를 추가·수정·삭제한다. (모두 DB에 저장)
    /// </summary>
    public partial class SupplierManageControl : UserControl, IRefreshable
    {
        private byte[]? _sealImage;

        /// <summary>목록에서 선택된 공급자 (선택이 없으면 null = 새로 만들기)</summary>
        private InvoiceSupplier? Selected => lstItems.SelectedItem as InvoiceSupplier;

        /// <summary>
        /// 컨트롤을 만들고, 기본 공급자에는 "기본" 표시가 붙도록 지정한다.
        /// </summary>
        public SupplierManageControl()
        {
            InitializeComponent();
            lstItems.DisplayMember = "Name";
            lstItems.HintSelector = item => item is InvoiceSupplier s && s.IsDefault ? "기본" : null;
        }

        /// <summary>
        /// DB에서 공급자 목록을 다시 읽어 표시한다.
        /// </summary>
        public void RefreshView()
        {
            Reload(Selected?.Id);
        }

        /// <summary>
        /// 목록을 다시 채우고, selectId에 해당하는 공급자를 선택한다. (없으면 선택 해제)
        /// </summary>
        private void Reload(long? selectId)
        {
            AppServices.Suppliers.Load();

            lstItems.DataSource = null;
            lstItems.DataSource = AppServices.Suppliers.Suppliers;

            var match = selectId == null ? null : AppServices.Suppliers.Suppliers.FirstOrDefault(s => s.Id == selectId);
            if (match != null) lstItems.SelectedItem = match; else lstItems.SelectedIndex = -1;

            FillForm();
        }

        /// <summary>
        /// 선택한 공급자를 입력창에 채운다. 선택이 없으면 비운 "새 공급자" 상태가 된다.
        /// </summary>
        private void FillForm()
        {
            var s = Selected;

            txtName.Text = s?.Name ?? "";
            txtRegNo.Text = s?.RegNo ?? "";
            txtCompany.Text = s?.CompanyName ?? "";
            txtCeo.Text = s?.CeoName ?? "";
            txtAddress.Text = s?.Address ?? "";
            txtBizType.Text = s?.BizType ?? "";
            txtBizItem.Text = s?.BizItem ?? "";
            chkDefault.Checked = s?.IsDefault ?? false;
            SetSealImage(s?.SealImage);

            lblFormTitle.Text = s == null ? "새 공급자" : "수정";
            btnSave.Text = s == null ? "추가" : "수정 저장";
            btnDelete.Visible = s != null;
        }

        private void SetSealImage(byte[]? imageData)
        {
            Bitmap? preview = null;
            byte[]? imageCopy = imageData?.ToArray();

            if (imageCopy != null)
            {
                using var stream = new MemoryStream(imageCopy);
                using var image = Image.FromStream(stream);
                preview = new Bitmap(image);
            }

            var oldPreview = picSeal.Image;
            _sealImage = imageCopy;
            picSeal.Image = preview;
            oldPreview?.Dispose();
            lblSealStatus.Text = imageCopy == null
                ? "직인이 등록되지 않았습니다."
                : "직인이 등록되어 있습니다.";
        }

        private void btnSelectSeal_Click(object? sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog
            {
                Title = "직인 이미지 선택",
                Filter = "이미지 파일 (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp",
                CheckFileExists = true,
                Multiselect = false,
            };

            if (dialog.ShowDialog(this) != DialogResult.OK) return;

            try
            {
                byte[] imageData = File.ReadAllBytes(dialog.FileName);
                using (var stream = new MemoryStream(imageData))
                using (Image.FromStream(stream))
                {
                }

                SetSealImage(imageData);
            }
            catch (Exception ex)
            {
                Dialogs.Info(FindForm()!, "직인 이미지 오류", $"이미지를 불러오지 못했습니다.\n\n{ex.Message}");
            }
        }

        private void btnClearSeal_Click(object? sender, EventArgs e)
        {
            SetSealImage(null);
            lblSealStatus.Text = "직인이 등록되지 않았습니다.";
        }

        /// <summary>
        /// 목록에서 선택이 바뀌면 입력창을 갱신한다.
        /// </summary>
        private void lstItems_SelectedIndexChanged(object? sender, EventArgs e)
        {
            FillForm();
        }

        /// <summary>
        /// "새로 만들기" 버튼 클릭. 선택을 풀고 빈 입력창으로 만든다.
        /// </summary>
        private void btnNew_Click(object? sender, EventArgs e)
        {
            lstItems.SelectedIndex = -1;
            FillForm();
            txtName.Inner.Focus();
        }

        /// <summary>
        /// "추가 / 수정 저장" 버튼 클릭. 상호(법인명)는 필수이며, 표시 이름이 비어 있으면 상호를 사용한다.
        /// </summary>
        private void btnSave_Click(object? sender, EventArgs e)
        {
            string company = txtCompany.Text.Trim();
            if (company.Length == 0) { ToastForm.Show(this, "상호(법인명)를 입력해 주세요", true); txtCompany.Inner.Focus(); return; }

            var s = new InvoiceSupplier
            {
                Id = Selected?.Id ?? 0,
                Name = txtName.Text.Trim().Length > 0 ? txtName.Text.Trim() : company,
                RegNo = txtRegNo.Text.Trim(), CompanyName = company, CeoName = txtCeo.Text.Trim(),
                Address = txtAddress.Text.Trim(), BizType = txtBizType.Text.Trim(), BizItem = txtBizItem.Text.Trim(),
                IsDefault = chkDefault.Checked, SealImage = _sealImage?.ToArray(),
            };

            try
            {
                long id;
                if (s.Id == 0) id = AppServices.Suppliers.Add(s);
                else { AppServices.Suppliers.Update(s); id = s.Id; }

                Reload(id);
                AppEvents.RaiseSuppliersChanged();
                ToastForm.Show(this, "저장했어요");
            }
            catch (Exception ex)
            {
                Dialogs.Info(FindForm()!, "저장 오류", ex.Message);
            }
        }

        /// <summary>
        /// "삭제" 버튼 클릭. 확인 후 공급자를 삭제한다. (이미 저장된 명세서 내용은 그대로 유지됨)
        /// </summary>
        private void btnDelete_Click(object? sender, EventArgs e)
        {
            if (Selected is not { } s) return;
            if (!Dialogs.Confirm(FindForm()!, "공급자를 삭제할까요?", "이미 저장된 거래명세서의 내용은 변하지 않아요.", "삭제", true)) return;

            AppServices.Suppliers.Remove(s.Id);
            Reload(null);
            AppEvents.RaiseSuppliersChanged();
            ToastForm.Show(this, "삭제했어요");
        }
    }
}
