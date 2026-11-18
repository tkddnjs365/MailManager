using MailSender.Controls;
#nullable disable
namespace MailSender.Views
{
    partial class InvoiceView
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            tlpBody = new TableLayoutPanel();
            cardList = new UiCard();
            txtSearch = new UiTextBox();
            gridInvoices = new UiGrid();
            colInvDate = new DataGridViewTextBoxColumn();
            colInvBuyer = new DataGridViewTextBoxColumn();
            colInvCount = new DataGridViewTextBoxColumn();
            colInvAmt = new DataGridViewTextBoxColumn();
            cardEdit = new UiCard();
            btnReset = new UiButton();
            lblEditTitle = new Label();
            lblBadge = new Label();
            lblDate = new Label();
            pnlDatePicker = new Panel();
            txtSupplyDate = new TextBox();
            btnSupplyDateCalendar = new Button();
            monthCalendarSupply = new MonthCalendar();
            lblBuyer = new Label();
            txtBuyer = new UiTextBox();
            lblSupplier = new Label();
            pnlSupplierBorder = new Panel();
            cboSupplier = new ComboBox();
            btnSupplierMng = new UiButton();
            lblSupplierInfo = new Label();
            lblItems = new Label();
            gridItems = new UiGrid();
            colItemDate = new DataGridViewTextBoxColumn();
            colItemName = new DataGridViewTextBoxColumn();
            colItemSpec = new DataGridViewTextBoxColumn();
            colItemAmt = new DataGridViewTextBoxColumn();
            colItemTax = new DataGridViewTextBoxColumn();
            gridDatePicker = new DateTimePicker();
            gridDateClearButton = new Button();
            btnAddRow = new UiButton();
            btnRemoveRow = new UiButton();
            pnlSum1 = new UiCard();
            pnlSum1Cap = new Label();
            pnlSum1Val = new Label();
            pnlSum2 = new UiCard();
            pnlSum2Cap = new Label();
            pnlSum2Val = new Label();
            pnlSum3 = new UiCard();
            pnlSum3Cap = new Label();
            pnlSum3Val = new Label();
            btnSave = new UiButton();
            btnPdf = new UiButton();
            btnDelete = new UiButton();
            lblPdfInfo = new Label();
            pnlHeader = new Panel();
            lblTitle = new Label();
            lblSub = new Label();
            btnNew = new UiButton();
            tlpBody.SuspendLayout();
            cardList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridInvoices).BeginInit();
            cardEdit.SuspendLayout();
            pnlDatePicker.SuspendLayout();
            pnlSupplierBorder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridItems).BeginInit();
            gridItems.SuspendLayout();
            pnlSum1.SuspendLayout();
            pnlSum2.SuspendLayout();
            pnlSum3.SuspendLayout();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // tlpBody
            // 
            tlpBody.BackColor = Color.FromArgb(245, 246, 248);
            tlpBody.ColumnCount = 2;
            tlpBody.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 320F));
            tlpBody.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpBody.Controls.Add(cardList, 0, 0);
            tlpBody.Controls.Add(cardEdit, 1, 0);
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
            cardList.Controls.Add(txtSearch);
            cardList.Controls.Add(gridInvoices);
            cardList.Dock = DockStyle.Fill;
            cardList.Location = new Point(28, 0);
            cardList.Margin = new Padding(0, 0, 8, 0);
            cardList.Name = "cardList";
            cardList.Size = new Size(312, 676);
            cardList.TabIndex = 0;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.Font = new Font("맑은 고딕", 10F);
            txtSearch.Location = new Point(14, 14);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "공급받는자 검색";
            txtSearch.Size = new Size(284, 38);
            txtSearch.TabIndex = 0;
            // 
            // gridInvoices
            // 
            gridInvoices.AllowUserToAddRows = false;
            gridInvoices.AllowUserToDeleteRows = false;
            gridInvoices.AllowUserToResizeRows = false;
            gridInvoices.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gridInvoices.BackgroundColor = Color.White;
            gridInvoices.BorderStyle = BorderStyle.None;
            gridInvoices.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gridInvoices.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(243, 244, 246);
            dataGridViewCellStyle1.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(55, 65, 81);
            dataGridViewCellStyle1.Padding = new Padding(8, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(243, 244, 246);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(55, 65, 81);
            gridInvoices.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            gridInvoices.ColumnHeadersHeight = 36;
            gridInvoices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            gridInvoices.Columns.AddRange(new DataGridViewColumn[] { colInvDate, colInvBuyer, colInvCount, colInvAmt });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("맑은 고딕", 9.5F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(17, 24, 39);
            dataGridViewCellStyle2.Padding = new Padding(8, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(238, 242, 255);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(17, 24, 39);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            gridInvoices.DefaultCellStyle = dataGridViewCellStyle2;
            gridInvoices.EnableHeadersVisualStyles = false;
            gridInvoices.GridColor = Color.FromArgb(229, 231, 235);
            gridInvoices.Location = new Point(8, 62);
            gridInvoices.MultiSelect = false;
            gridInvoices.Name = "gridInvoices";
            gridInvoices.RowHeadersVisible = false;
            gridInvoices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridInvoices.Size = new Size(296, 606);
            gridInvoices.TabIndex = 1;
            gridInvoices.CellClick += gridInvoices_CellClick;
            // 
            // colInvDate
            // 
            colInvDate.HeaderText = "공급일자";
            colInvDate.Name = "colInvDate";
            colInvDate.ReadOnly = true;
            colInvDate.SortMode = DataGridViewColumnSortMode.NotSortable;
            colInvDate.Width = 92;
            // 
            // colInvBuyer
            // 
            colInvBuyer.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colInvBuyer.HeaderText = "공급받는자";
            colInvBuyer.Name = "colInvBuyer";
            colInvBuyer.ReadOnly = true;
            colInvBuyer.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // colInvCount
            // 
            colInvCount.HeaderText = "건수";
            colInvCount.Name = "colInvCount";
            colInvCount.ReadOnly = true;
            colInvCount.SortMode = DataGridViewColumnSortMode.NotSortable;
            colInvCount.Width = 52;
            // 
            // colInvAmt
            // 
            colInvAmt.HeaderText = "전체금액";
            colInvAmt.Name = "colInvAmt";
            colInvAmt.ReadOnly = true;
            colInvAmt.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // cardEdit
            // 
            cardEdit.BackColor = Color.Transparent;
            cardEdit.Controls.Add(btnReset);
            cardEdit.Controls.Add(lblEditTitle);
            cardEdit.Controls.Add(lblBadge);
            cardEdit.Controls.Add(lblDate);
            cardEdit.Controls.Add(pnlDatePicker);
            cardEdit.Controls.Add(monthCalendarSupply);
            cardEdit.Controls.Add(lblBuyer);
            cardEdit.Controls.Add(txtBuyer);
            cardEdit.Controls.Add(lblSupplier);
            cardEdit.Controls.Add(pnlSupplierBorder);
            cardEdit.Controls.Add(btnSupplierMng);
            cardEdit.Controls.Add(lblSupplierInfo);
            cardEdit.Controls.Add(lblItems);
            cardEdit.Controls.Add(gridItems);
            cardEdit.Controls.Add(btnAddRow);
            cardEdit.Controls.Add(btnRemoveRow);
            cardEdit.Controls.Add(pnlSum1);
            cardEdit.Controls.Add(pnlSum2);
            cardEdit.Controls.Add(pnlSum3);
            cardEdit.Controls.Add(btnSave);
            cardEdit.Controls.Add(btnPdf);
            cardEdit.Controls.Add(btnDelete);
            cardEdit.Controls.Add(lblPdfInfo);
            cardEdit.Dock = DockStyle.Fill;
            cardEdit.Location = new Point(356, 0);
            cardEdit.Margin = new Padding(8, 0, 0, 0);
            cardEdit.Name = "cardEdit";
            cardEdit.Size = new Size(676, 676);
            cardEdit.TabIndex = 1;
            // 
            // btnReset
            // 
            btnReset.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.Font = new Font("맑은 고딕", 10F, FontStyle.Bold);
            btnReset.Kind = ButtonKind.Primary;
            btnReset.Location = new Point(152, 15);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(66, 26);
            btnReset.TabIndex = 21;
            btnReset.Text = "초기화";
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Click += btnNew_Click;
            // 
            // lblEditTitle
            // 
            lblEditTitle.AutoSize = true;
            lblEditTitle.BackColor = Color.Transparent;
            lblEditTitle.Font = new Font("맑은 고딕", 12F, FontStyle.Bold);
            lblEditTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblEditTitle.Location = new Point(18, 16);
            lblEditTitle.Name = "lblEditTitle";
            lblEditTitle.Size = new Size(80, 21);
            lblEditTitle.TabIndex = 0;
            lblEditTitle.Text = "새 명세서";
            // 
            // lblBadge
            // 
            lblBadge.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblBadge.BackColor = Color.FromArgb(254, 243, 199);
            lblBadge.Font = new Font("맑은 고딕", 8.5F, FontStyle.Bold);
            lblBadge.ForeColor = Color.FromArgb(180, 83, 9);
            lblBadge.Location = new Point(566, 16);
            lblBadge.Name = "lblBadge";
            lblBadge.Size = new Size(92, 24);
            lblBadge.TabIndex = 1;
            lblBadge.Text = "저장 전";
            lblBadge.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.BackColor = Color.Transparent;
            lblDate.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
            lblDate.ForeColor = Color.Black;
            lblDate.Location = new Point(18, 56);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(55, 15);
            lblDate.TabIndex = 2;
            lblDate.Text = "공급일자";
            // 
            // pnlDatePicker
            // 
            pnlDatePicker.BackColor = Color.White;
            pnlDatePicker.Controls.Add(txtSupplyDate);
            pnlDatePicker.Controls.Add(btnSupplyDateCalendar);
            pnlDatePicker.Location = new Point(18, 78);
            pnlDatePicker.Name = "pnlDatePicker";
            pnlDatePicker.Padding = new Padding(1);
            pnlDatePicker.Size = new Size(172, 38);
            pnlDatePicker.TabIndex = 3;
            pnlDatePicker.Paint += pnlDatePicker_Paint;
            // 
            // txtSupplyDate
            // 
            txtSupplyDate.BackColor = Color.White;
            txtSupplyDate.BorderStyle = BorderStyle.None;
            txtSupplyDate.Dock = DockStyle.Fill;
            txtSupplyDate.Font = new Font("맑은 고딕", 10F);
            txtSupplyDate.Location = new Point(1, 1);
            txtSupplyDate.Name = "txtSupplyDate";
            txtSupplyDate.ReadOnly = true;
            txtSupplyDate.Size = new Size(136, 18);
            txtSupplyDate.TabIndex = 3;
            txtSupplyDate.TextAlign = HorizontalAlignment.Center;
            // 
            // btnSupplyDateCalendar
            // 
            btnSupplyDateCalendar.Dock = DockStyle.Right;
            btnSupplyDateCalendar.FlatAppearance.BorderSize = 0;
            btnSupplyDateCalendar.FlatStyle = FlatStyle.Flat;
            btnSupplyDateCalendar.Font = new Font("맑은 고딕", 9F);
            btnSupplyDateCalendar.Location = new Point(137, 1);
            btnSupplyDateCalendar.Name = "btnSupplyDateCalendar";
            btnSupplyDateCalendar.Size = new Size(34, 36);
            btnSupplyDateCalendar.TabIndex = 4;
            btnSupplyDateCalendar.Text = "▼";
            btnSupplyDateCalendar.UseVisualStyleBackColor = false;
            btnSupplyDateCalendar.Click += btnSupplyDateCalendar_Click;
            // 
            // monthCalendarSupply
            // 
            monthCalendarSupply.Font = new Font("맑은 고딕", 10F);
            monthCalendarSupply.Location = new Point(18, 118);
            monthCalendarSupply.MaxSelectionCount = 1;
            monthCalendarSupply.Name = "monthCalendarSupply";
            monthCalendarSupply.TabIndex = 22;
            monthCalendarSupply.Visible = false;
            monthCalendarSupply.DateSelected += monthCalendarSupply_DateSelected;
            // 
            // lblBuyer
            // 
            lblBuyer.AutoSize = true;
            lblBuyer.BackColor = Color.Transparent;
            lblBuyer.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
            lblBuyer.ForeColor = Color.Black;
            lblBuyer.Location = new Point(200, 56);
            lblBuyer.Name = "lblBuyer";
            lblBuyer.Size = new Size(103, 15);
            lblBuyer.TabIndex = 4;
            lblBuyer.Text = "공급받는자 (귀하)";
            // 
            // txtBuyer
            // 
            txtBuyer.Font = new Font("맑은 고딕", 10F);
            txtBuyer.Location = new Point(200, 78);
            txtBuyer.Name = "txtBuyer";
            txtBuyer.PlaceholderText = "거래처명";
            txtBuyer.Size = new Size(230, 38);
            txtBuyer.TabIndex = 5;
            // 
            // lblSupplier
            // 
            lblSupplier.AutoSize = true;
            lblSupplier.BackColor = Color.Transparent;
            lblSupplier.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
            lblSupplier.ForeColor = Color.Black;
            lblSupplier.Location = new Point(448, 56);
            lblSupplier.Name = "lblSupplier";
            lblSupplier.Size = new Size(43, 15);
            lblSupplier.TabIndex = 6;
            lblSupplier.Text = "공급자";
            // 
            // pnlSupplierBorder
            // 
            pnlSupplierBorder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlSupplierBorder.BackColor = Color.White;
            pnlSupplierBorder.Controls.Add(cboSupplier);
            pnlSupplierBorder.Location = new Point(432, 78);
            pnlSupplierBorder.Name = "pnlSupplierBorder";
            pnlSupplierBorder.Padding = new Padding(1);
            pnlSupplierBorder.Size = new Size(154, 40);
            pnlSupplierBorder.TabIndex = 7;
            pnlSupplierBorder.Paint += pnlSupplierBorder_Paint;
            // 
            // cboSupplier
            // 
            cboSupplier.BackColor = Color.White;
            cboSupplier.DisplayMember = "Name";
            cboSupplier.Dock = DockStyle.Fill;
            cboSupplier.DrawMode = DrawMode.OwnerDrawFixed;
            cboSupplier.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSupplier.FlatStyle = FlatStyle.Flat;
            cboSupplier.Font = new Font("맑은 고딕", 10F);
            cboSupplier.FormattingEnabled = true;
            cboSupplier.ItemHeight = 30;
            cboSupplier.Location = new Point(1, 1);
            cboSupplier.Name = "cboSupplier";
            cboSupplier.Size = new Size(152, 36);
            cboSupplier.TabIndex = 7;
            cboSupplier.DrawItem += cboSupplier_DrawItem;
            cboSupplier.SelectedIndexChanged += cboSupplier_SelectedIndexChanged;
            // 
            // btnSupplierMng
            // 
            btnSupplierMng.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSupplierMng.FlatStyle = FlatStyle.Flat;
            btnSupplierMng.Font = new Font("맑은 고딕", 10F, FontStyle.Bold);
            btnSupplierMng.Location = new Point(592, 78);
            btnSupplierMng.Name = "btnSupplierMng";
            btnSupplierMng.Size = new Size(66, 38);
            btnSupplierMng.TabIndex = 8;
            btnSupplierMng.Text = "관리";
            btnSupplierMng.UseVisualStyleBackColor = false;
            btnSupplierMng.Click += btnSupplierMng_Click;
            // 
            // lblSupplierInfo
            // 
            lblSupplierInfo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblSupplierInfo.BackColor = Color.Transparent;
            lblSupplierInfo.Font = new Font("맑은 고딕", 8.5F);
            lblSupplierInfo.ForeColor = Color.FromArgb(107, 114, 128);
            lblSupplierInfo.Location = new Point(432, 122);
            lblSupplierInfo.Name = "lblSupplierInfo";
            lblSupplierInfo.Size = new Size(226, 119);
            lblSupplierInfo.TabIndex = 9;
            // 
            // lblItems
            // 
            lblItems.AutoSize = true;
            lblItems.BackColor = Color.Transparent;
            lblItems.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
            lblItems.ForeColor = Color.Black;
            lblItems.Location = new Point(19, 226);
            lblItems.Name = "lblItems";
            lblItems.Size = new Size(31, 15);
            lblItems.TabIndex = 10;
            lblItems.Text = "품목";
            // 
            // gridItems
            // 
            gridItems.AllowUserToAddRows = false;
            gridItems.AllowUserToDeleteRows = false;
            gridItems.AllowUserToResizeRows = false;
            gridItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gridItems.BackgroundColor = Color.White;
            gridItems.BorderStyle = BorderStyle.None;
            gridItems.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gridItems.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(243, 244, 246);
            dataGridViewCellStyle3.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(55, 65, 81);
            dataGridViewCellStyle3.Padding = new Padding(8, 0, 0, 0);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(243, 244, 246);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(55, 65, 81);
            gridItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            gridItems.ColumnHeadersHeight = 36;
            gridItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            gridItems.Columns.AddRange(new DataGridViewColumn[] { colItemDate, colItemName, colItemSpec, colItemAmt, colItemTax });
            gridItems.Controls.Add(gridDatePicker);
            gridItems.Controls.Add(gridDateClearButton);
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("맑은 고딕", 9.5F);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(17, 24, 39);
            dataGridViewCellStyle4.Padding = new Padding(8, 0, 0, 0);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(238, 242, 255);
            dataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(17, 24, 39);
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            gridItems.DefaultCellStyle = dataGridViewCellStyle4;
            gridItems.EditMode = DataGridViewEditMode.EditOnEnter;
            gridItems.EnableHeadersVisualStyles = false;
            gridItems.GridColor = Color.FromArgb(229, 231, 235);
            gridItems.Location = new Point(18, 244);
            gridItems.MultiSelect = false;
            gridItems.Name = "gridItems";
            gridItems.RowHeadersVisible = false;
            gridItems.RowTemplate.Height = 38;
            gridItems.SelectionMode = DataGridViewSelectionMode.CellSelect;
            gridItems.Size = new Size(655, 250);
            gridItems.TabIndex = 11;
            gridItems.CellClick += gridItems_CellClick;
            gridItems.CellEnter += gridItems_CellEnter;
            gridItems.CellFormatting += gridItems_CellFormatting;
            gridItems.CellValueChanged += gridItems_CellValueChanged;
            gridItems.CurrentCellDirtyStateChanged += gridItems_CurrentCellDirtyStateChanged;
            gridItems.Scroll += gridItems_Scroll;
            // 
            // colItemDate
            // 
            colItemDate.HeaderText = "일자";
            colItemDate.Name = "colItemDate";
            colItemDate.ReadOnly = true;
            colItemDate.SortMode = DataGridViewColumnSortMode.NotSortable;
            colItemDate.Width = 112;
            // 
            // colItemName
            // 
            colItemName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colItemName.HeaderText = "품목";
            colItemName.Name = "colItemName";
            colItemName.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // colItemSpec
            // 
            colItemSpec.HeaderText = "규격";
            colItemSpec.Name = "colItemSpec";
            colItemSpec.SortMode = DataGridViewColumnSortMode.NotSortable;
            colItemSpec.Width = 90;
            // 
            // colItemAmt
            // 
            colItemAmt.HeaderText = "공급가액";
            colItemAmt.Name = "colItemAmt";
            colItemAmt.SortMode = DataGridViewColumnSortMode.NotSortable;
            colItemAmt.Width = 120;
            // 
            // colItemTax
            // 
            colItemTax.HeaderText = "세액 (10%)";
            colItemTax.Name = "colItemTax";
            colItemTax.ReadOnly = true;
            colItemTax.SortMode = DataGridViewColumnSortMode.NotSortable;
            colItemTax.Width = 104;
            // 
            // gridDatePicker
            // 
            gridDatePicker.CalendarFont = new Font("맑은 고딕", 10F);
            gridDatePicker.CustomFormat = "yyyy-MM-dd";
            gridDatePicker.Font = new Font("맑은 고딕", 10F);
            gridDatePicker.Format = DateTimePickerFormat.Custom;
            gridDatePicker.Location = new Point(0, 0);
            gridDatePicker.Name = "gridDatePicker";
            gridDatePicker.Size = new Size(100, 25);
            gridDatePicker.TabIndex = 0;
            gridDatePicker.Visible = false;
            gridDatePicker.CloseUp += gridDatePicker_CloseUp;
            gridDatePicker.ValueChanged += gridDatePicker_ValueChanged;
            gridDatePicker.KeyPress += gridDatePicker_KeyPress;
            // 
            // gridDateClearButton
            // 
            gridDateClearButton.BackColor = Color.WhiteSmoke;
            gridDateClearButton.Cursor = Cursors.Hand;
            gridDateClearButton.FlatStyle = FlatStyle.Flat;
            gridDateClearButton.Font = new Font("맑은 고딕", 11F, FontStyle.Bold);
            gridDateClearButton.ForeColor = Color.Black;
            gridDateClearButton.Location = new Point(0, 0);
            gridDateClearButton.Name = "gridDateClearButton";
            gridDateClearButton.Size = new Size(25, 25);
            gridDateClearButton.TabIndex = 1;
            gridDateClearButton.Text = "×";
            gridDateClearButton.UseVisualStyleBackColor = false;
            gridDateClearButton.Visible = false;
            gridDateClearButton.Click += gridDateClearButton_Click;
            // 
            // btnAddRow
            // 
            btnAddRow.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAddRow.FlatStyle = FlatStyle.Flat;
            btnAddRow.Font = new Font("맑은 고딕", 10F, FontStyle.Bold);
            btnAddRow.Location = new Point(18, 500);
            btnAddRow.Name = "btnAddRow";
            btnAddRow.Size = new Size(120, 32);
            btnAddRow.TabIndex = 12;
            btnAddRow.Text = "＋ 품목 추가";
            btnAddRow.UseVisualStyleBackColor = false;
            btnAddRow.Click += btnAddRow_Click;
            // 
            // btnRemoveRow
            // 
            btnRemoveRow.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnRemoveRow.FlatStyle = FlatStyle.Flat;
            btnRemoveRow.Font = new Font("맑은 고딕", 10F, FontStyle.Bold);
            btnRemoveRow.Kind = ButtonKind.Danger;
            btnRemoveRow.Location = new Point(146, 500);
            btnRemoveRow.Name = "btnRemoveRow";
            btnRemoveRow.Size = new Size(120, 32);
            btnRemoveRow.TabIndex = 13;
            btnRemoveRow.Text = "선택 행 삭제";
            btnRemoveRow.UseVisualStyleBackColor = false;
            btnRemoveRow.Click += btnRemoveRow_Click;
            // 
            // pnlSum1
            // 
            pnlSum1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            pnlSum1.BackColor = Color.Transparent;
            pnlSum1.BorderColor = Color.Transparent;
            pnlSum1.Controls.Add(pnlSum1Cap);
            pnlSum1.Controls.Add(pnlSum1Val);
            pnlSum1.FillColor = Color.FromArgb(249, 250, 251);
            pnlSum1.Location = new Point(18, 540);
            pnlSum1.Name = "pnlSum1";
            pnlSum1.Size = new Size(200, 64);
            pnlSum1.TabIndex = 14;
            // 
            // pnlSum1Cap
            // 
            pnlSum1Cap.AutoSize = true;
            pnlSum1Cap.BackColor = Color.Transparent;
            pnlSum1Cap.Font = new Font("맑은 고딕", 8.5F);
            pnlSum1Cap.ForeColor = Color.FromArgb(107, 114, 128);
            pnlSum1Cap.Location = new Point(14, 8);
            pnlSum1Cap.Name = "pnlSum1Cap";
            pnlSum1Cap.Size = new Size(55, 15);
            pnlSum1Cap.TabIndex = 0;
            pnlSum1Cap.Text = "공급가액";
            // 
            // pnlSum1Val
            // 
            pnlSum1Val.AutoSize = true;
            pnlSum1Val.BackColor = Color.Transparent;
            pnlSum1Val.Font = new Font("맑은 고딕", 13F, FontStyle.Bold);
            pnlSum1Val.ForeColor = Color.FromArgb(17, 24, 39);
            pnlSum1Val.Location = new Point(14, 28);
            pnlSum1Val.Name = "pnlSum1Val";
            pnlSum1Val.Size = new Size(22, 25);
            pnlSum1Val.TabIndex = 1;
            pnlSum1Val.Text = "0";
            // 
            // pnlSum2
            // 
            pnlSum2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            pnlSum2.BackColor = Color.Transparent;
            pnlSum2.BorderColor = Color.Transparent;
            pnlSum2.Controls.Add(pnlSum2Cap);
            pnlSum2.Controls.Add(pnlSum2Val);
            pnlSum2.FillColor = Color.FromArgb(249, 250, 251);
            pnlSum2.Location = new Point(226, 540);
            pnlSum2.Name = "pnlSum2";
            pnlSum2.Size = new Size(200, 64);
            pnlSum2.TabIndex = 15;
            // 
            // pnlSum2Cap
            // 
            pnlSum2Cap.AutoSize = true;
            pnlSum2Cap.BackColor = Color.Transparent;
            pnlSum2Cap.Font = new Font("맑은 고딕", 8.5F);
            pnlSum2Cap.ForeColor = Color.FromArgb(107, 114, 128);
            pnlSum2Cap.Location = new Point(14, 8);
            pnlSum2Cap.Name = "pnlSum2Cap";
            pnlSum2Cap.Size = new Size(67, 15);
            pnlSum2Cap.TabIndex = 0;
            pnlSum2Cap.Text = "세액 (10%)";
            // 
            // pnlSum2Val
            // 
            pnlSum2Val.AutoSize = true;
            pnlSum2Val.BackColor = Color.Transparent;
            pnlSum2Val.Font = new Font("맑은 고딕", 13F, FontStyle.Bold);
            pnlSum2Val.ForeColor = Color.FromArgb(17, 24, 39);
            pnlSum2Val.Location = new Point(14, 28);
            pnlSum2Val.Name = "pnlSum2Val";
            pnlSum2Val.Size = new Size(22, 25);
            pnlSum2Val.TabIndex = 1;
            pnlSum2Val.Text = "0";
            // 
            // pnlSum3
            // 
            pnlSum3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            pnlSum3.BackColor = Color.Transparent;
            pnlSum3.BorderColor = Color.Transparent;
            pnlSum3.Controls.Add(pnlSum3Cap);
            pnlSum3.Controls.Add(pnlSum3Val);
            pnlSum3.FillColor = Color.FromArgb(238, 242, 255);
            pnlSum3.Location = new Point(434, 540);
            pnlSum3.Name = "pnlSum3";
            pnlSum3.Size = new Size(238, 64);
            pnlSum3.TabIndex = 16;
            // 
            // pnlSum3Cap
            // 
            pnlSum3Cap.AutoSize = true;
            pnlSum3Cap.BackColor = Color.Transparent;
            pnlSum3Cap.Font = new Font("맑은 고딕", 8.5F);
            pnlSum3Cap.ForeColor = Color.FromArgb(59, 91, 219);
            pnlSum3Cap.Location = new Point(14, 8);
            pnlSum3Cap.Name = "pnlSum3Cap";
            pnlSum3Cap.Size = new Size(55, 15);
            pnlSum3Cap.TabIndex = 0;
            pnlSum3Cap.Text = "합계금액";
            // 
            // pnlSum3Val
            // 
            pnlSum3Val.AutoSize = true;
            pnlSum3Val.BackColor = Color.Transparent;
            pnlSum3Val.Font = new Font("맑은 고딕", 13F, FontStyle.Bold);
            pnlSum3Val.ForeColor = Color.FromArgb(59, 91, 219);
            pnlSum3Val.Location = new Point(14, 28);
            pnlSum3Val.Name = "pnlSum3Val";
            pnlSum3Val.Size = new Size(22, 25);
            pnlSum3Val.TabIndex = 1;
            pnlSum3Val.Text = "0";
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("맑은 고딕", 10F, FontStyle.Bold);
            btnSave.Kind = ButtonKind.Success;
            btnSave.Location = new Point(18, 620);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(110, 42);
            btnSave.TabIndex = 17;
            btnSave.Text = "저장";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnPdf
            // 
            btnPdf.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnPdf.FlatStyle = FlatStyle.Flat;
            btnPdf.Font = new Font("맑은 고딕", 10F, FontStyle.Bold);
            btnPdf.Kind = ButtonKind.Primary;
            btnPdf.Location = new Point(136, 620);
            btnPdf.Name = "btnPdf";
            btnPdf.Size = new Size(130, 42);
            btnPdf.TabIndex = 18;
            btnPdf.Text = "PDF로 저장";
            btnPdf.UseVisualStyleBackColor = false;
            btnPdf.Click += btnPdf_Click;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("맑은 고딕", 10F, FontStyle.Bold);
            btnDelete.Kind = ButtonKind.Danger;
            btnDelete.Location = new Point(274, 620);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(90, 42);
            btnDelete.TabIndex = 19;
            btnDelete.Text = "삭제";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // lblPdfInfo
            // 
            lblPdfInfo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblPdfInfo.BackColor = Color.Transparent;
            lblPdfInfo.Font = new Font("맑은 고딕", 8F);
            lblPdfInfo.ForeColor = Color.FromArgb(107, 114, 128);
            lblPdfInfo.Location = new Point(376, 630);
            lblPdfInfo.Name = "lblPdfInfo";
            lblPdfInfo.Size = new Size(296, 32);
            lblPdfInfo.TabIndex = 20;
            lblPdfInfo.Text = "PDF로 저장하면 DB에 저장한 뒤 새 PDF를 만들어요. 이전 PDF는 유지돼요.";
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(245, 246, 248);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblSub);
            pnlHeader.Controls.Add(btnNew);
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
            lblTitle.Size = new Size(152, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "거래명세서";
            // 
            // lblSub
            // 
            lblSub.AutoSize = true;
            lblSub.BackColor = Color.Transparent;
            lblSub.Font = new Font("맑은 고딕", 10F);
            lblSub.ForeColor = Color.FromArgb(107, 114, 128);
            lblSub.Location = new Point(30, 54);
            lblSub.Name = "lblSub";
            lblSub.Size = new Size(331, 19);
            lblSub.TabIndex = 1;
            lblSub.Text = "저장한 명세서를 불러와 수정하거나 새로 작성해요.";
            // 
            // btnNew
            // 
            btnNew.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNew.FlatStyle = FlatStyle.Flat;
            btnNew.Font = new Font("맑은 고딕", 10F, FontStyle.Bold);
            btnNew.Kind = ButtonKind.Primary;
            btnNew.Location = new Point(1862, 24);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(130, 40);
            btnNew.TabIndex = 2;
            btnNew.Text = "＋ 새 명세서";
            btnNew.UseVisualStyleBackColor = false;
            btnNew.Click += btnNew_Click;
            // 
            // InvoiceView
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 246, 248);
            Controls.Add(tlpBody);
            Controls.Add(pnlHeader);
            Font = new Font("맑은 고딕", 10F);
            Name = "InvoiceView";
            Size = new Size(1060, 780);
            tlpBody.ResumeLayout(false);
            cardList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridInvoices).EndInit();
            cardEdit.ResumeLayout(false);
            cardEdit.PerformLayout();
            pnlDatePicker.ResumeLayout(false);
            pnlDatePicker.PerformLayout();
            pnlSupplierBorder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridItems).EndInit();
            gridItems.ResumeLayout(false);
            pnlSum1.ResumeLayout(false);
            pnlSum1.PerformLayout();
            pnlSum2.ResumeLayout(false);
            pnlSum2.PerformLayout();
            pnlSum3.ResumeLayout(false);
            pnlSum3.PerformLayout();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
        }
        #endregion
        private TableLayoutPanel tlpBody;
        private UiCard cardList;
        private UiTextBox txtSearch;
        private UiGrid gridInvoices;
        private UiCard cardEdit;
        private Label lblEditTitle;
        private Label lblBadge;
        private Label lblDate;
        private Panel pnlDatePicker;
        private TextBox txtSupplyDate;
        private Button btnSupplyDateCalendar;
        private MonthCalendar monthCalendarSupply;
        private Label lblBuyer;
        private UiTextBox txtBuyer;
        private Label lblSupplier;
        private ComboBox cboSupplier;
        private Panel pnlSupplierBorder;
        private UiButton btnSupplierMng;
        private Label lblSupplierInfo;
        private Label lblItems;
        private UiGrid gridItems;
        private DateTimePicker gridDatePicker;
        private Button gridDateClearButton;
        private UiButton btnAddRow;
        private UiButton btnRemoveRow;
        private UiCard pnlSum1;
        private Label pnlSum1Cap;
        private Label pnlSum1Val;
        private UiCard pnlSum2;
        private Label pnlSum2Cap;
        private Label pnlSum2Val;
        private UiCard pnlSum3;
        private Label pnlSum3Cap;
        private Label pnlSum3Val;
        private UiButton btnSave;
        private UiButton btnPdf;
        private UiButton btnDelete;
        private Label lblPdfInfo;
        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblSub;
        private UiButton btnNew;
        private DataGridViewTextBoxColumn colInvDate;
        private DataGridViewTextBoxColumn colInvBuyer;
        private DataGridViewTextBoxColumn colInvCount;
        private DataGridViewTextBoxColumn colInvAmt;
        private DataGridViewTextBoxColumn colItemDate;
        private DataGridViewTextBoxColumn colItemName;
        private DataGridViewTextBoxColumn colItemSpec;
        private DataGridViewTextBoxColumn colItemAmt;
        private DataGridViewTextBoxColumn colItemTax;
        private UiButton btnReset;
    }
}
