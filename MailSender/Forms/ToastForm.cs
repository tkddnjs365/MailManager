using MailSender.Controls;

namespace MailSender.Forms
{
    /// <summary>
    /// 화면 오른쪽 위에 잠깐 떴다가 저절로 사라지는 알림(토스트) 창.
    /// 저장/전송 성공이나 입력 안내처럼 사용자를 방해하지 않아야 하는 메시지에 사용한다.
    /// </summary>
    public partial class ToastForm : Form
    {
        /// <summary>
        /// 알림 창을 만들고 글자와 색상을 정한다.
        /// </summary>
        private ToastForm(string text, bool error)
        {
            InitializeComponent();

            lblText.Text = text;
            if (error) BackColor = Ui.Danger;
        }

        /// <summary>창을 띄울 때 현재 사용 중인 창의 포커스를 빼앗지 않게 한다.</summary>
        protected override bool ShowWithoutActivation => true;

        /// <summary>
        /// 알림 창이 작업표시줄/Alt+Tab에 나타나지 않고, 클릭을 가로채지 않게 하는 창 속성.
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x08000000 | 0x00000080; // NOACTIVATE | TOOLWINDOW
                return cp;
            }
        }

        /// <summary>
        /// 창이 만들어지면 모서리를 둥글게 깎는다.
        /// </summary>
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            using var path = Ui.RoundRect(new Rectangle(0, 0, Width, Height), 12);
            Region = new Region(path);
        }

        /// <summary>
        /// 일정 시간이 지나면 알림 창을 닫는다.
        /// </summary>
        private void timerClose_Tick(object? sender, EventArgs e)
        {
            timerClose.Stop();
            Close();
        }

        /// <summary>
        /// 기준 창의 오른쪽 위에 알림을 보여준다.
        /// </summary>
        /// <param name="owner">알림을 띄울 기준 컨트롤 (속한 창의 오른쪽 위에 표시)</param>
        /// <param name="text">알림 내용</param>
        /// <param name="error">true이면 빨간색 오류 알림</param>
        public static void Show(Control owner, string text, bool error = false)
        {
            var host = owner.FindForm();
            if (host == null) return;

            var toast = new ToastForm(text, error);
            toast.Location = new Point(host.Right - toast.Width - 24, host.Top + 48);
            toast.Show(host);
            toast.timerClose.Start();
        }
    }

    /// <summary>
    /// 확인/안내 창을 간단히 띄우는 도우미.
    /// </summary>
    public static class Dialogs
    {
        /// <summary>
        /// "예/취소" 확인 창을 띄우고, 확인을 눌렀는지 반환한다.
        /// </summary>
        public static bool Confirm(IWin32Window owner, string title, string message, string okText = "확인", bool danger = false)
        {
            using var f = new ConfirmForm(title, message, okText, true, danger);
            return f.ShowDialog(owner) == DialogResult.OK;
        }

        /// <summary>
        /// 확인 버튼만 있는 안내 창을 띄운다. (오류 내용 안내 등)
        /// </summary>
        public static void Info(IWin32Window owner, string title, string message)
        {
            using var f = new ConfirmForm(title, message, "확인", false, false);
            f.ShowDialog(owner);
        }

        /// <summary>
        /// 글자 한 줄을 입력받는 창을 띄운다. 취소하면 null을 반환한다.
        /// </summary>
        public static string? Prompt(IWin32Window owner, string message, string placeholder = "")
        {
            using var f = new InputBoxForm(message, placeholder);
            return f.ShowDialog(owner) == DialogResult.OK ? f.Value : null;
        }
    }
}
