namespace MailSender.Forms
{
    /// <summary>
    /// 글자 한 줄을 입력받는 작은 입력 창. (예: 새 구분 이름 입력)
    /// </summary>
    public partial class InputBoxForm : Form
    {
        /// <summary>사용자가 입력한 글자</summary>
        public string Value => txtValue.Text;

        /// <summary>
        /// 입력 창을 만든다.
        /// </summary>
        /// <param name="message">입력창 위에 보여줄 안내 문구</param>
        /// <param name="placeholder">입력 전에 흐리게 보일 예시 글자</param>
        public InputBoxForm(string message, string placeholder = "")
        {
            InitializeComponent();

            lblMessage.Text = message;
            txtValue.PlaceholderText = placeholder;
            AcceptButton = btnOk;
            CancelButton = btnCancel;
        }

        /// <summary>
        /// 창이 열리면 입력창에 바로 커서를 둔다.
        /// </summary>
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            txtValue.Inner.Focus();
        }

        /// <summary>
        /// 확인 버튼 클릭 시 "확인" 결과로 닫는다.
        /// </summary>
        private void btnOk_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// 취소 버튼 클릭 시 "취소" 결과로 닫는다.
        /// </summary>
        private void btnCancel_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
