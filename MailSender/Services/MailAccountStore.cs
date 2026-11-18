using MailSender.Models;
using System.Security.Cryptography;
using System.Text;

namespace MailSender.Services
{
    /// <summary>
    /// 내 메일(발신 계정) 설정을 DB(mail_account 테이블)에서 읽고 저장합니다.
    /// 비밀번호는 현재 Windows 사용자만 풀 수 있도록 암호화해서 저장합니다.
    /// </summary>
    internal static class MailAccountStore
    {
        /// <summary>
        /// 저장된 메일 설정을 읽어온다. 저장된 값이 없으면 빈 설정을 반환한다.
        /// </summary>
        public static MailAccountSetting Load()
        {
            try
            {
                using var conn = Database.Open();
                using var cmd = Database.CreateCommand(conn, null,
                    "SELECT mail_server, smtp_port, mail_id, sender_name, password_enc FROM mail_account WHERE id = 1");
                using var reader = cmd.ExecuteReader();

                if (!reader.Read())
                {
                    return new MailAccountSetting();
                }

                return new MailAccountSetting
                {
                    MailServer = reader.GetString(0),
                    SmtpPort = reader.GetInt32(1),
                    MailId = reader.GetString(2),
                    SenderName = reader.GetString(3),
                    Password = Decrypt(reader.GetString(4)),
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"메일 설정 불러오기 중 오류가 발생했습니다.\n{ex.Message}", ex);
            }
        }

        /// <summary>
        /// 메일 설정을 DB에 저장한다. (이미 있으면 덮어쓰기)
        /// </summary>
        public static void Save(MailAccountSetting setting)
        {
            try
            {
                using var conn = Database.Open();
                Database.Exec(conn, null,
                    @"INSERT INTO mail_account (id, mail_server, smtp_port, mail_id, sender_name, password_enc)
                      VALUES (1, @server, @port, @mailId, @name, @pw)
                      ON CONFLICT(id) DO UPDATE SET
                          mail_server  = excluded.mail_server,
                          smtp_port    = excluded.smtp_port,
                          mail_id      = excluded.mail_id,
                          sender_name  = excluded.sender_name,
                          password_enc = excluded.password_enc,
                          updated_at   = datetime('now','localtime')",
                    ("@server", setting.MailServer),
                    ("@port", setting.SmtpPort),
                    ("@mailId", setting.MailId),
                    ("@name", setting.SenderName),
                    ("@pw", Encrypt(setting.Password)));
            }
            catch (Exception ex)
            {
                throw new Exception($"메일 설정 저장 중 오류가 발생했습니다.\n{ex.Message}", ex);
            }
        }

        /// <summary>
        /// 비밀번호를 암호화한다. (Windows 사용자 계정 기준)
        /// </summary>
        private static string Encrypt(string plainText)
        {
            if (string.IsNullOrEmpty(plainText)) return "";

            byte[] encrypted = ProtectedData.Protect(
                Encoding.UTF8.GetBytes(plainText), null, DataProtectionScope.CurrentUser);

            return Convert.ToBase64String(encrypted);
        }

        /// <summary>
        /// 암호화된 비밀번호를 원래 글자로 되돌린다.
        /// </summary>
        private static string Decrypt(string encryptedText)
        {
            if (string.IsNullOrEmpty(encryptedText)) return "";

            byte[] decrypted = ProtectedData.Unprotect(
                Convert.FromBase64String(encryptedText), null, DataProtectionScope.CurrentUser);

            return Encoding.UTF8.GetString(decrypted);
        }
    }
}
