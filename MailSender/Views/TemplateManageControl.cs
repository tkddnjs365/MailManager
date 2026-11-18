using MailSender.Forms;
using MailSender.Models;
using MailSender.Services;

namespace MailSender.Views
{
    /// <summary>
    /// 관리 > "메일 양식" 탭. 메일 제목/내용 양식을 추가·수정·삭제한다. (모두 DB에 저장)
    /// </summary>
    public partial class TemplateManageControl : UserControl, IRefreshable
    {
        /// <summary>목록에서 선택된 양식 (선택이 없으면 null = 새로 만들기)</summary>
        private MailTemplate? Selected => lstItems.SelectedItem as MailTemplate;

        /// <summary>
        /// 컨트롤을 만들고 목록이 보여줄 글자(이름)를 지정한다.
        /// </summary>
        public TemplateManageControl()
        {
            InitializeComponent();
            lstItems.DisplayMember = "Name";
        }

        /// <summary>
        /// DB에서 양식 목록을 다시 읽어 표시한다.
        /// </summary>
        public void RefreshView()
        {
            Reload(Selected?.Id);
        }

        /// <summary>
        /// 목록을 다시 채우고, selectId에 해당하는 양식을 선택한다. (없으면 선택 해제)
        /// </summary>
        private void Reload(long? selectId)
        {
            AppServices.Templates.Load();

            lstItems.DataSource = null;
            lstItems.DataSource = AppServices.Templates.Templates;

            var match = selectId == null ? null : AppServices.Templates.Templates.FirstOrDefault(t => t.Id == selectId);
            if (match != null) lstItems.SelectedItem = match; else lstItems.SelectedIndex = -1;

            FillForm();
        }

        /// <summary>
        /// 선택한 양식을 오른쪽 입력창에 채운다. 선택이 없으면 비운 "새 항목" 상태가 된다.
        /// </summary>
        private void FillForm()
        {
            var t = Selected;

            txtName.Text = t?.Name ?? "";
            txtTitle.Text = t?.Title ?? "";
            txtContent.Text = t?.Content ?? "";

            lblFormTitle.Text = t == null ? "새 항목" : "수정";
            btnSave.Text = t == null ? "추가" : "수정 저장";
            btnDelete.Visible = t != null;
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
        /// "추가 / 수정 저장" 버튼 클릭. 선택이 없으면 새 양식으로 추가하고, 있으면 수정한다.
        /// </summary>
        private void btnSave_Click(object? sender, EventArgs e)
        {
            string name = txtName.Text.Trim(), title = txtTitle.Text.Trim();

            if (name.Length == 0) { ToastForm.Show(this, "양식 이름을 입력해 주세요", true); txtName.Inner.Focus(); return; }
            if (title.Length == 0) { ToastForm.Show(this, "메일 제목을 입력해 주세요", true); txtTitle.Inner.Focus(); return; }

            try
            {
                long id;
                if (Selected is { } t)
                {
                    AppServices.Templates.Update(t.Id, name, title, txtContent.Text);
                    id = t.Id;
                }
                else
                {
                    id = AppServices.Templates.Add(name, title, txtContent.Text).Id;
                }

                Reload(id);
                AppEvents.RaiseTemplatesChanged();
                ToastForm.Show(this, "저장했어요");
            }
            catch (Exception ex)
            {
                Dialogs.Info(FindForm()!, "저장 오류", ex.Message);
            }
        }

        /// <summary>
        /// "삭제" 버튼 클릭. 확인 후 선택한 양식을 DB에서 삭제한다.
        /// </summary>
        private void btnDelete_Click(object? sender, EventArgs e)
        {
            if (Selected is not { } t) return;
            if (!Dialogs.Confirm(FindForm()!, "양식을 삭제할까요?", $"'{t.Name}' 양식이 삭제돼요.", "삭제", true)) return;

            AppServices.Templates.Remove(t.Id);
            Reload(null);
            AppEvents.RaiseTemplatesChanged();
            ToastForm.Show(this, "삭제했어요");
        }
    }
}
