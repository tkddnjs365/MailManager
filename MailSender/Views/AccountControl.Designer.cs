using MailSender.Controls;
#nullable disable
namespace MailSender.Views
{
    partial class AccountControl
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
            cardAccount = new UiCard();
            lblFormTitle = new Label();
            lblServer = new Label();
            txtServer = new UiTextBox();
            lblPort = new Label();
            txtPort = new UiTextBox();
            lblMailId = new Label();
            txtMailId = new UiTextBox();
            lblPassword = new Label();
            txtPassword = new UiTextBox();
            lblSender = new Label();
            txtSender = new UiTextBox();
            btnSave = new UiButton();
            cardAccount.SuspendLayout();
            SuspendLayout();
            // 
            // cardAccount
            // 
            cardAccount.BackColor = Color.Transparent;
            cardAccount.Controls.Add(lblFormTitle);
            cardAccount.Controls.Add(lblServer);
            cardAccount.Controls.Add(txtServer);
            cardAccount.Controls.Add(lblPort);
            cardAccount.Controls.Add(txtPort);
            cardAccount.Controls.Add(lblMailId);
            cardAccount.Controls.Add(txtMailId);
            cardAccount.Controls.Add(lblPassword);
            cardAccount.Controls.Add(txtPassword);
            cardAccount.Controls.Add(lblSender);
            cardAccount.Controls.Add(txtSender);
            cardAccount.Controls.Add(btnSave);
            cardAccount.Location = new Point(0, 0);
            cardAccount.Name = "cardAccount";
            cardAccount.Size = new Size(560, 500);
            cardAccount.TabIndex = 0;
            // 
            // lblFormTitle
            // 
            lblFormTitle.AutoSize = true;
            lblFormTitle.BackColor = Color.Transparent;
            lblFormTitle.Font = new Font("맑은 고딕", 12F, FontStyle.Bold);
            lblFormTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblFormTitle.Location = new Point(18, 16);
            lblFormTitle.Name = "lblFormTitle";
            lblFormTitle.Size = new Size(80, 21);
            lblFormTitle.TabIndex = 0;
            lblFormTitle.Text = "메일 계정";
            // 
            // lblServer
            // 
            lblServer.AutoSize = true;
            lblServer.BackColor = Color.Transparent;
            lblServer.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
            lblServer.ForeColor = Color.Black;
            lblServer.Location = new Point(18, 56);
            lblServer.Name = "lblServer";
            lblServer.Size = new Size(59, 15);
            lblServer.TabIndex = 1;
            lblServer.Text = "메일 서버";
            // 
            // txtServer
            // 
            txtServer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtServer.Font = new Font("맑은 고딕", 10F);
            txtServer.Location = new Point(18, 78);
            txtServer.Name = "txtServer";
            txtServer.Size = new Size(524, 38);
            txtServer.TabIndex = 2;
            // 
            // lblPort
            // 
            lblPort.AutoSize = true;
            lblPort.BackColor = Color.Transparent;
            lblPort.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
            lblPort.ForeColor = Color.Black;
            lblPort.Location = new Point(18, 128);
            lblPort.Name = "lblPort";
            lblPort.Size = new Size(68, 15);
            lblPort.TabIndex = 3;
            lblPort.Text = "SMTP 포트";
            // 
            // txtPort
            // 
            txtPort.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPort.Font = new Font("맑은 고딕", 10F);
            txtPort.Location = new Point(18, 150);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(524, 38);
            txtPort.TabIndex = 4;
            // 
            // lblMailId
            // 
            lblMailId.AutoSize = true;
            lblMailId.BackColor = Color.Transparent;
            lblMailId.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
            lblMailId.ForeColor = Color.Black;
            lblMailId.Location = new Point(18, 200);
            lblMailId.Name = "lblMailId";
            lblMailId.Size = new Size(59, 15);
            lblMailId.TabIndex = 5;
            lblMailId.Text = "메일 주소";
            // 
            // txtMailId
            // 
            txtMailId.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMailId.Font = new Font("맑은 고딕", 10F);
            txtMailId.Location = new Point(18, 222);
            txtMailId.Name = "txtMailId";
            txtMailId.Size = new Size(524, 38);
            txtMailId.TabIndex = 6;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.BackColor = Color.Transparent;
            lblPassword.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
            lblPassword.ForeColor = Color.Black;
            lblPassword.Location = new Point(18, 272);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(55, 15);
            lblPassword.TabIndex = 7;
            lblPassword.Text = "비밀번호";
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPassword.Font = new Font("맑은 고딕", 10F);
            txtPassword.Location = new Point(18, 294);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(524, 38);
            txtPassword.TabIndex = 8;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // lblSender
            // 
            lblSender.AutoSize = true;
            lblSender.BackColor = Color.Transparent;
            lblSender.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
            lblSender.ForeColor = Color.Black;
            lblSender.Location = new Point(18, 344);
            lblSender.Name = "lblSender";
            lblSender.Size = new Size(59, 15);
            lblSender.TabIndex = 9;
            lblSender.Text = "보낸 사람";
            // 
            // txtSender
            // 
            txtSender.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSender.Font = new Font("맑은 고딕", 10F);
            txtSender.Location = new Point(18, 366);
            txtSender.Name = "txtSender";
            txtSender.Size = new Size(524, 38);
            txtSender.TabIndex = 10;
            // 
            // btnSave
            // 
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("맑은 고딕", 10F, FontStyle.Bold);
            btnSave.Kind = ButtonKind.Success;
            btnSave.Location = new Point(18, 440);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(110, 42);
            btnSave.TabIndex = 11;
            btnSave.Text = "저장";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // AccountControl
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 246, 248);
            Controls.Add(cardAccount);
            Font = new Font("맑은 고딕", 10F);
            Name = "AccountControl";
            Size = new Size(1004, 590);
            cardAccount.ResumeLayout(false);
            cardAccount.PerformLayout();
            ResumeLayout(false);
        }
        #endregion
        private UiCard cardAccount;
        private Label lblFormTitle;
        private Label lblServer;
        private UiTextBox txtServer;
        private Label lblPort;
        private UiTextBox txtPort;
        private Label lblMailId;
        private UiTextBox txtMailId;
        private Label lblPassword;
        private UiTextBox txtPassword;
        private Label lblSender;
        private UiTextBox txtSender;
        private UiButton btnSave;
    }
}
