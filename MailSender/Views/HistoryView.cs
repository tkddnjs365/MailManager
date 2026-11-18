using System.ComponentModel;
using MailSender.Controls;
using MailSender.Models;
using MailSender.Services;

namespace MailSender.Views
{
    /// <summary>
    /// "전송 이력" 화면. DB에 저장된 보낸 메일 목록과, 선택한 메일의 내용/첨부파일(파일명, 원본경로)을 보여준다.
    /// </summary>
    public partial class HistoryView : UserControl, IRefreshable
    {
        /// <summary>목록에 표시 중인 이력 (그리드 행 순서와 같음)</summary>
        private List<MailHistoryRow> _rows = new();

        /// <summary>
        /// 화면을 만들고, 새 이력이 쌓이면 자동으로 새로 읽도록 연결한다.
        /// </summary>
        public HistoryView()
        {
            InitializeComponent();

            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

            AppEvents.HistoryChanged += RefreshView;
        }

        /// <summary>
        /// DB에서 전송 이력을 읽어 목록에 표시한다. 읽기 전에 선택했던 이력이 있으면 다시 선택한다.
        /// </summary>
        public void RefreshView()
        {
            try
            {
                long? keep = SelectedRow()?.Id;
                _rows = MailHistoryStore.Search();

                gridHistory.Rows.Clear();
                foreach (var r in _rows)
                {
                    int i = gridHistory.Rows.Add(r.SentAt, r.Recipient, r.Subject, r.Status);
                    gridHistory.Rows[i].Cells[3].Style.ForeColor = r.Status == "성공" ? Ui.Ok : Ui.Danger;
                }

                if (_rows.Count == 0)
                {
                    ShowDetail(null);
                    return;
                }

                int idx = keep == null ? 0 : Math.Max(0, _rows.FindIndex(x => x.Id == keep));
                gridHistory.ClearSelection();
                gridHistory.Rows[idx].Selected = true;
                gridHistory.CurrentCell = gridHistory.Rows[idx].Cells[0];
                ShowDetail(_rows[idx]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"전송 이력을 불러오지 못했습니다.\n\n{ex.Message}", "오류");
            }
        }

        /// <summary>
        /// 목록에서 현재 선택된 이력을 반환한다. (없으면 null)
        /// </summary>
        private MailHistoryRow? SelectedRow()
        {
            if (gridHistory.SelectedRows.Count == 0) return null;
            int i = gridHistory.SelectedRows[0].Index;
            return i >= 0 && i < _rows.Count ? _rows[i] : null;
        }

        /// <summary>
        /// 목록의 선택이 바뀌면 오른쪽 상세 영역을 갱신한다.
        /// </summary>
        private void gridHistory_SelectionChanged(object? sender, EventArgs e)
        {
            ShowDetail(SelectedRow());
        }

        /// <summary>
        /// 선택한 이력의 제목, 보낸 정보, 내용, 첨부파일 목록을 오른쪽 상세 영역에 표시한다.
        /// </summary>
        private void ShowDetail(MailHistoryRow? row)
        {
            lstAttach.Items.Clear();

            if (row == null)
            {
                lblDetSubject.Text = "이력을 선택하세요";
                lblDetMeta.Text = "";
                txtDetBody.Text = "";
                return;
            }

            lblDetSubject.Text = row.Subject;
            lblDetMeta.Text = $"{row.SentAt}  ·  {row.Recipient}  ·  {row.Status}" +
                              (row.MailCount > 1 ? $"  ·  {row.MailCount}통" : "") +
                              (row.ErrorMessage.Length > 0 ? $"\n{row.ErrorMessage}" : "");
            txtDetBody.Text = row.Body;

            foreach (var a in MailHistoryStore.GetAttachments(row.Id))
            {
                lstAttach.Items.Add($"{a.FileName}   ·   {a.FilePath}");
            }
        }
    }
}
