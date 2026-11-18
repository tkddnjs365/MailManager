using MailSender.Forms;
using MailSender.Models;
using MailSender.Services;

namespace MailSender.Views
{
    /// <summary>
    /// 관리 > "메일 계정" 탭. 메일을 보낼 계정(서버, 포트, 주소, 비밀번호, 보낸 사람)을 DB에 저장한다.
    /// 비밀번호는 암호화되어 저장된다.
    /// </summary>
    public partial class AccountControl : UserControl, IRefreshable
    {
        /// <summary>
        /// 컨트롤을 만든다.
        /// </summary>
        public AccountControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// DB에 저장된 메일 설정을 읽어 입력창에 채운다.
        /// </summary>
        public void RefreshView()
        {
            try
            {
                MailAccountSetting s = MailAccountStore.Load();

                txtServer.Text = s.MailServer;
                txtPort.Text = s.SmtpPort > 0 ? s.SmtpPort.ToString() : "";
                txtMailId.Text = s.MailId;
                txtPassword.Text = s.Password;
                txtSender.Text = s.SenderName;
            }
            catch (Exception ex)
            {
                Dialogs.Info(FindForm()!, "메일 설정 오류", ex.Message);
            }
        }

        /// <summary>
        /// "저장" 버튼 클릭. 입력값을 검사하고 DB에 저장한다.
        /// </summary>
        private void btnSave_Click(object? sender, EventArgs e)
        {
            if (txtServer.Text.Trim().Length == 0) { ToastForm.Show(this, "메일 서버를 입력해 주세요", true); txtServer.Inner.Focus(); return; }
            if (!int.TryParse(txtPort.Text.Trim(), out int port)) { ToastForm.Show(this, "SMTP 포트를 숫자로 입력해 주세요", true); txtPort.Inner.Focus(); return; }
            if (txtMailId.Text.Trim().Length == 0) { ToastForm.Show(this, "메일 주소를 입력해 주세요", true); txtMailId.Inner.Focus(); return; }
            if (txtPassword.Text.Length == 0) { ToastForm.Show(this, "비밀번호를 입력해 주세요", true); txtPassword.Inner.Focus(); return; }
            if (txtSender.Text.Trim().Length == 0) { ToastForm.Show(this, "보낸 사람을 입력해 주세요", true); txtSender.Inner.Focus(); return; }

            try
            {
                MailAccountStore.Save(new MailAccountSetting
                {
                    MailServer = txtServer.Text.Trim(), SmtpPort = port, MailId = txtMailId.Text.Trim(),
                    Password = txtPassword.Text, SenderName = txtSender.Text.Trim(),
                });

                ToastForm.Show(this, "메일 설정을 저장했어요");
            }
            catch (Exception ex)
            {
                Dialogs.Info(FindForm()!, "저장 오류", ex.Message);
            }
        }
    }
}
