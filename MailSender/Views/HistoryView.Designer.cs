using MailSender.Controls;
#nullable disable
namespace MailSender.Views
{
    partial class HistoryView
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            tlpBody = new TableLayoutPanel();
            cardList = new UiCard();
            gridHistory = new UiGrid();
            colHSent = new DataGridViewTextBoxColumn();
            colHTo = new DataGridViewTextBoxColumn();
            colHSub = new DataGridViewTextBoxColumn();
            colHStatus = new DataGridViewTextBoxColumn();
            cardDetail = new UiCard();
            lblDetSubject = new Label();
            lblDetMeta = new Label();
            lblBodyCap = new Label();
            txtDetBody = new UiTextBox();
            lblAttCap = new Label();
            lstAttach = new UiListBox();
            pnlHeader = new Panel();
            lblTitle = new Label();
            lblSub = new Label();
            tlpBody.SuspendLayout();
            cardList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridHistory).BeginInit();
            cardDetail.SuspendLayout();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // tlpBody
            // 
            tlpBody.BackColor = Color.FromArgb(245, 246, 248);
            tlpBody.ColumnCount = 2;
            tlpBody.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 58F));
            tlpBody.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 42F));
            tlpBody.Controls.Add(cardList, 0, 0);
            tlpBody.Controls.Add(cardDetail, 1, 0);
            tlpBody.Dock = DockStyle.Fill;
            tlpBody.Location = new Point(0, 88);
            tlpBody.Name = "tlpBody";
            tlpBody.Padding = new Padding(28, 0, 28, 16);
            tlpBody.RowCount = 1;
            tlpBody.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpBody.Size = new Size(1060, 692);
            tlpBody.TabIndex = 0;
            // 
            // cardList
            // 
            cardList.BackColor = Color.Transparent;
            cardList.Controls.Add(gridHistory);
            cardList.Dock = DockStyle.Fill;
            cardList.Location = new Point(28, 0);
            cardList.Margin = new Padding(0, 0, 8, 0);
            cardList.Name = "cardList";
            cardList.Padding = new Padding(10);
            cardList.Size = new Size(574, 676);
            cardList.TabIndex = 0;
            // 
            // gridHistory
            // 
            gridHistory.AllowUserToAddRows = false;
            gridHistory.AllowUserToDeleteRows = false;
            gridHistory.AllowUserToResizeRows = false;
            gridHistory.BackgroundColor = Color.White;
            gridHistory.BorderStyle = BorderStyle.None;
            gridHistory.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gridHistory.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(107, 114, 128);
            dataGridViewCellStyle1.Padding = new Padding(8, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = Color.White;
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(107, 114, 128);
            gridHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            gridHistory.ColumnHeadersHeight = 36;
            gridHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            gridHistory.Columns.AddRange(new DataGridViewColumn[] { colHSent, colHTo, colHSub, colHStatus });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("맑은 고딕", 9.5F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(17, 24, 39);
            dataGridViewCellStyle2.Padding = new Padding(8, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(238, 242, 255);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(17, 24, 39);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            gridHistory.DefaultCellStyle = dataGridViewCellStyle2;
            gridHistory.Dock = DockStyle.Fill;
            gridHistory.EnableHeadersVisualStyles = false;
            gridHistory.GridColor = Color.Black;
            gridHistory.Location = new Point(10, 10);
            gridHistory.MultiSelect = false;
            gridHistory.Name = "gridHistory";
            gridHistory.RowHeadersVisible = false;
            gridHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridHistory.Size = new Size(554, 656);
            gridHistory.TabIndex = 0;
            gridHistory.SelectionChanged += gridHistory_SelectionChanged;
            // 
            // colHSent
            // 
            colHSent.HeaderText = "일시";
            colHSent.Name = "colHSent";
            colHSent.ReadOnly = true;
            colHSent.SortMode = DataGridViewColumnSortMode.NotSortable;
            colHSent.Width = 150;
            // 
            // colHTo
            // 
            colHTo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colHTo.FillWeight = 60F;
            colHTo.HeaderText = "받는 사람";
            colHTo.Name = "colHTo";
            colHTo.ReadOnly = true;
            colHTo.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // colHSub
            // 
            colHSub.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colHSub.HeaderText = "제목";
            colHSub.Name = "colHSub";
            colHSub.ReadOnly = true;
            colHSub.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // colHStatus
            // 
            colHStatus.HeaderText = "결과";
            colHStatus.Name = "colHStatus";
            colHStatus.ReadOnly = true;
            colHStatus.SortMode = DataGridViewColumnSortMode.NotSortable;
            colHStatus.Width = 70;
            // 
            // cardDetail
            // 
            cardDetail.BackColor = Color.Transparent;
            cardDetail.Controls.Add(lblDetSubject);
            cardDetail.Controls.Add(lblDetMeta);
            cardDetail.Controls.Add(lblBodyCap);
            cardDetail.Controls.Add(txtDetBody);
            cardDetail.Controls.Add(lblAttCap);
            cardDetail.Controls.Add(lstAttach);
            cardDetail.Dock = DockStyle.Fill;
            cardDetail.Location = new Point(618, 0);
            cardDetail.Margin = new Padding(8, 0, 0, 0);
            cardDetail.Name = "cardDetail";
            cardDetail.Size = new Size(414, 676);
            cardDetail.TabIndex = 1;
            // 
            // lblDetSubject
            // 
            lblDetSubject.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblDetSubject.BackColor = Color.Transparent;
            lblDetSubject.Font = new Font("맑은 고딕", 12F, FontStyle.Bold);
            lblDetSubject.ForeColor = Color.FromArgb(17, 24, 39);
            lblDetSubject.Location = new Point(18, 16);
            lblDetSubject.Name = "lblDetSubject";
            lblDetSubject.Size = new Size(378, 26);
            lblDetSubject.TabIndex = 0;
            lblDetSubject.Text = "이력을 선택하세요";
            // 
            // lblDetMeta
            // 
            lblDetMeta.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblDetMeta.BackColor = Color.Transparent;
            lblDetMeta.Font = new Font("맑은 고딕", 9F);
            lblDetMeta.ForeColor = Color.FromArgb(107, 114, 128);
            lblDetMeta.Location = new Point(18, 46);
            lblDetMeta.Name = "lblDetMeta";
            lblDetMeta.Size = new Size(378, 36);
            lblDetMeta.TabIndex = 1;
            // 
            // lblBodyCap
            // 
            lblBodyCap.AutoSize = true;
            lblBodyCap.BackColor = Color.Transparent;
            lblBodyCap.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
            lblBodyCap.ForeColor = Color.Black;
            lblBodyCap.Location = new Point(18, 88);
            lblBodyCap.Name = "lblBodyCap";
            lblBodyCap.Size = new Size(31, 15);
            lblBodyCap.TabIndex = 2;
            lblBodyCap.Text = "내용";
            // 
            // txtDetBody
            // 
            txtDetBody.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtDetBody.Font = new Font("맑은 고딕", 10F);
            txtDetBody.Location = new Point(18, 110);
            txtDetBody.Multiline = true;
            txtDetBody.Name = "txtDetBody";
            txtDetBody.ReadOnly = true;
            txtDetBody.Size = new Size(378, 170);
            txtDetBody.TabIndex = 3;
            // 
            // lblAttCap
            // 
            lblAttCap.AutoSize = true;
            lblAttCap.BackColor = Color.Transparent;
            lblAttCap.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
            lblAttCap.ForeColor = Color.Black;
            lblAttCap.Location = new Point(18, 292);
            lblAttCap.Name = "lblAttCap";
            lblAttCap.Size = new Size(164, 15);
            lblAttCap.TabIndex = 4;
            lblAttCap.Text = "첨부파일 (파일명 / 원본경로)";
            // 
            // lstAttach
            // 
            lstAttach.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstAttach.BackColor = Color.White;
            lstAttach.BorderStyle = BorderStyle.None;
            lstAttach.DrawMode = DrawMode.OwnerDrawFixed;
            lstAttach.IntegralHeight = false;
            lstAttach.ItemHeight = 40;
            lstAttach.Location = new Point(18, 316);
            lstAttach.Name = "lstAttach";
            lstAttach.Size = new Size(378, 592);
            lstAttach.TabIndex = 5;
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
            pnlHeader.TabIndex = 1;
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
            lblTitle.Text = "전송 이력";
            // 
            // lblSub
            // 
            lblSub.AutoSize = true;
            lblSub.BackColor = Color.Transparent;
            lblSub.Font = new Font("맑은 고딕", 10F);
            lblSub.ForeColor = Color.FromArgb(107, 114, 128);
            lblSub.Location = new Point(30, 54);
            lblSub.Name = "lblSub";
            lblSub.Size = new Size(401, 19);
            lblSub.TabIndex = 1;
            lblSub.Text = "보낸 메일의 받는 사람, 제목, 내용, 첨부파일이 DB에 기록돼요.";
            // 
            // HistoryView
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 246, 248);
            Controls.Add(tlpBody);
            Controls.Add(pnlHeader);
            Font = new Font("맑은 고딕", 10F);
            Name = "HistoryView";
            Size = new Size(1060, 780);
            tlpBody.ResumeLayout(false);
            cardList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridHistory).EndInit();
            cardDetail.ResumeLayout(false);
            cardDetail.PerformLayout();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
        }
        #endregion
        private TableLayoutPanel tlpBody;
        private UiCard cardList;
        private UiGrid gridHistory;
        private UiCard cardDetail;
        private Label lblDetSubject;
        private Label lblDetMeta;
        private Label lblBodyCap;
        private UiTextBox txtDetBody;
        private Label lblAttCap;
        private UiListBox lstAttach;
        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblSub;
        private DataGridViewTextBoxColumn colHSent;
        private DataGridViewTextBoxColumn colHTo;
        private DataGridViewTextBoxColumn colHSub;
        private DataGridViewTextBoxColumn colHStatus;
    }
}
