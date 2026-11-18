using MailSender.Controls;
#nullable disable
namespace MailSender.Views
{
    partial class SupplierManageControl
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
            lblRegNo = new Label();
            txtRegNo = new UiTextBox();
            lblCompany = new Label();
            txtCompany = new UiTextBox();
            lblCeo = new Label();
            txtCeo = new UiTextBox();
            lblAddress = new Label();
            txtAddress = new UiTextBox();
            lblBizType = new Label();
            txtBizType = new UiTextBox();
            lblBizItem = new Label();
            txtBizItem = new UiTextBox();
            chkDefault = new CheckBox();
            lblSeal = new Label();
            picSeal = new PictureBox();
            lblSealStatus = new Label();
            btnSelectSeal = new UiButton();
            btnClearSeal = new UiButton();
            btnSave = new UiButton();
            btnDelete = new UiButton();
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
            cardList.Controls.Add(btnNew);
            cardList.Controls.Add(lstItems);
            // 
            // btnNew
            // 
            btnNew.Kind = ButtonKind.Primary;
            btnNew.Text = "＋ 새로 만들기";
            btnNew.Size = new Size(272, 40);
            btnNew.Location = new Point(14, 14);
            btnNew.UseVisualStyleBackColor = false;
            btnNew.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnNew.TabIndex = 0;
            btnNew.Name = "btnNew";
            btnNew.Click += btnNew_Click;
            // 
            // lstItems
            // 
            lstItems.Location = new Point(8, 64);
            lstItems.Size = new Size(284, 516);
            lstItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstItems.TabIndex = 1;
            lstItems.Name = "lstItems";
            lstItems.SelectedIndexChanged += lstItems_SelectedIndexChanged;
            // 
            // cardForm
            // 
            cardForm.Size = new Size(700, 590);
            cardForm.Dock = DockStyle.Fill;
            cardForm.Margin = new Padding(8, 0, 0, 0);
            cardForm.TabIndex = 1;
            cardForm.Name = "cardForm";
            cardForm.Controls.Add(lblFormTitle);
            cardForm.Controls.Add(lblName);
            cardForm.Controls.Add(txtName);
            cardForm.Controls.Add(lblRegNo);
            cardForm.Controls.Add(txtRegNo);
            cardForm.Controls.Add(lblCompany);
            cardForm.Controls.Add(txtCompany);
            cardForm.Controls.Add(lblCeo);
            cardForm.Controls.Add(txtCeo);
            cardForm.Controls.Add(lblAddress);
            cardForm.Controls.Add(txtAddress);
            cardForm.Controls.Add(lblBizType);
            cardForm.Controls.Add(txtBizType);
            cardForm.Controls.Add(lblBizItem);
            cardForm.Controls.Add(txtBizItem);
            cardForm.Controls.Add(chkDefault);
            cardForm.Controls.Add(lblSeal);
            cardForm.Controls.Add(picSeal);
            cardForm.Controls.Add(lblSealStatus);
            cardForm.Controls.Add(btnSelectSeal);
            cardForm.Controls.Add(btnClearSeal);
            cardForm.Controls.Add(btnSave);
            cardForm.Controls.Add(btnDelete);
            // 
            // lblFormTitle
            // 
            lblFormTitle.AutoSize = true;
            lblFormTitle.BackColor = Color.Transparent;
            lblFormTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblFormTitle.Font = new Font("맑은 고딕", 12F, FontStyle.Bold);
            lblFormTitle.Location = new Point(18, 16);
            lblFormTitle.Text = "새 공급자";
            lblFormTitle.TabIndex = 0;
            lblFormTitle.Name = "lblFormTitle";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.BackColor = Color.Transparent;
            lblName.ForeColor = Color.FromArgb(107, 114, 128);
            lblName.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
            lblName.Location = new Point(18, 56);
            lblName.Text = "표시 이름";
            lblName.TabIndex = 1;
            lblName.Name = "lblName";
            // 
            // txtName
            // 
            txtName.Location = new Point(18, 78);
            txtName.Size = new Size(320, 38);
            txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            txtName.TabIndex = 2;
            txtName.Name = "txtName";
            // 
            // lblRegNo
            // 
            lblRegNo.AutoSize = true;
            lblRegNo.BackColor = Color.Transparent;
            lblRegNo.ForeColor = Color.FromArgb(107, 114, 128);
            lblRegNo.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
            lblRegNo.Location = new Point(358, 56);
            lblRegNo.Text = "사업자등록번호";
            lblRegNo.TabIndex = 3;
            lblRegNo.Name = "lblRegNo";
            // 
            // txtRegNo
            // 
            txtRegNo.Location = new Point(358, 78);
            txtRegNo.Size = new Size(324, 38);
            txtRegNo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtRegNo.TabIndex = 4;
            txtRegNo.Name = "txtRegNo";
            // 
            // lblCompany
            // 
            lblCompany.AutoSize = true;
            lblCompany.BackColor = Color.Transparent;
            lblCompany.ForeColor = Color.FromArgb(107, 114, 128);
            lblCompany.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
            lblCompany.Location = new Point(18, 128);
            lblCompany.Text = "상호(법인명)";
            lblCompany.TabIndex = 5;
            lblCompany.Name = "lblCompany";
            // 
            // txtCompany
            // 
            txtCompany.Location = new Point(18, 150);
            txtCompany.Size = new Size(320, 38);
            txtCompany.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            txtCompany.TabIndex = 6;
            txtCompany.Name = "txtCompany";
            // 
            // lblCeo
            // 
            lblCeo.AutoSize = true;
            lblCeo.BackColor = Color.Transparent;
            lblCeo.ForeColor = Color.FromArgb(107, 114, 128);
            lblCeo.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
            lblCeo.Location = new Point(358, 128);
            lblCeo.Text = "성명";
            lblCeo.TabIndex = 7;
            lblCeo.Name = "lblCeo";
            // 
            // txtCeo
            // 
            txtCeo.Location = new Point(358, 150);
            txtCeo.Size = new Size(324, 38);
            txtCeo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCeo.TabIndex = 8;
            txtCeo.Name = "txtCeo";
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.BackColor = Color.Transparent;
            lblAddress.ForeColor = Color.FromArgb(107, 114, 128);
            lblAddress.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
            lblAddress.Location = new Point(18, 200);
            lblAddress.Text = "사업장 주소";
            lblAddress.TabIndex = 9;
            lblAddress.Name = "lblAddress";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(18, 222);
            txtAddress.Size = new Size(664, 38);
            txtAddress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtAddress.TabIndex = 10;
            txtAddress.Name = "txtAddress";
            // 
            // lblBizType
            // 
            lblBizType.AutoSize = true;
            lblBizType.BackColor = Color.Transparent;
            lblBizType.ForeColor = Color.FromArgb(107, 114, 128);
            lblBizType.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
            lblBizType.Location = new Point(18, 272);
            lblBizType.Text = "업태";
            lblBizType.TabIndex = 11;
            lblBizType.Name = "lblBizType";
            // 
            // txtBizType
            // 
            txtBizType.Location = new Point(18, 294);
            txtBizType.Size = new Size(320, 38);
            txtBizType.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            txtBizType.TabIndex = 12;
            txtBizType.Name = "txtBizType";
            // 
            // lblBizItem
            // 
            lblBizItem.AutoSize = true;
            lblBizItem.BackColor = Color.Transparent;
            lblBizItem.ForeColor = Color.FromArgb(107, 114, 128);
            lblBizItem.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
            lblBizItem.Location = new Point(358, 272);
            lblBizItem.Text = "종목";
            lblBizItem.TabIndex = 13;
            lblBizItem.Name = "lblBizItem";
            // 
            // txtBizItem
            // 
            txtBizItem.Location = new Point(358, 294);
            txtBizItem.Size = new Size(324, 38);
            txtBizItem.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBizItem.TabIndex = 14;
            txtBizItem.Name = "txtBizItem";
            // 
            // chkDefault
            // 
            chkDefault.AutoSize = true;
            chkDefault.BackColor = Color.Transparent;
            chkDefault.Font = new Font("맑은 고딕", 10F);
            chkDefault.Location = new Point(18, 356);
            chkDefault.Text = "새 거래명세서의 기본 공급자로 사용";
            chkDefault.UseVisualStyleBackColor = false;
            chkDefault.TabIndex = 15;
            chkDefault.Name = "chkDefault";
            // 
            // lblSeal
            // 
            lblSeal.AutoSize = true;
            lblSeal.BackColor = Color.Transparent;
            lblSeal.ForeColor = Color.FromArgb(107, 114, 128);
            lblSeal.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
            lblSeal.Location = new Point(18, 390);
            lblSeal.Text = "직인 이미지";
            lblSeal.TabIndex = 16;
            lblSeal.Name = "lblSeal";
            // 
            // picSeal
            // 
            picSeal.BackColor = Color.White;
            picSeal.BorderStyle = BorderStyle.FixedSingle;
            picSeal.Location = new Point(18, 414);
            picSeal.Name = "picSeal";
            picSeal.Size = new Size(96, 96);
            picSeal.SizeMode = PictureBoxSizeMode.Zoom;
            picSeal.TabIndex = 17;
            picSeal.TabStop = false;
            // 
            // lblSealStatus
            // 
            lblSealStatus.AutoSize = true;
            lblSealStatus.BackColor = Color.Transparent;
            lblSealStatus.ForeColor = Color.FromArgb(107, 114, 128);
            lblSealStatus.Font = new Font("맑은 고딕", 9F);
            lblSealStatus.Location = new Point(126, 414);
            lblSealStatus.Text = "직인이 등록되지 않았습니다.";
            lblSealStatus.TabIndex = 18;
            lblSealStatus.Name = "lblSealStatus";
            // 
            // btnSelectSeal
            // 
            btnSelectSeal.Kind = ButtonKind.Secondary;
            btnSelectSeal.Text = "이미지 등록";
            btnSelectSeal.Size = new Size(120, 38);
            btnSelectSeal.Location = new Point(126, 440);
            btnSelectSeal.UseVisualStyleBackColor = false;
            btnSelectSeal.TabIndex = 19;
            btnSelectSeal.Name = "btnSelectSeal";
            btnSelectSeal.Click += btnSelectSeal_Click;
            // 
            // btnClearSeal
            // 
            btnClearSeal.Kind = ButtonKind.Link;
            btnClearSeal.Text = "직인 제거";
            btnClearSeal.Size = new Size(90, 32);
            btnClearSeal.Location = new Point(254, 443);
            btnClearSeal.UseVisualStyleBackColor = false;
            btnClearSeal.TabIndex = 20;
            btnClearSeal.Name = "btnClearSeal";
            btnClearSeal.Click += btnClearSeal_Click;
            // 
            // btnSave
            // 
            btnSave.Kind = ButtonKind.Success;
            btnSave.Text = "추가";
            btnSave.Size = new Size(120, 40);
            btnSave.Location = new Point(18, 534);
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSave.TabIndex = 16;
            btnSave.Name = "btnSave";
            btnSave.Click += btnSave_Click;
            // 
            // btnDelete
            // 
            btnDelete.Kind = ButtonKind.Danger;
            btnDelete.Text = "삭제";
            btnDelete.Size = new Size(90, 40);
            btnDelete.Location = new Point(146, 534);
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDelete.TabIndex = 17;
            btnDelete.Name = "btnDelete";
            btnDelete.Click += btnDelete_Click;
            // 
            // SupplierManageControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 246, 248);
            Size = new Size(1004, 590);
            Font = new Font("맑은 고딕", 10F);
            Controls.Add(tlp);
            Name = "SupplierManageControl";
            tlp.ResumeLayout(false);
            cardList.ResumeLayout(false);
            cardForm.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
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
        private Label lblRegNo;
        private UiTextBox txtRegNo;
        private Label lblCompany;
        private UiTextBox txtCompany;
        private Label lblCeo;
        private UiTextBox txtCeo;
        private Label lblAddress;
        private UiTextBox txtAddress;
        private Label lblBizType;
        private UiTextBox txtBizType;
        private Label lblBizItem;
        private UiTextBox txtBizItem;
        private CheckBox chkDefault;
        private Label lblSeal;
        private PictureBox picSeal;
        private Label lblSealStatus;
        private UiButton btnSelectSeal;
        private UiButton btnClearSeal;
        private UiButton btnSave;
        private UiButton btnDelete;
    }
}
