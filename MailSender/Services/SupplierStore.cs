using MailSender.Models;

namespace MailSender.Services
{
    /// <summary>
    /// 거래명세서의 공급자 정보를 DB(invoice_supplier 테이블)에서 관리합니다.
    /// </summary>
    public class SupplierStore
    {
        /// <summary>마지막으로 DB에서 읽어온 공급자 목록</summary>
        public List<InvoiceSupplier> Suppliers { get; private set; } = new();

        /// <summary>
        /// DB에 저장된 공급자 목록을 새로 읽어온다. (기본 공급자가 맨 위)
        /// </summary>
        public void Load()
        {
            var list = new List<InvoiceSupplier>();

            using var conn = Database.Open();
            using var cmd = Database.CreateCommand(conn, null,
                @"SELECT id, name, reg_no, company_name, ceo_name, address, biz_type, biz_item, is_default, seal_image
                    FROM invoice_supplier
                   ORDER BY is_default DESC, name, id");
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new InvoiceSupplier
                {
                    Id = reader.GetInt64(0),
                    Name = reader.GetString(1),
                    RegNo = reader.GetString(2),
                    CompanyName = reader.GetString(3),
                    CeoName = reader.GetString(4),
                    Address = reader.GetString(5),
                    BizType = reader.GetString(6),
                    BizItem = reader.GetString(7),
                    IsDefault = reader.GetInt32(8) == 1,
                    SealImage = reader.IsDBNull(9) ? null : (byte[])reader[9],
                });
            }

            Suppliers = list;
        }

        /// <summary>
        /// 새 공급자를 추가하고, 부여된 번호를 반환한다.
        /// </summary>
        public long Add(InvoiceSupplier s)
        {
            long id;

            using (var conn = Database.Open())
            using (var tx = conn.BeginTransaction())
            {
                id = Database.ExecInsert(conn, tx,
                    @"INSERT INTO invoice_supplier
                          (name, reg_no, company_name, ceo_name, address, biz_type, biz_item, is_default, seal_image)
                      VALUES (@name, @reg, @company, @ceo, @addr, @type, @item, @def, @seal)",
                    ("@name", s.Name), ("@reg", s.RegNo), ("@company", s.CompanyName),
                    ("@ceo", s.CeoName), ("@addr", s.Address), ("@type", s.BizType),
                    ("@item", s.BizItem), ("@def", s.IsDefault ? 1 : 0), ("@seal", s.SealImage));

                ClearOtherDefaults(conn, tx, id, s.IsDefault);
                tx.Commit();
            }

            Load();
            return id;
        }

        /// <summary>
        /// 기존 공급자 정보를 수정한다.
        /// </summary>
        public void Update(InvoiceSupplier s)
        {
            using (var conn = Database.Open())
            using (var tx = conn.BeginTransaction())
            {
                Database.Exec(conn, tx,
                    @"UPDATE invoice_supplier
                          SET name = @name, reg_no = @reg, company_name = @company, ceo_name = @ceo,
                                  address = @addr, biz_type = @type, biz_item = @item, is_default = @def,
                                  seal_image = @seal
                            WHERE id = @id",
                         ("@name", s.Name), ("@reg", s.RegNo), ("@company", s.CompanyName),
                         ("@ceo", s.CeoName), ("@addr", s.Address), ("@type", s.BizType),
                         ("@item", s.BizItem), ("@def", s.IsDefault ? 1 : 0), ("@seal", s.SealImage), ("@id", s.Id));

                ClearOtherDefaults(conn, tx, s.Id, s.IsDefault);
                tx.Commit();
            }

            Load();
        }

        /// <summary>
        /// 공급자를 삭제한다. (이미 저장된 거래명세서에는 당시 공급자 내용이 복사되어 있어 영향 없음)
        /// </summary>
        public void Remove(long id)
        {
            using var conn = Database.Open();
            Database.Exec(conn, null, "DELETE FROM invoice_supplier WHERE id = @id", ("@id", id));

            Load();
        }

        /// <summary>
        /// 기본 공급자는 1명만 되도록, 이번에 기본으로 지정했다면 나머지의 기본 표시를 해제한다.
        /// </summary>
        private static void ClearOtherDefaults(Microsoft.Data.Sqlite.SqliteConnection conn,
            Microsoft.Data.Sqlite.SqliteTransaction tx, long keepId, bool isDefault)
        {
            if (!isDefault) return;

            Database.Exec(conn, tx,
                "UPDATE invoice_supplier SET is_default = 0 WHERE id <> @id", ("@id", keepId));
        }
    }
}
