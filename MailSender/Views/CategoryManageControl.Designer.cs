using MailSender.Controls;
#nullable disable
namespace MailSender.Views
{
    partial class CategoryManageControl
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            tlp = new TableLayoutPanel();
            cardList = new UiCard();
            btnAddCategory = new UiButton();
            lstCategories = new UiListBox();
            cardForm = new UiCard();
            lblCatName = new Label();
            btnAddFile = new UiButton();
            btnDeleteCategory = new UiButton();
            lblCatHint = new Label();
            lstFiles = new UiListBox();
            btnDeleteFile = new UiButton();
            openFileDialog1 = new OpenFileDialog();
            tlp.SuspendLayout();
            cardList.SuspendLayout();
            cardForm.SuspendLayout();
            SuspendLayout();
            // 
            // tlp
            // 
            tlp.Dock = DockStyle.Fill;
            tlp.BackColor = Color.FromArgb(245, 246, 248);
            tlp.ColumnCount = 2;
            tlp.RowCount = 1;
            tlp.Padding = new Padding(0, 0, 0, 0);
            tlp.TabIndex = 0;
            tlp.Name = "tlp";
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300F));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlp.Controls.Add(cardList, 0, 0);
            tlp.Controls.Add(cardForm, 1, 0);
            // 
            // cardList
            // 
            cardList.Size = new Size(300, 590);
            cardList.Dock = DockStyle.Fill;
            cardList.Margin = new Padding(0, 0, 8, 0);
            cardList.TabIndex = 0;
            cardList.Name = "cardList";
            cardList.Controls.Add(btnAddCategory);
            cardList.Controls.Add(lstCategories);
            // 
            // btnAddCategory
            // 
            btnAddCategory.Kind = ButtonKind.Primary;
            btnAddCategory.Text = "＋ 구분 추가";
            btnAddCategory.Size = new Size(272, 40);
            btnAddCategory.Location = new Point(14, 14);
            btnAddCategory.UseVisualStyleBackColor = false;
            btnAddCategory.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnAddCategory.TabIndex = 0;
            btnAddCategory.Name = "btnAddCategory";
            btnAddCategory.Click += btnAddCategory_Click;
            // 
            // lstCategories
            // 
            lstCategories.Location = new Point(8, 64);
            lstCategories.Size = new Size(284, 516);
            lstCategories.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstCategories.TabIndex = 1;
            lstCategories.Name = "lstCategories";
            lstCategories.SelectedIndexChanged += lstCategories_SelectedIndexChanged;
            // 
            // cardForm
            // 
            cardForm.Size = new Size(700, 590);
            cardForm.Dock = DockStyle.Fill;
            cardForm.Margin = new Padding(8, 0, 0, 0);
            cardForm.TabIndex = 1;
            cardForm.Name = "cardForm";
            cardForm.Controls.Add(lblCatName);
            cardForm.Controls.Add(btnAddFile);
            cardForm.Controls.Add(btnDeleteCategory);
            cardForm.Controls.Add(lblCatHint);
            cardForm.Controls.Add(lstFiles);
            cardForm.Controls.Add(btnDeleteFile);
            // 
            // lblCatName
            // 
            lblCatName.AutoSize = true;
            lblCatName.BackColor = Color.Transparent;
            lblCatName.ForeColor = Color.FromArgb(17, 24, 39);
            lblCatName.Font = new Font("맑은 고딕", 12F, FontStyle.Bold);
            lblCatName.Location = new Point(18, 16);
            lblCatName.Text = "왼쪽에서 구분을 선택하세요";
            lblCatName.TabIndex = 0;
            lblCatName.Name = "lblCatName";
            // 
            // btnAddFile
            // 
            btnAddFile.Kind = ButtonKind.Secondary;
            btnAddFile.Text = "＋ 파일 추가";
            btnAddFile.Size = new Size(110, 34);
            btnAddFile.Location = new Point(476, 12);
            btnAddFile.UseVisualStyleBackColor = false;
            btnAddFile.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddFile.TabIndex = 1;
            btnAddFile.Name = "btnAddFile";
            btnAddFile.Click += btnAddFile_Click;
            // 
            // btnDeleteCategory
            // 
            btnDeleteCategory.Kind = ButtonKind.Danger;
            btnDeleteCategory.Text = "구분 삭제";
            btnDeleteCategory.Size = new Size(90, 34);
            btnDeleteCategory.Location = new Point(594, 12);
            btnDeleteCategory.UseVisualStyleBackColor = false;
            btnDeleteCategory.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDeleteCategory.TabIndex = 2;
            btnDeleteCategory.Name = "btnDeleteCategory";
            btnDeleteCategory.Click += btnDeleteCategory_Click;
            // 
            // lblCatHint
            // 
            lblCatHint.AutoSize = true;
            lblCatHint.BackColor = Color.Transparent;
            lblCatHint.ForeColor = Color.FromArgb(107, 114, 128);
            lblCatHint.Font = new Font("맑은 고딕", 9F);
            lblCatHint.Location = new Point(18, 56);
            lblCatHint.Text = "파일 내용은 DB에 저장되어 원본 경로 없이도 바로 첨부돼요.";
            lblCatHint.TabIndex = 3;
            lblCatHint.Name = "lblCatHint";
            // 
            // lstFiles
            // 
            lstFiles.Location = new Point(18, 86);
            lstFiles.Size = new Size(664, 432);
            lstFiles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstFiles.TabIndex = 4;
            lstFiles.Name = "lstFiles";
            // 
            // btnDeleteFile
            // 
            btnDeleteFile.Kind = ButtonKind.Danger;
            btnDeleteFile.Text = "선택 파일 삭제";
            btnDeleteFile.Size = new Size(130, 40);
            btnDeleteFile.Location = new Point(18, 534);
            btnDeleteFile.UseVisualStyleBackColor = false;
            btnDeleteFile.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDeleteFile.TabIndex = 5;
            btnDeleteFile.Name = "btnDeleteFile";
            btnDeleteFile.Click += btnDeleteFile_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.Multiselect = true;
            openFileDialog1.Title = "첨부할 파일 선택";
            // 
            // CategoryManageControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 246, 248);
            Size = new Size(1004, 590);
            Font = new Font("맑은 고딕", 10F);
            Controls.Add(tlp);
            Name = "CategoryManageControl";
            tlp.ResumeLayout(false);
            cardList.ResumeLayout(false);
            cardForm.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion
        private TableLayoutPanel tlp;
        private UiCard cardList;
        private UiButton btnAddCategory;
        private UiListBox lstCategories;
        private UiCard cardForm;
        private Label lblCatName;
        private UiButton btnAddFile;
        private UiButton btnDeleteCategory;
        private Label lblCatHint;
        private UiListBox lstFiles;
        private UiButton btnDeleteFile;
        private OpenFileDialog openFileDialog1;
    }
}
