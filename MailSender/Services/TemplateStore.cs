using MailSender.Models;

namespace MailSender.Services
{
    /// <summary>
    /// 미리 등록한 메일 제목/내용(양식)을 DB(mail_template 테이블)에서 관리합니다.
    /// </summary>
    public class TemplateStore
    {
        /// <summary>마지막으로 DB에서 읽어온 양식 목록</summary>
        public List<MailTemplate> Templates { get; private set; } = new();

        /// <summary>
        /// DB에 저장된 양식 목록을 새로 읽어온다.
        /// </summary>
        public void Load()
        {
            var list = new List<MailTemplate>();

            using var conn = Database.Open();
            using var cmd = Database.CreateCommand(conn, null,
                "SELECT id, name, title, content FROM mail_template ORDER BY id");
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new MailTemplate
                {
                    Id = reader.GetInt64(0),
                    Name = reader.GetString(1),
                    Title = reader.GetString(2),
                    Content = reader.GetString(3),
                });
            }

            Templates = list;
        }

        /// <summary>
        /// 새 양식을 DB에 추가하고, 추가된 양식을 반환한다.
        /// </summary>
        public MailTemplate Add(string name, string title, string content)
        {
            long id;

            using (var conn = Database.Open())
            {
                id = Database.ExecInsert(conn, null,
                    "INSERT INTO mail_template (name, title, content) VALUES (@name, @title, @content)",
                    ("@name", name), ("@title", title), ("@content", content));
            }

            Load();
            return Templates.First(x => x.Id == id);
        }

        /// <summary>
        /// 기존 양식의 이름/제목/내용을 수정한다.
        /// </summary>
        public void Update(long id, string name, string title, string content)
        {
            using var conn = Database.Open();
            Database.Exec(conn, null,
                @"UPDATE mail_template
                     SET name = @name, title = @title, content = @content,
                         updated_at = datetime('now','localtime')
                   WHERE id = @id",
                ("@name", name), ("@title", title), ("@content", content), ("@id", id));

            Load();
        }

        /// <summary>
        /// 양식을 삭제한다.
        /// </summary>
        public void Remove(long id)
        {
            using var conn = Database.Open();
            Database.Exec(conn, null, "DELETE FROM mail_template WHERE id = @id", ("@id", id));

            Load();
        }
    }
}
