using MailSender.Models;
using Microsoft.Data.Sqlite;
using System.Globalization;

namespace MailSender.Services
{
    /// <summary>
    /// 거래명세서(invoice)와 품목(invoice_item), PDF 생성 이력(invoice_pdf)을 DB에서 관리합니다.
    /// </summary>
    public class InvoiceStore
    {
        /// <summary>
        /// 저장된 거래명세서 요약 목록을 최근 공급일자 순으로 가져온다. (목록 그리드용)
        /// </summary>
        public List<InvoiceSummary> Search()
        {
            var list = new List<InvoiceSummary>();

            using var conn = Database.Open();
            using var cmd = Database.CreateCommand(conn, null,
                @"SELECT id, supply_date, buyer_name, total_count, total_amount
                    FROM invoice
                   ORDER BY supply_date DESC, id DESC");
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new InvoiceSummary
                {
                    Id = reader.GetInt64(0),
                    SupplyDate = reader.GetString(1),
                    BuyerName = reader.GetString(2),
                    TotalCount = reader.GetInt32(3),
                    TotalAmount = reader.GetInt64(4),
                });
            }

            return list;
        }

        /// <summary>
        /// 거래명세서 한 건(품목 포함)을 DB에서 읽어온다. 없으면 null.
        /// </summary>
        public InvoiceData? Get(long id)
        {
            using var conn = Database.Open();

            InvoiceData? data = null;

            using (var cmd = Database.CreateCommand(conn, null,
                @"SELECT id, supply_date, buyer_name, supplier_id, reg_no, company_name, ceo_name,
                         address, biz_type, biz_item, total_amount, seal_image
                   FROM invoice WHERE id = @id", ("@id", id)))
            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    data = new InvoiceData
                    {
                        Id = reader.GetInt64(0),
                        SupplyDate = DateTime.TryParse(reader.GetString(1), CultureInfo.InvariantCulture,
                            DateTimeStyles.None, out var d) ? d : DateTime.Today,
                        BuyerName = reader.GetString(2),
                        SupplierId = reader.IsDBNull(3) ? null : reader.GetInt64(3),
                        RegNo = reader.GetString(4),
                        CompanyName = reader.GetString(5),
                        CeoName = reader.GetString(6),
                        Address = reader.GetString(7),
                        BizType = reader.GetString(8),
                        BizItem = reader.GetString(9),
                        Amt = reader.GetInt64(10).ToString("#,##0"),
                        SealImage = reader.IsDBNull(11) ? null : (byte[])reader[11],
                    };
                }
            }

            if (data == null) return null;

            using (var cmd = Database.CreateCommand(conn, null,
                @"SELECT item_date, name, spec, etc, amount, unit_price, tax_amount
                    FROM invoice_item WHERE invoice_id = @id ORDER BY line_no", ("@id", id)))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    data.Items.Add(new InvoiceItem
                    {
                        Date = reader.GetString(0),
                        Name = reader.GetString(1),
                        Spec = reader.GetString(2),
                        Etc = reader.GetString(3),
                        Amt = reader.GetString(4),
                        UnitPrice = reader.GetString(5),
                        TaxAmount = reader.GetString(6),
                    });
                }
            }

            return data;
        }

        /// <summary>
        /// 거래명세서를 저장한다. Id가 0이면 새로 추가하고, 0이 아니면 기존 내용을 수정한다.
        /// 품목은 기존 것을 모두 지우고 화면 내용으로 다시 저장한다. (전부 성공해야 반영)
        /// </summary>
        /// <returns>저장된 거래명세서의 DB 번호</returns>
        public long Save(InvoiceData data)
        {
            using var conn = Database.Open();
            using var tx = conn.BeginTransaction();

            var p = new (string, object?)[]
            {
                ("@date", data.SupplyDate.ToString("yyyy-MM-dd")),
                ("@buyer", data.BuyerName),
                ("@supplierId", data.SupplierId),
                ("@reg", data.RegNo),
                ("@company", data.CompanyName),
                ("@ceo", data.CeoName),
                ("@addr", data.Address),
                ("@type", data.BizType),
                ("@item", data.BizItem),
                ("@seal", data.SealImage),
                ("@count", data.Items.Count),
                ("@amount", data.TotalAmount),
            };

            long id = data.Id;

            if (id == 0)
            {
                id = Database.ExecInsert(conn, tx,
                    @"INSERT INTO invoice
                          (supply_date, buyer_name, supplier_id, reg_no, company_name, ceo_name,
                            address, biz_type, biz_item, seal_image, total_count, total_amount)
                       VALUES (@date, @buyer, @supplierId, @reg, @company, @ceo,
                               @addr, @type, @item, @seal, @count, @amount)", p);
            }
            else
            {
                Database.Exec(conn, tx,
                    @"UPDATE invoice
                         SET supply_date = @date, buyer_name = @buyer, supplier_id = @supplierId,
                             reg_no = @reg, company_name = @company, ceo_name = @ceo,
                             address = @addr, biz_type = @type, biz_item = @item, seal_image = @seal,
                             total_count = @count, total_amount = @amount,
                             updated_at = datetime('now','localtime')
                       WHERE id = @id",
                    p.Append(("@id", (object?)id)).ToArray());

                Database.Exec(conn, tx, "DELETE FROM invoice_item WHERE invoice_id = @id", ("@id", id));
            }

            int lineNo = 1;
            foreach (var item in data.Items)
            {
                Database.Exec(conn, tx,
                    @"INSERT INTO invoice_item
                          (invoice_id, line_no, item_date, name, spec, etc, amount, unit_price, tax_amount)
                      VALUES (@iid, @line, @date, @name, @spec, @etc, @amt, @unit, @tax)",
                    ("@iid", id), ("@line", lineNo++), ("@date", item.Date ?? ""), ("@name", item.Name ?? ""),
                    ("@spec", item.Spec ?? ""), ("@etc", item.Etc ?? ""), ("@amt", item.Amt ?? ""),
                    ("@unit", item.UnitPrice ?? ""), ("@tax", item.TaxAmount ?? ""));
            }

            tx.Commit();
            return id;
        }

        /// <summary>
        /// 거래명세서를 삭제한다. 품목과 PDF 이력도 함께 삭제된다. (이미 만들어진 PDF 파일은 그대로 남음)
        /// </summary>
        public void Delete(long id)
        {
            using var conn = Database.Open();
            Database.Exec(conn, null, "DELETE FROM invoice WHERE id = @id", ("@id", id));
        }

        /// <summary>
        /// 거래명세서로 PDF를 만들 때마다 그 파일 경로를 이력으로 남긴다.
        /// </summary>
        public void AddPdf(long invoiceId, string pdfPath)
        {
            using var conn = Database.Open();
            Database.Exec(conn, null,
                "INSERT INTO invoice_pdf (invoice_id, pdf_path) VALUES (@id, @path)",
                ("@id", invoiceId), ("@path", pdfPath));
        }
    }
}
