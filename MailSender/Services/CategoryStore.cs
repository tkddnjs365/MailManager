using MailSender.Models;
using System.Security.Cryptography;

namespace MailSender.Services
{
    /// <summary>
    /// 첨부파일 구분(attachment_category)과 각 구분에 속한 파일(attachment_file)을 DB에서 관리합니다.
    /// 파일 내용도 DB(BLOB)에 저장하므로, 원본 파일이 지워져도 메일을 보낼 수 있습니다.
    /// </summary>
    public class CategoryStore
    {
        /// <summary>마지막으로 DB에서 읽어온 구분 목록 (각 구분의 Files에는 파일 정보만 있고 내용은 없음)</summary>
        public List<AttachmentCategory> Categories { get; private set; } = new();

        /// <summary>
        /// DB에 저장된 구분과 파일 목록을 새로 읽어온다. (파일 내용은 읽지 않아서 빠름)
        /// </summary>
        public void Load()
        {
            var list = new List<AttachmentCategory>();
            var map = new Dictionary<long, AttachmentCategory>();

            using var conn = Database.Open();

            // 1) 구분 목록
            using (var cmd = Database.CreateCommand(conn, null,
                "SELECT id, name FROM attachment_category ORDER BY id"))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var category = new AttachmentCategory { Id = reader.GetInt64(0), Name = reader.GetString(1) };
                    list.Add(category);
                    map[category.Id] = category;
                }
            }

            // 2) 파일 목록 (file_data 컬럼은 일부러 제외)
            using (var cmd = Database.CreateCommand(conn, null,
                @"SELECT id, category_id, file_name, original_path, file_size, file_hash
                    FROM attachment_file ORDER BY id"))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    long categoryId = reader.GetInt64(1);
                    if (!map.TryGetValue(categoryId, out var category)) continue;

                    category.Files.Add(new AttachmentFile
                    {
                        Id = reader.GetInt64(0),
                        CategoryId = categoryId,
                        FileName = reader.GetString(2),
                        OriginalPath = reader.GetString(3),
                        FileSize = reader.GetInt64(4),
                        FileHash = reader.GetString(5),
                    });
                }
            }

            Categories = list;
        }

        /// <summary>
        /// 새로운 구분(Category)을 추가합니다.
        /// </summary>
        public AttachmentCategory AddCategory(string name)
        {
            long id;

            using (var conn = Database.Open())
            {
                id = Database.ExecInsert(conn, null,
                    "INSERT INTO attachment_category (name) VALUES (@name)", ("@name", name));
            }

            Load();
            return Categories.First(c => c.Id == id);
        }

        /// <summary>
        /// 구분(Category)을 삭제합니다. 그 구분에 속한 파일도 함께 삭제됩니다.
        /// </summary>
        public void RemoveCategory(long id)
        {
            using var conn = Database.Open();
            Database.Exec(conn, null, "DELETE FROM attachment_category WHERE id = @id", ("@id", id));

            Load();
        }

        /// <summary>
        /// 선택한 파일들을 읽어서 특정 구분에 DB로 저장합니다.
        /// 같은 구분에 이미 같은 내용의 파일이 있으면 중복으로 보고 건너뜁니다.
        /// </summary>
        /// <returns>새로 저장된 개수(Added)와 중복이라 건너뛴 개수(Duplicated)</returns>
        public (int Added, int Duplicated) AddFiles(long categoryId, IEnumerable<string> filePaths)
        {
            int added = 0;
            int duplicated = 0;

            using (var conn = Database.Open())
            using (var tx = conn.BeginTransaction())
            {
                foreach (var path in filePaths)
                {
                    byte[] data = File.ReadAllBytes(path);
                    string hash = Convert.ToHexString(SHA256.HashData(data));

                    // OR IGNORE : 같은 구분에 같은 해시가 있으면 저장하지 않고 0행으로 반환된다.
                    int rows = Database.Exec(conn, tx,
                        @"INSERT OR IGNORE INTO attachment_file
                              (category_id, file_name, original_path, file_size, file_hash, file_data)
                          VALUES (@cid, @name, @path, @size, @hash, @data)",
                        ("@cid", categoryId),
                        ("@name", Path.GetFileName(path)),
                        ("@path", path),
                        ("@size", (long)data.Length),
                        ("@hash", hash),
                        ("@data", data));

                    if (rows > 0) added++; else duplicated++;
                }

                tx.Commit();
            }

            Load();
            return (added, duplicated);
        }

        /// <summary>
        /// 특정 파일을 DB에서 삭제합니다.
        /// </summary>
        public void RemoveFile(long fileId)
        {
            using var conn = Database.Open();
            Database.Exec(conn, null, "DELETE FROM attachment_file WHERE id = @id", ("@id", fileId));

            Load();
        }

        /// <summary>
        /// 파일의 실제 내용(byte 배열)을 DB에서 읽어온다. 메일 첨부, 썸네일 생성 때 사용한다.
        /// </summary>
        public byte[] GetFileData(long fileId)
        {
            using var conn = Database.Open();
            using var cmd = Database.CreateCommand(conn, null,
                "SELECT file_data FROM attachment_file WHERE id = @id", ("@id", fileId));

            return cmd.ExecuteScalar() as byte[] ?? Array.Empty<byte>();
        }
    }
}
