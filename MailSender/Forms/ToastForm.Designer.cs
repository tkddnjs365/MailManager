using MailSender.Controls;
#nullable disable
namespace MailSender.Forms
{
    partial class ToastForm
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
            lblText = new Label();
            timerClose = new System.Windows.Forms.Timer();
            SuspendLayout();
            // 
            // lblText
            // 
            lblText.AutoSize = false;
            lblText.BackColor = Color.Transparent;
            lblText.ForeColor = Color.White;
            lblText.Font = new Font("맑은 고딕", 10F, FontStyle.Bold);
            lblText.Location = new Point(0, 0);
            lblText.Text = "";
            lblText.Size = new Size(320, 44);
            lblText.TextAlign = ContentAlignment.MiddleCenter;
            lblText.Dock = DockStyle.Fill;
            lblText.TabIndex = 0;
            lblText.Name = "lblText";
            // 
            // timerClose
            // 
            timerClose.Interval = 2400;
            timerClose.Tick += timerClose_Tick;
            // 
            // ToastForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(17, 24, 39);
            ClientSize = new Size(340, 46);
            Font = new Font("맑은 고딕", 10F);
            FormBorderStyle = FormBorderStyle.None;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            TopMost = true;
            Controls.Add(lblText);
            Name = "ToastForm";
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion
        private Label lblText;
        private System.Windows.Forms.Timer timerClose;
    }
}
