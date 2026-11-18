using MailSender.Controls;
#nullable disable
namespace MailSender.Forms
{
    partial class InputBoxForm
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
            lblMessage = new Label();
            txtValue = new UiTextBox();
            btnCancel = new UiButton();
            btnOk = new UiButton();
            SuspendLayout();
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = false;
            lblMessage.BackColor = Color.Transparent;
            lblMessage.ForeColor = Color.FromArgb(17, 24, 39);
            lblMessage.Font = new Font("맑은 고딕", 10F, FontStyle.Bold);
            lblMessage.Location = new Point(24, 22);
            lblMessage.Text = "";
            lblMessage.Size = new Size(352, 40);
            lblMessage.TabIndex = 0;
            lblMessage.Name = "lblMessage";
            // 
            // txtValue
            // 
            txtValue.Location = new Point(24, 66);
            txtValue.Size = new Size(352, 40);
            txtValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtValue.TabIndex = 1;
            txtValue.Name = "txtValue";
            // 
            // btnCancel
            // 
            btnCancel.Kind = ButtonKind.Secondary;
            btnCancel.Text = "취소";
            btnCancel.Size = new Size(100, 40);
            btnCancel.Location = new Point(160, 126);
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
            btnOk.Location = new Point(268, 126);
            btnOk.UseVisualStyleBackColor = false;
            btnOk.TabIndex = 3;
            btnOk.Name = "btnOk";
            btnOk.Click += btnOk_Click;
            // 
            // InputBoxForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 255, 255);
            ClientSize = new Size(400, 186);
            Font = new Font("맑은 고딕", 10F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "입력";
            ControlBox = false;
            Controls.Add(lblMessage);
            Controls.Add(txtValue);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Name = "InputBoxForm";
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion
        private Label lblMessage;
        private UiTextBox txtValue;
        private UiButton btnCancel;
        private UiButton btnOk;
    }
}
