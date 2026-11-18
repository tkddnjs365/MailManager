namespace MailSender.Controls
{
    /// <summary>
    /// 테두리 없이 깔끔한 모던 스타일의 표(DataGridView).
    /// 생성될 때 색상/행 높이/헤더 모양을 한 번에 적용한다.
    /// </summary>
    public class UiGrid : DataGridView
    {
        /// <summary>
        /// 표를 만들고 모던 스타일(연한 가로선, 큰 행 높이, 선택 행 파란 배경)을 적용한다.
        /// </summary>
        public UiGrid()
        {
            DoubleBuffered = true;
            BorderStyle = BorderStyle.None;
            BackgroundColor = Ui.Surface;
            GridColor = Ui.Border;
            CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            EnableHeadersVisualStyles = false;
            RowHeadersVisible = false;
            AllowUserToAddRows = false;
            AllowUserToDeleteRows = false;
            AllowUserToResizeRows = false;
            MultiSelect = false;
            SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            ColumnHeadersHeight = 36;
            RowTemplate.Height = 38;

            ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Ui.Surface,
                ForeColor = Ui.Muted,
                Font = new Font("맑은 고딕", 9F, FontStyle.Bold),
                SelectionBackColor = Ui.Surface,
                SelectionForeColor = Ui.Muted,
                Padding = new Padding(8, 0, 0, 0),
            };

            DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Ui.Surface,
                ForeColor = Ui.Text,
                Font = new Font("맑은 고딕", 9.5F),
                SelectionBackColor = Ui.PrimarySoft,
                SelectionForeColor = Ui.Text,
                Padding = new Padding(8, 0, 0, 0),
            };
        }
    }
}
