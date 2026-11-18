namespace MailSender.Forms
{
    /// <summary>
    /// 삭제/전송 같은 동작을 하기 전에 한 번 더 물어보는 깔끔한 확인 창.
    /// 메시지박스 대신 사용하며, 취소 버튼 없이 안내만 보여주는 용도로도 쓴다.
    /// </summary>
    public partial class ConfirmForm : Form
    {
        /// <summary>
        /// 확인 창을 만든다.
        /// </summary>
        /// <param name="title">굵게 표시할 제목</param>
        /// <param name="message">설명 글</param>
        /// <param name="okText">확인 버튼 글자</param>
        /// <param name="showCancel">취소 버튼 표시 여부 (false면 안내 창)</param>
        /// <param name="danger">true이면 확인 버튼을 빨간색(삭제)으로 표시</param>
        public ConfirmForm(string title, string message, string okText, bool showCancel, bool danger)
        {
            InitializeComponent();

            lblTitle.Text = title;
            lblMessage.Text = message;
            btnOk.Text = okText;
            btnCancel.Visible = showCancel;

            if (danger) btnOk.Kind = MailSender.Controls.ButtonKind.DangerSolid;
        }

        /// <summary>
        /// 확인 버튼 클릭 시 "확인"(OK) 결과로 창을 닫는다.
        /// </summary>
        private void btnOk_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// 취소 버튼 클릭 시 "취소" 결과로 창을 닫는다.
        /// </summary>
        private void btnCancel_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
