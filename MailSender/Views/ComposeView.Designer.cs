using MailSender.Controls;
#nullable disable
namespace MailSender.Views
{
    partial class ComposeView
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
            tlpBody = new TableLayoutPanel();
            cardMail = new UiCard();
            lblTo = new Label();
            txtTo = new UiTextBox();
            lblTpl = new Label();
            flowTpl = new FlowLayoutPanel();
            lblSubject = new Label();
            txtSubject = new UiTextBox();
            lblBody = new Label();
            txtBody = new UiTextBox();
            cardAttach = new UiCard();
            lblAttach = new Label();
            flowCats = new FlowLayoutPanel();
            flowFiles = new FlowLayoutPanel();
            pnlBar = new Panel();
            lblSummary = new Label();
            btnSend = new UiButton();
            pnlHeader = new Panel();
            lblTitle = new Label();
            lblSub = new Label();
            tlpBody.SuspendLayout();
            cardMail.SuspendLayout();
            cardAttach.SuspendLayout();
            pnlBar.SuspendLayout();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // tlpBody
            // 
            tlpBody.BackColor = Color.FromArgb(245, 246, 248);
            tlpBody.ColumnCount = 2;
            tlpBody.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 56F));
            tlpBody.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 44F));
            tlpBody.Controls.Add(cardMail, 0, 0);
            tlpBody.Controls.Add(cardAttach, 1, 0);
            tlpBody.Dock = DockStyle.Fill;
            tlpBody.Location = new Point(0, 88);
            tlpBody.Name = "tlpBody";
            tlpBody.Padding = new Padding(28, 0, 28, 16);
            tlpBody.RowCount = 1;
            tlpBody.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpBody.Size = new Size(1060, 628);
            tlpBody.TabIndex = 0;
            // 
            // cardMail
            // 
            cardMail.BackColor = Color.Transparent;
            cardMail.Controls.Add(lblTo);
            cardMail.Controls.Add(txtTo);
            cardMail.Controls.Add(lblTpl);
            cardMail.Controls.Add(flowTpl);
            cardMail.Controls.Add(lblSubject);
            cardMail.Controls.Add(txtSubject);
            cardMail.Controls.Add(lblBody);
            cardMail.Controls.Add(txtBody);
            cardMail.Dock = DockStyle.Fill;
            cardMail.Location = new Point(28, 0);
            cardMail.Margin = new Padding(0, 0, 8, 0);
            cardMail.Name = "cardMail";
            cardMail.Size = new Size(554, 612);
            cardMail.TabIndex = 0;
            // 
            // lblTo
            // 
            lblTo.AutoSize = true;
            lblTo.BackColor = Color.Transparent;
            lblTo.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
            lblTo.ForeColor = Color.Black;
            lblTo.Location = new Point(18, 16);
            lblTo.Name = "lblTo";
            lblTo.Size = new Size(59, 15);
            lblTo.TabIndex = 0;
            lblTo.Text = "받는 사람";
            // 
            // txtTo
            // 
            txtTo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTo.Font = new Font("맑은 고딕", 10F);
            txtTo.Location = new Point(18, 38);
            txtTo.Name = "txtTo";
            txtTo.PlaceholderText = "name@example.com";
            txtTo.Size = new Size(518, 38);
            txtTo.TabIndex = 1;
            // 
            // lblTpl
            // 
            lblTpl.AutoSize = true;
            lblTpl.BackColor = Color.Transparent;
            lblTpl.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
            lblTpl.ForeColor = Color.Black;
            lblTpl.Location = new Point(18, 90);
            lblTpl.Name = "lblTpl";
            lblTpl.Size = new Size(111, 15);
            lblTpl.TabIndex = 2;
            lblTpl.Text = "메일 양식 불러오기";
            // 
            // flowTpl
            // 
            flowTpl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flowTpl.BackColor = Color.Transparent;
            flowTpl.Location = new Point(18, 112);
            flowTpl.Name = "flowTpl";
            flowTpl.Size = new Size(518, 44);
            flowTpl.TabIndex = 3;
            // 
            // lblSubject
            // 
            lblSubject.AutoSize = true;
            lblSubject.BackColor = Color.Transparent;
            lblSubject.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
            lblSubject.ForeColor = Color.Black;
            lblSubject.Location = new Point(18, 166);
            lblSubject.Name = "lblSubject";
            lblSubject.Size = new Size(31, 15);
            lblSubject.TabIndex = 4;
            lblSubject.Text = "제목";
            // 
            // txtSubject
            // 
            txtSubject.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSubject.Font = new Font("맑은 고딕", 10F);
            txtSubject.Location = new Point(18, 188);
            txtSubject.Name = "txtSubject";
            txtSubject.PlaceholderText = "메일 제목";
            txtSubject.Size = new Size(518, 38);
            txtSubject.TabIndex = 5;
            // 
            // lblBody
            // 
            lblBody.AutoSize = true;
            lblBody.BackColor = Color.Transparent;
            lblBody.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
            lblBody.ForeColor = Color.Black;
            lblBody.Location = new Point(18, 240);
            lblBody.Name = "lblBody";
            lblBody.Size = new Size(31, 15);
            lblBody.TabIndex = 6;
            lblBody.Text = "내용";
            // 
            // txtBody
            // 
            txtBody.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtBody.Font = new Font("맑은 고딕", 10F);
            txtBody.Location = new Point(18, 262);
            txtBody.Multiline = true;
            txtBody.Name = "txtBody";
            txtBody.PlaceholderText = "내용을 입력하세요";
            txtBody.Size = new Size(518, 347);
            txtBody.TabIndex = 7;
            // 
            // cardAttach
            // 
            cardAttach.BackColor = Color.Transparent;
            cardAttach.Controls.Add(lblAttach);
            cardAttach.Controls.Add(flowCats);
            cardAttach.Controls.Add(flowFiles);
            cardAttach.Dock = DockStyle.Fill;
            cardAttach.Location = new Point(598, 0);
            cardAttach.Margin = new Padding(8, 0, 0, 0);
            cardAttach.Name = "cardAttach";
            cardAttach.Size = new Size(434, 612);
            cardAttach.TabIndex = 1;
            // 
            // lblAttach
            // 
            lblAttach.AutoSize = true;
            lblAttach.BackColor = Color.Transparent;
            lblAttach.Font = new Font("맑은 고딕", 11F, FontStyle.Bold);
            lblAttach.ForeColor = Color.FromArgb(17, 24, 39);
            lblAttach.Location = new Point(18, 16);
            lblAttach.Name = "lblAttach";
            lblAttach.Size = new Size(69, 20);
            lblAttach.TabIndex = 0;
            lblAttach.Text = "첨부파일";
            // 
            // flowCats
            // 
            flowCats.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flowCats.AutoScroll = true;
            flowCats.BackColor = Color.Transparent;
            flowCats.Location = new Point(18, 50);
            flowCats.Name = "flowCats";
            flowCats.Size = new Size(398, 76);
            flowCats.TabIndex = 1;
            // 
            // flowFiles
            // 
            flowFiles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowFiles.AutoScroll = true;
            flowFiles.BackColor = Color.Transparent;
            flowFiles.Location = new Point(18, 134);
            flowFiles.Name = "flowFiles";
            flowFiles.Size = new Size(398, 475);
            flowFiles.TabIndex = 2;
            // 
            // pnlBar
            // 
            pnlBar.BackColor = Color.FromArgb(255, 255, 255);
            pnlBar.Controls.Add(lblSummary);
            pnlBar.Controls.Add(btnSend);
            pnlBar.Dock = DockStyle.Bottom;
            pnlBar.Location = new Point(0, 716);
            pnlBar.Name = "pnlBar";
            pnlBar.Padding = new Padding(28, 12, 28, 12);
            pnlBar.Size = new Size(1060, 64);
            pnlBar.TabIndex = 1;
            // 
            // lblSummary
            // 
            lblSummary.BackColor = Color.Transparent;
            lblSummary.Dock = DockStyle.Fill;
            lblSummary.Font = new Font("맑은 고딕", 10F, FontStyle.Bold);
            lblSummary.ForeColor = Color.FromArgb(17, 24, 39);
            lblSummary.Location = new Point(28, 12);
            lblSummary.Name = "lblSummary";
            lblSummary.Size = new Size(864, 40);
            lblSummary.TabIndex = 0;
            lblSummary.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnSend
            // 
            btnSend.Dock = DockStyle.Right;
            btnSend.FlatStyle = FlatStyle.Flat;
            btnSend.Font = new Font("맑은 고딕", 10F, FontStyle.Bold);
            btnSend.Kind = ButtonKind.Primary;
            btnSend.Location = new Point(892, 12);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(140, 40);
            btnSend.TabIndex = 1;
            btnSend.Text = "메일 전송";
            btnSend.UseVisualStyleBackColor = false;
            btnSend.Click += btnSend_Click;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(245, 246, 248);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblSub);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1060, 88);
            pnlHeader.TabIndex = 2;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("맑은 고딕", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblTitle.Location = new Point(28, 16);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(134, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "메일 작성";
            // 
            // lblSub
            // 
            lblSub.AutoSize = true;
            lblSub.BackColor = Color.Transparent;
            lblSub.Font = new Font("맑은 고딕", 10F);
            lblSub.ForeColor = Color.FromArgb(107, 114, 128);
            lblSub.Location = new Point(30, 54);
            lblSub.Name = "lblSub";
            lblSub.Size = new Size(435, 19);
            lblSub.TabIndex = 1;
            lblSub.Text = "받는 사람을 입력하고 첨부파일 구분을 고르면 바로 보낼 수 있어요.";
            // 
            // ComposeView
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 246, 248);
            Controls.Add(tlpBody);
            Controls.Add(pnlBar);
            Controls.Add(pnlHeader);
            Font = new Font("맑은 고딕", 10F);
            Name = "ComposeView";
            Size = new Size(1060, 780);
            tlpBody.ResumeLayout(false);
            cardMail.ResumeLayout(false);
            cardMail.PerformLayout();
            cardAttach.ResumeLayout(false);
            cardAttach.PerformLayout();
            pnlBar.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
        }
        #endregion
        private TableLayoutPanel tlpBody;
        private UiCard cardMail;
        private Label lblTo;
        private UiTextBox txtTo;
        private Label lblTpl;
        private FlowLayoutPanel flowTpl;
        private Label lblSubject;
        private UiTextBox txtSubject;
        private Label lblBody;
        private UiTextBox txtBody;
        private UiCard cardAttach;
        private Label lblAttach;
        private FlowLayoutPanel flowCats;
        private FlowLayoutPanel flowFiles;
        private Panel pnlBar;
        private Label lblSummary;
        private UiButton btnSend;
        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblSub;
    }
}
