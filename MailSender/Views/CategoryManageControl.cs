using MailSender.Forms;
using MailSender.Models;
using MailSender.Services;

namespace MailSender.Views
{
    /// <summary>
    /// 관리 > "첨부파일" 탭. 구분(세트)을 만들고, 각 구분에 첨부파일을 DB로 저장/삭제한다.
    /// 파일 내용 자체가 DB에 저장되므로 원본 파일이 없어져도 바로 첨부할 수 있다.
    /// </summary>
    public partial class CategoryManageControl : UserControl, IRefreshable
    {
        /// <summary>왼쪽 목록에서 선택된 구분 (선택이 없으면 null)</summary>
        private AttachmentCategory? Selected => lstCategories.SelectedItem as AttachmentCategory;

        /// <summary>
        /// 컨트롤을 만들고, 구분 이름 옆에 파일 개수가 표시되도록 지정한다.
        /// </summary>
        public CategoryManageControl()
        {
            InitializeComponent();
            lstCategories.DisplayMember = "Name";
            lstCategories.HintSelector = item => item is AttachmentCategory c ? $"{c.Files.Count}개" : null;
        }

        /// <summary>
        /// DB에서 구분/파일 목록을 다시 읽어 표시한다.
        /// </summary>
        public void RefreshView()
        {
            Reload(Selected?.Id);
        }

        /// <summary>
        /// 구분 목록을 다시 채우고, selectId에 해당하는 구분을 선택한다. (없으면 선택 해제)
        /// </summary>
        private void Reload(long? selectId)
        {
            AppServices.Categories.Load();

            lstCategories.DataSource = null;
            lstCategories.DataSource = AppServices.Categories.Categories;

            var match = selectId == null ? null : AppServices.Categories.Categories.FirstOrDefault(c => c.Id == selectId);
            if (match != null) lstCategories.SelectedItem = match; else lstCategories.SelectedIndex = -1;

            FillFiles();
        }

        /// <summary>
        /// 선택한 구분의 첨부파일 목록을 오른쪽에 표시한다.
        /// </summary>
        private void FillFiles()
        {
            lstFiles.Items.Clear();

            var c = Selected;
            lblCatName.Text = c == null ? "왼쪽에서 구분을 선택하세요" : c.Name;
            btnAddFile.Enabled = btnDeleteCategory.Enabled = btnDeleteFile.Enabled = c != null;

            if (c == null) return;
            foreach (var f in c.Files) lstFiles.Items.Add(f);
        }

        /// <summary>
        /// 구분 선택이 바뀌면 그 구분의 파일 목록으로 바꾼다.
        /// </summary>
        private void lstCategories_SelectedIndexChanged(object? sender, EventArgs e)
        {
            FillFiles();
        }

        /// <summary>
        /// "구분 추가" 버튼 클릭. 이름을 입력받아 새 구분을 DB에 만든다.
        /// </summary>
        private void btnAddCategory_Click(object? sender, EventArgs e)
        {
            string? name = Dialogs.Prompt(FindForm()!, "새 구분 이름을 입력하세요", "예: 홍길동-지게차");
            if (string.IsNullOrWhiteSpace(name)) return;

            var created = AppServices.Categories.AddCategory(name.Trim());
            Reload(created.Id);
            AppEvents.RaiseCategoriesChanged();
        }

        /// <summary>
        /// "구분 삭제" 버튼 클릭. 확인 후 구분과 그 안의 파일을 모두 삭제한다.
        /// </summary>
        private void btnDeleteCategory_Click(object? sender, EventArgs e)
        {
            if (Selected is not { } c) return;
            if (!Dialogs.Confirm(FindForm()!, "구분을 삭제할까요?", $"'{c.Name}' 구분과 첨부파일이 모두 삭제돼요.", "삭제", true)) return;

            AppServices.Categories.RemoveCategory(c.Id);
            Reload(null);
            AppEvents.RaiseCategoriesChanged();
            ToastForm.Show(this, "삭제했어요");
        }

        /// <summary>
        /// "파일 추가" 버튼 클릭. 파일을 선택하면 내용을 읽어 선택된 구분에 DB로 저장한다.
        /// 같은 내용의 파일이 이미 있으면 중복으로 보고 건너뛴다.
        /// </summary>
        private void btnAddFile_Click(object? sender, EventArgs e)
        {
            if (Selected is not { } c) return;
            if (openFileDialog1.ShowDialog(this) != DialogResult.OK) return;

            // 큰 파일은 DB에 저장하는 데 시간이 걸리므로 마우스를 대기 모양으로 바꾼다.
            Cursor = Cursors.WaitCursor;
            try
            {
                var (added, duplicated) = AppServices.Categories.AddFiles(c.Id, openFileDialog1.FileNames);

                Reload(c.Id);
                AppEvents.RaiseCategoriesChanged();
                ToastForm.Show(this, duplicated > 0 ? $"{added}개 저장, 같은 파일 {duplicated}개는 건너뛰었어요" : $"{added}개 저장했어요");
            }
            catch (Exception ex)
            {
                Dialogs.Info(FindForm()!, "파일 저장 오류", ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// "선택 파일 삭제" 버튼 클릭. 오른쪽 목록에서 고른 파일을 DB에서 삭제한다.
        /// </summary>
        private void btnDeleteFile_Click(object? sender, EventArgs e)
        {
            if (lstFiles.SelectedItem is not AttachmentFile f) return;

            AppServices.Categories.RemoveFile(f.Id);
            Reload(Selected?.Id);
            AppEvents.RaiseCategoriesChanged();
            ToastForm.Show(this, "삭제했어요");
        }
    }
}
