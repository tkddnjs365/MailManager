namespace MailSender.Models
{
    /// <summary>
    /// 내 메일(발신 계정) 정보. 메일 서버, 포트, 아이디, 비밀번호, 보낸 사람 이름을 담는다.
    /// </summary>
    internal class MailAccountSetting
    {
        /// <summary>SMTP 메일 서버 주소 (예: smtp.naver.com)</summary>
        public string MailServer { get; set; } = "";

        /// <summary>SMTP 포트 번호 (SSL 기본 465)</summary>
        public int SmtpPort { get; set; } = 465;

        /// <summary>메일 계정 아이디(메일 주소)</summary>
        public string MailId { get; set; } = "";

        /// <summary>받는 사람에게 표시될 보낸 사람 이름</summary>
        public string SenderName { get; set; } = "";

        /// <summary>메일 비밀번호 (프로그램에서는 그대로, DB에는 암호화해서 저장)</summary>
        public string Password { get; set; } = "";
    }
}
