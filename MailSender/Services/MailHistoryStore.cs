using MailSender.Models;

namespace MailSender.Services
{
    /// <summary>
    /// 메일 전송 이력(받는사람, 제목, 내용, 첨부파일명/경로)을 DB에 저장합니다.
    /// </summary>
    public static class MailHistoryStore
    {
        /// <summary>
        /// 메일 전송 1회분의 이력과 첨부파일 목록을 한 번에 저장한다. (중간에 실패하면 전부 취소)
        /// </summary>
        public static void Save(MailHistoryRecord record)
        {
            using var conn = Database.Open();
            using var tx = conn.BeginTransaction();

            long historyId = Database.ExecInsert(conn, tx,
                @"INSERT INTO mail_history
                      (recipient, subject, body, status, error_message, mail_count, attachment_count)
                  VALUES (@recipient, @subject, @body, @status, @error, @mailCount, @attachCount)",
                ("@recipient", record.Recipient),
                ("@subject", record.Subject),
                ("@body", record.Body),
                ("@status", record.Status),
                ("@error", record.ErrorMessage),
                ("@mailCount", record.MailCount),
                ("@attachCount", record.Attachments.Count));

            foreach (var file in record.Attachments)
            {
                Database.Exec(conn, tx,
                    @"INSERT INTO mail_history_attachment (history_id, mail_index, file_name, file_path, file_size)
                      VALUES (@hid, @idx, @name, @path, @size)",
                    ("@hid", historyId),
                    ("@idx", file.MailIndex),
                    ("@name", file.FileName),
                    ("@path", file.FilePath),
                    ("@size", file.FileSize));
            }

            tx.Commit();
        }

        /// <summary>
        /// 저장된 전송 이력을 최근 순으로 읽어온다. (첨부파일 목록은 제외)
        /// </summary>
        public static List<MailHistoryRow> Search()
        {
            var list = new List<MailHistoryRow>();

            using var conn = Database.Open();
            using var cmd = Database.CreateCommand(conn, null,
                @"SELECT id, sent_at, recipient, subject, body, status, error_message, mail_count, attachment_count
                    FROM mail_history ORDER BY id DESC");
            using var r = cmd.ExecuteReader();

            while (r.Read())
            {
                list.Add(new MailHistoryRow
                {
                    Id = r.GetInt64(0), SentAt = r.GetString(1), Recipient = r.GetString(2),
                    Subject = r.GetString(3), Body = r.GetString(4), Status = r.GetString(5),
                    ErrorMessage = r.GetString(6), MailCount = r.GetInt32(7), AttachmentCount = r.GetInt32(8),
                });
            }

            return list;
        }

        /// <summary>
        /// 특정 전송 이력에 첨부되었던 파일 목록(파일명, 원본경로, 크기)을 읽어온다.
        /// </summary>
        public static List<MailHistoryAttachment> GetAttachments(long historyId)
        {
            var list = new List<MailHistoryAttachment>();

            using var conn = Database.Open();
            using var cmd = Database.CreateCommand(conn, null,
                @"SELECT mail_index, file_name, file_path, file_size
                    FROM mail_history_attachment WHERE history_id = @id ORDER BY id", ("@id", historyId));
            using var r = cmd.ExecuteReader();

            while (r.Read())
            {
                list.Add(new MailHistoryAttachment
                {
                    MailIndex = r.GetInt32(0), FileName = r.GetString(1), FilePath = r.GetString(2), FileSize = r.GetInt64(3),
                });
            }

            return list;
        }
    }
}
