using MailSender.Controls;
#nullable disable
namespace MailSender.Forms
{
    partial class ConfirmForm
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
            lblTitle = new Label();
            lblMessage = new Label();
            btnCancel = new UiButton();
            btnOk = new UiButton();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblTitle.Font = new Font("맑은 고딕", 13F, FontStyle.Bold);
            lblTitle.Location = new Point(24, 22);
            lblTitle.Text = "확인";
            lblTitle.TabIndex = 0;
            lblTitle.Name = "lblTitle";
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = false;
            lblMessage.BackColor = Color.Transparent;
            lblMessage.ForeColor = Color.FromArgb(107, 114, 128);
            lblMessage.Font = new Font("맑은 고딕", 10F);
            lblMessage.Location = new Point(24, 60);
            lblMessage.Text = "";
            lblMessage.Size = new Size(352, 70);
            lblMessage.TextAlign = ContentAlignment.TopLeft;
            lblMessage.TabIndex = 1;
            lblMessage.Name = "lblMessage";
            // 
            // btnCancel
            // 
            btnCancel.Kind = ButtonKind.Secondary;
            btnCancel.Text = "취소";
            btnCancel.Size = new Size(100, 40);
            btnCancel.Location = new Point(160, 136);
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.TabIndex = 2;
            btnCancel.Name = "btnCancel";
            btnCancel.Click += btnCancel_Click;
            // 
            // btnOk
            // 
            btnOk.Kind = ButtonKind.Primary;
            btnOk.Text = "확인";
            btnOk.Size = new Size(108, 40);
            btnOk.Location = new Point(268, 136);
            btnOk.UseVisualStyleBackColor = false;
            btnOk.TabIndex = 3;
            btnOk.Name = "btnOk";
            btnOk.Click += btnOk_Click;
            // 
            // ConfirmForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 255, 255);
            ClientSize = new Size(400, 196);
            Font = new Font("맑은 고딕", 10F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "확인";
            ControlBox = false;
            Controls.Add(lblTitle);
            Controls.Add(lblMessage);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Name = "ConfirmForm";
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion
        private Label lblTitle;
        private Label lblMessage;
        private UiButton btnCancel;
        private UiButton btnOk;
    }
}
