using MailSender.Controls;
#nullable disable
namespace MailSender.Views
{
    partial class TemplateManageControl
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
            btnNew = new UiButton();
            lstItems = new UiListBox();
            cardForm = new UiCard();
            lblFormTitle = new Label();
            lblName = new Label();
            txtName = new UiTextBox();
            lblTitle2 = new Label();
            txtTitle = new UiTextBox();
            lblContent = new Label();
            txtContent = new UiTextBox();
            btnSave = new UiButton();
            btnDelete = new UiButton();
            tlp.SuspendLayout();
            cardList.SuspendLayout();
            cardForm.SuspendLayout();
            SuspendLayout();
            // 
            // tlp
            // 
            tlp.BackColor = Color.FromArgb(245, 246, 248);
            tlp.ColumnCount = 2;
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300F));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlp.Controls.Add(cardList, 0, 0);
            tlp.Controls.Add(cardForm, 1, 0);
            tlp.Dock = DockStyle.Fill;
            tlp.Location = new Point(0, 0);
            tlp.Name = "tlp";
            tlp.RowCount = 1;
            tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlp.Size = new Size(1004, 590);
            tlp.TabIndex = 0;
            // 
            // cardList
            // 
            cardList.BackColor = Color.Transparent;
            cardList.Controls.Add(btnNew);
            cardList.Controls.Add(lstItems);
            cardList.Dock = DockStyle.Fill;
            cardList.Location = new Point(0, 0);
            cardList.Margin = new Padding(0, 0, 8, 0);
            cardList.Name = "cardList";
            cardList.Size = new Size(292, 590);
            cardList.TabIndex = 0;
            // 
            // btnNew
            // 
            btnNew.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnNew.FlatStyle = FlatStyle.Flat;
            btnNew.Font = new Font("맑은 고딕", 10F, FontStyle.Bold);
            btnNew.Kind = ButtonKind.Primary;
            btnNew.Location = new Point(14, 14);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(264, 40);
            btnNew.TabIndex = 0;
            btnNew.Text = "＋ 새로 만들기";
            btnNew.UseVisualStyleBackColor = false;
            btnNew.Click += btnNew_Click;
            // 
            // lstItems
            // 
            lstItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstItems.BackColor = Color.White;
            lstItems.BorderStyle = BorderStyle.None;
            lstItems.DrawMode = DrawMode.OwnerDrawFixed;
            lstItems.IntegralHeight = false;
            lstItems.ItemHeight = 42;
            lstItems.Location = new Point(8, 64);
            lstItems.Name = "lstItems";
            lstItems.Size = new Size(276, 516);
            lstItems.TabIndex = 1;
            lstItems.SelectedIndexChanged += lstItems_SelectedIndexChanged;
            // 
            // cardForm
            // 
            cardForm.BackColor = Color.Transparent;
            cardForm.Controls.Add(lblFormTitle);
            cardForm.Controls.Add(lblName);
            cardForm.Controls.Add(txtName);
            cardForm.Controls.Add(lblTitle2);
            cardForm.Controls.Add(txtTitle);
            cardForm.Controls.Add(lblContent);
            cardForm.Controls.Add(txtContent);
            cardForm.Controls.Add(btnSave);
            cardForm.Controls.Add(btnDelete);
            cardForm.Dock = DockStyle.Fill;
            cardForm.Location = new Point(308, 0);
            cardForm.Margin = new Padding(8, 0, 0, 0);
            cardForm.Name = "cardForm";
            cardForm.Size = new Size(696, 590);
            cardForm.TabIndex = 1;
            // 
            // lblFormTitle
            // 
            lblFormTitle.AutoSize = true;
            lblFormTitle.BackColor = Color.Transparent;
            lblFormTitle.Font = new Font("맑은 고딕", 12F, FontStyle.Bold);
            lblFormTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblFormTitle.Location = new Point(18, 16);
            lblFormTitle.Name = "lblFormTitle";
            lblFormTitle.Size = new Size(64, 21);
            lblFormTitle.TabIndex = 0;
            lblFormTitle.Text = "새 항목";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.BackColor = Color.Transparent;
            lblName.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
            lblName.ForeColor = Color.Black;
            lblName.Location = new Point(18, 56);
            lblName.Name = "lblName";
            lblName.Size = new Size(59, 15);
            lblName.TabIndex = 1;
            lblName.Text = "양식 이름";
            // 
            // txtName
            // 
            txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtName.Font = new Font("맑은 고딕", 10F);
            txtName.Location = new Point(18, 78);
            txtName.Name = "txtName";
            txtName.PlaceholderText = "예: 정기 안내";
            txtName.Size = new Size(660, 38);
            txtName.TabIndex = 2;
            // 
            // lblTitle2
            // 
            lblTitle2.AutoSize = true;
            lblTitle2.BackColor = Color.Transparent;
            lblTitle2.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
            lblTitle2.ForeColor = Color.Black;
            lblTitle2.Location = new Point(18, 128);
            lblTitle2.Name = "lblTitle2";
            lblTitle2.Size = new Size(59, 15);
            lblTitle2.TabIndex = 3;
            lblTitle2.Text = "메일 제목";
            // 
            // txtTitle
            // 
            txtTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTitle.Font = new Font("맑은 고딕", 10F);
            txtTitle.Location = new Point(18, 150);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(660, 38);
            txtTitle.TabIndex = 4;
            // 
            // lblContent
            // 
            lblContent.AutoSize = true;
            lblContent.BackColor = Color.Transparent;
            lblContent.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
            lblContent.ForeColor = Color.Black;
            lblContent.Location = new Point(18, 200);
            lblContent.Name = "lblContent";
            lblContent.Size = new Size(59, 15);
            lblContent.TabIndex = 5;
            lblContent.Text = "메일 내용";
            // 
            // txtContent
            // 
            txtContent.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtContent.Font = new Font("맑은 고딕", 10F);
            txtContent.Location = new Point(18, 222);
            txtContent.Multiline = true;
            txtContent.Name = "txtContent";
            txtContent.Size = new Size(660, 296);
            txtContent.TabIndex = 6;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("맑은 고딕", 10F, FontStyle.Bold);
            btnSave.Kind = ButtonKind.Success;
            btnSave.Location = new Point(18, 534);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(120, 40);
            btnSave.TabIndex = 7;
            btnSave.Text = "추가";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("맑은 고딕", 10F, FontStyle.Bold);
            btnDelete.Kind = ButtonKind.Danger;
            btnDelete.Location = new Point(146, 534);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(90, 40);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "삭제";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // TemplateManageControl
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 246, 248);
            Controls.Add(tlp);
            Font = new Font("맑은 고딕", 10F);
            Name = "TemplateManageControl";
            Size = new Size(1004, 590);
            tlp.ResumeLayout(false);
            cardList.ResumeLayout(false);
            cardForm.ResumeLayout(false);
            cardForm.PerformLayout();
            ResumeLayout(false);
        }
        #endregion
        private TableLayoutPanel tlp;
        private UiCard cardList;
        private UiButton btnNew;
        private UiListBox lstItems;
        private UiCard cardForm;
        private Label lblFormTitle;
        private Label lblName;
        private UiTextBox txtName;
        private Label lblTitle2;
        private UiTextBox txtTitle;
        private Label lblContent;
        private UiTextBox txtContent;
        private UiButton btnSave;
        private UiButton btnDelete;
    }
}
