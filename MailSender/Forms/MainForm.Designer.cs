using MailSender.Controls;
using MailSender.Views;
#nullable disable
namespace MailSender.Forms
{
    partial class MainForm
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
            pnlContent = new Panel();
            composeView = new ComposeView();
            invoiceView = new InvoiceView();
            historyView = new HistoryView();
            manageView = new ManageView();
            pnlNav = new Panel();
            lblVer = new Label();
            btnNavManage = new UiButton();
            btnNavHistory = new UiButton();
            btnNavInvoice = new UiButton();
            btnNavCompose = new UiButton();
            pnlBrandGap = new Panel();
            lblBrand = new Label();
            pnlNavLine = new Panel();
            pnlContent.SuspendLayout();
            pnlNav.SuspendLayout();
            SuspendLayout();
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.FromArgb(245, 246, 248);
            pnlContent.Controls.Add(composeView);
            pnlContent.Controls.Add(invoiceView);
            pnlContent.Controls.Add(historyView);
            pnlContent.Controls.Add(manageView);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(220, 0);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(1060, 780);
            pnlContent.TabIndex = 0;
            // 
            // composeView
            // 
            composeView.BackColor = Color.FromArgb(245, 246, 248);
            composeView.Dock = DockStyle.Fill;
            composeView.Font = new Font("맑은 고딕", 10F);
            composeView.Location = new Point(0, 0);
            composeView.Name = "composeView";
            composeView.Size = new Size(1060, 780);
            composeView.TabIndex = 0;
            // 
            // invoiceView
            // 
            invoiceView.BackColor = Color.FromArgb(245, 246, 248);
            invoiceView.Dock = DockStyle.Fill;
            invoiceView.Font = new Font("맑은 고딕", 10F);
            invoiceView.Location = new Point(0, 0);
            invoiceView.Name = "invoiceView";
            invoiceView.Size = new Size(1060, 780);
            invoiceView.TabIndex = 1;
            invoiceView.Visible = false;
            // 
            // historyView
            // 
            historyView.BackColor = Color.FromArgb(245, 246, 248);
            historyView.Dock = DockStyle.Fill;
            historyView.Font = new Font("맑은 고딕", 10F);
            historyView.Location = new Point(0, 0);
            historyView.Name = "historyView";
            historyView.Size = new Size(1060, 780);
            historyView.TabIndex = 2;
            historyView.Visible = false;
            // 
            // manageView
            // 
            manageView.BackColor = Color.FromArgb(245, 246, 248);
            manageView.Dock = DockStyle.Fill;
            manageView.Font = new Font("맑은 고딕", 10F);
            manageView.Location = new Point(0, 0);
            manageView.Name = "manageView";
            manageView.Size = new Size(1060, 780);
            manageView.TabIndex = 3;
            manageView.Visible = false;
            // 
            // pnlNav
            // 
            pnlNav.BackColor = Color.FromArgb(255, 255, 255);
            pnlNav.Controls.Add(lblVer);
            pnlNav.Controls.Add(btnNavManage);
            pnlNav.Controls.Add(btnNavHistory);
            pnlNav.Controls.Add(btnNavInvoice);
            pnlNav.Controls.Add(btnNavCompose);
            pnlNav.Controls.Add(pnlBrandGap);
            pnlNav.Controls.Add(lblBrand);
            pnlNav.Controls.Add(pnlNavLine);
            pnlNav.Dock = DockStyle.Left;
            pnlNav.Location = new Point(0, 0);
            pnlNav.Name = "pnlNav";
            pnlNav.Padding = new Padding(14, 10, 0, 10);
            pnlNav.Size = new Size(220, 780);
            pnlNav.TabIndex = 1;
            // 
            // lblVer
            // 
            lblVer.BackColor = Color.Transparent;
            lblVer.Dock = DockStyle.Bottom;
            lblVer.Font = new Font("맑은 고딕", 8F);
            lblVer.ForeColor = Color.FromArgb(107, 114, 128);
            lblVer.Location = new Point(14, 742);
            lblVer.Name = "lblVer";
            lblVer.Size = new Size(205, 28);
            lblVer.TabIndex = 0;
            lblVer.Text = "SQLite · mailSender.db";
            lblVer.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnNavManage
            // 
            btnNavManage.Dock = DockStyle.Top;
            btnNavManage.FlatStyle = FlatStyle.Flat;
            btnNavManage.Font = new Font("맑은 고딕", 10F, FontStyle.Bold);
            btnNavManage.Kind = ButtonKind.Nav;
            btnNavManage.Location = new Point(14, 210);
            btnNavManage.Name = "btnNavManage";
            btnNavManage.Padding = new Padding(0, 20, 0, 20);
            btnNavManage.Size = new Size(205, 44);
            btnNavManage.TabIndex = 1;
            btnNavManage.Text = "⚙  관리";
            btnNavManage.UseVisualStyleBackColor = false;
            btnNavManage.Click += btnNav_Click;
            // 
            // btnNavHistory
            // 
            btnNavHistory.Dock = DockStyle.Top;
            btnNavHistory.FlatStyle = FlatStyle.Flat;
            btnNavHistory.Font = new Font("맑은 고딕", 10F, FontStyle.Bold);
            btnNavHistory.Kind = ButtonKind.Nav;
            btnNavHistory.Location = new Point(14, 166);
            btnNavHistory.Name = "btnNavHistory";
            btnNavHistory.Padding = new Padding(0, 20, 0, 20);
            btnNavHistory.Size = new Size(205, 44);
            btnNavHistory.TabIndex = 2;
            btnNavHistory.Text = "◷  전송 이력";
            btnNavHistory.UseVisualStyleBackColor = false;
            btnNavHistory.Click += btnNav_Click;
            // 
            // btnNavInvoice
            // 
            btnNavInvoice.Dock = DockStyle.Top;
            btnNavInvoice.FlatStyle = FlatStyle.Flat;
            btnNavInvoice.Font = new Font("맑은 고딕", 10F, FontStyle.Bold);
            btnNavInvoice.Kind = ButtonKind.Nav;
            btnNavInvoice.Location = new Point(14, 122);
            btnNavInvoice.Name = "btnNavInvoice";
            btnNavInvoice.Padding = new Padding(0, 20, 0, 20);
            btnNavInvoice.Size = new Size(205, 44);
            btnNavInvoice.TabIndex = 3;
            btnNavInvoice.Text = "▤  거래명세서";
            btnNavInvoice.UseVisualStyleBackColor = false;
            btnNavInvoice.Click += btnNav_Click;
            // 
            // btnNavCompose
            // 
            btnNavCompose.Checked = true;
            btnNavCompose.Dock = DockStyle.Top;
            btnNavCompose.FlatStyle = FlatStyle.Flat;
            btnNavCompose.Font = new Font("맑은 고딕", 10F, FontStyle.Bold);
            btnNavCompose.Kind = ButtonKind.Nav;
            btnNavCompose.Location = new Point(14, 78);
            btnNavCompose.Name = "btnNavCompose";
            btnNavCompose.Padding = new Padding(0, 20, 0, 20);
            btnNavCompose.Size = new Size(205, 44);
            btnNavCompose.TabIndex = 4;
            btnNavCompose.Text = "✉  메일 작성";
            btnNavCompose.UseVisualStyleBackColor = false;
            btnNavCompose.Click += btnNav_Click;
            // 
            // pnlBrandGap
            // 
            pnlBrandGap.BackColor = Color.FromArgb(255, 255, 255);
            pnlBrandGap.Dock = DockStyle.Top;
            pnlBrandGap.Location = new Point(14, 66);
            pnlBrandGap.Name = "pnlBrandGap";
            pnlBrandGap.Size = new Size(205, 12);
            pnlBrandGap.TabIndex = 5;
            // 
            // lblBrand
            // 
            lblBrand.BackColor = Color.Transparent;
            lblBrand.Dock = DockStyle.Top;
            lblBrand.Font = new Font("맑은 고딕", 14F, FontStyle.Bold);
            lblBrand.ForeColor = Color.FromArgb(59, 91, 219);
            lblBrand.Location = new Point(14, 10);
            lblBrand.Name = "lblBrand";
            lblBrand.Size = new Size(205, 56);
            lblBrand.TabIndex = 6;
            lblBrand.Text = "메일 발송";
            lblBrand.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlNavLine
            // 
            pnlNavLine.BackColor = Color.FromArgb(229, 231, 235);
            pnlNavLine.Dock = DockStyle.Right;
            pnlNavLine.Location = new Point(219, 10);
            pnlNavLine.Name = "pnlNavLine";
            pnlNavLine.Size = new Size(1, 760);
            pnlNavLine.TabIndex = 7;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 246, 248);
            ClientSize = new Size(1280, 780);
            Controls.Add(pnlContent);
            Controls.Add(pnlNav);
            Font = new Font("맑은 고딕", 10F);
            MinimumSize = new Size(1120, 720);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "메일 발송";
            pnlContent.ResumeLayout(false);
            pnlNav.ResumeLayout(false);
            ResumeLayout(false);
        }
        #endregion
        private Panel pnlContent;
        private ComposeView composeView;
        private InvoiceView invoiceView;
        private HistoryView historyView;
        private ManageView manageView;
        private Panel pnlNav;
        private Label lblVer;
        private UiButton btnNavManage;
        private UiButton btnNavHistory;
        private UiButton btnNavInvoice;
        private UiButton btnNavCompose;
        private Panel pnlBrandGap;
        private Label lblBrand;
        private Panel pnlNavLine;
    }
}
