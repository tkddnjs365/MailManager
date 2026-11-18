using MailSender.Controls;
#nullable disable
namespace MailSender.Views
{
    partial class ManageView
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
            pnlHost = new Panel();
            templateControl = new TemplateManageControl();
            categoryControl = new CategoryManageControl();
            supplierControl = new SupplierManageControl();
            accountControl = new AccountControl();
            pnlTabs = new Panel();
            btnTabTpl = new UiButton();
            btnTabCat = new UiButton();
            btnTabSup = new UiButton();
            btnTabAcc = new UiButton();
            pnlHeader = new Panel();
            lblTitle = new Label();
            lblSub = new Label();
            pnlHost.SuspendLayout();
            pnlTabs.SuspendLayout();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHost
            // 
            pnlHost.Dock = DockStyle.Fill;
            pnlHost.BackColor = Color.FromArgb(245, 246, 248);
            pnlHost.Padding = new Padding(28, 0, 28, 16);
            pnlHost.TabIndex = 0;
            pnlHost.Name = "pnlHost";
            pnlHost.Controls.Add(templateControl);
            pnlHost.Controls.Add(categoryControl);
            pnlHost.Controls.Add(supplierControl);
            pnlHost.Controls.Add(accountControl);
            // 
            // templateControl
            // 
            templateControl.Dock = DockStyle.Fill;
            templateControl.TabIndex = 0;
            templateControl.Name = "templateControl";
            // 
            // categoryControl
            // 
            categoryControl.Dock = DockStyle.Fill;
            categoryControl.Visible = false;
            categoryControl.TabIndex = 1;
            categoryControl.Name = "categoryControl";
            // 
            // supplierControl
            // 
            supplierControl.Dock = DockStyle.Fill;
            supplierControl.Visible = false;
            supplierControl.TabIndex = 2;
            supplierControl.Name = "supplierControl";
            // 
            // accountControl
            // 
            accountControl.Dock = DockStyle.Fill;
            accountControl.Visible = false;
            accountControl.TabIndex = 3;
            accountControl.Name = "accountControl";
            // 
            // pnlTabs
            // 
            pnlTabs.Dock = DockStyle.Top;
            pnlTabs.BackColor = Color.FromArgb(245, 246, 248);
            pnlTabs.Size = new Size(100, 52);
            pnlTabs.TabIndex = 1;
            pnlTabs.Name = "pnlTabs";
            pnlTabs.Controls.Add(btnTabTpl);
            pnlTabs.Controls.Add(btnTabCat);
            pnlTabs.Controls.Add(btnTabSup);
            pnlTabs.Controls.Add(btnTabAcc);
            // 
            // btnTabTpl
            // 
            btnTabTpl.Kind = ButtonKind.Chip;
            btnTabTpl.Text = "메일 양식";
            btnTabTpl.Size = new Size(104, 36);
            btnTabTpl.Location = new Point(28, 6);
            btnTabTpl.UseVisualStyleBackColor = false;
            btnTabTpl.Checked = true;
            btnTabTpl.TabIndex = 0;
            btnTabTpl.Name = "btnTabTpl";
            btnTabTpl.Click += btnTab_Click;
            // 
            // btnTabCat
            // 
            btnTabCat.Kind = ButtonKind.Chip;
            btnTabCat.Text = "첨부파일";
            btnTabCat.Size = new Size(104, 36);
            btnTabCat.Location = new Point(140, 6);
            btnTabCat.UseVisualStyleBackColor = false;
            btnTabCat.TabIndex = 1;
            btnTabCat.Name = "btnTabCat";
            btnTabCat.Click += btnTab_Click;
            // 
            // btnTabSup
            // 
            btnTabSup.Kind = ButtonKind.Chip;
            btnTabSup.Text = "공급자";
            btnTabSup.Size = new Size(96, 36);
            btnTabSup.Location = new Point(252, 6);
            btnTabSup.UseVisualStyleBackColor = false;
            btnTabSup.TabIndex = 2;
            btnTabSup.Name = "btnTabSup";
            btnTabSup.Click += btnTab_Click;
            // 
            // btnTabAcc
            // 
            btnTabAcc.Kind = ButtonKind.Chip;
            btnTabAcc.Text = "메일 계정";
            btnTabAcc.Size = new Size(104, 36);
            btnTabAcc.Location = new Point(356, 6);
            btnTabAcc.UseVisualStyleBackColor = false;
            btnTabAcc.TabIndex = 3;
            btnTabAcc.Name = "btnTabAcc";
            btnTabAcc.Click += btnTab_Click;
            // 
            // pnlHeader
            // 
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.BackColor = Color.FromArgb(245, 246, 248);
            pnlHeader.Size = new Size(100, 88);
            pnlHeader.TabIndex = 2;
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblSub);
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblTitle.Font = new Font("맑은 고딕", 20F, FontStyle.Bold);
            lblTitle.Location = new Point(28, 16);
            lblTitle.Text = "관리";
            lblTitle.TabIndex = 0;
            lblTitle.Name = "lblTitle";
            // 
            // lblSub
            // 
            lblSub.AutoSize = true;
            lblSub.BackColor = Color.Transparent;
            lblSub.ForeColor = Color.FromArgb(107, 114, 128);
            lblSub.Font = new Font("맑은 고딕", 10F);
            lblSub.Location = new Point(30, 54);
            lblSub.Text = "양식, 첨부파일, 공급자, 메일 계정을 한 곳에서 관리해요. 모두 DB에 저장돼요.";
            lblSub.TabIndex = 1;
            lblSub.Name = "lblSub";
            // 
            // ManageView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 246, 248);
            Size = new Size(1060, 780);
            Font = new Font("맑은 고딕", 10F);
            Controls.Add(pnlHost);
            Controls.Add(pnlTabs);
            Controls.Add(pnlHeader);
            Name = "ManageView";
            pnlHost.ResumeLayout(false);
            pnlTabs.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion
        private Panel pnlHost;
        private TemplateManageControl templateControl;
        private CategoryManageControl categoryControl;
        private SupplierManageControl supplierControl;
        private AccountControl accountControl;
        private Panel pnlTabs;
        private UiButton btnTabTpl;
        private UiButton btnTabCat;
        private UiButton btnTabSup;
        private UiButton btnTabAcc;
        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblSub;
    }
}
