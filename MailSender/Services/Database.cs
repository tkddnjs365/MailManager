using Microsoft.Data.Sqlite;

namespace MailSender.Services
{
    /// <summary>
    /// SQLite 데이터베이스 연결, 테이블 생성, 공통 SQL 실행 도구를 모아둔 클래스.
    /// 모든 Store 클래스(TemplateStore, CategoryStore 등)가 이 클래스를 통해 DB를 사용한다.
    /// </summary>
    public static class Database
    {
        /// <summary>
        /// DB 연결을 새로 열어서 반환한다. 사용이 끝나면 호출한 쪽에서 using으로 닫아야 한다.
        /// 외래키(FOREIGN KEY) 기능을 켜서, 구분을 지우면 그 구분의 첨부파일도 같이 지워지게 한다.
        /// </summary>
        public static SqliteConnection Open()
        {
            var builder = new SqliteConnectionStringBuilder
            {
                DataSource = AppPaths.DbFile,
                Mode = SqliteOpenMode.ReadWriteCreate,
                ForeignKeys = true,
            };

            var conn = new SqliteConnection(builder.ToString());
            conn.Open();
            return conn;
        }

        /// <summary>
        /// SQL 명령 객체를 만들고 @이름 형태의 파라미터 값을 채워서 반환한다.
        /// 값이 null이면 DB의 NULL로 저장되도록 DBNull로 바꿔준다.
        /// </summary>
        public static SqliteCommand CreateCommand(SqliteConnection conn, SqliteTransaction? tx, string sql,
            params (string Name, object? Value)[] parameters)
        {
            var cmd = conn.CreateCommand();
            cmd.Transaction = tx;
            cmd.CommandText = sql;

            foreach (var (name, value) in parameters)
            {
                cmd.Parameters.AddWithValue(name, value ?? DBNull.Value);
            }

            return cmd;
        }

        /// <summary>
        /// INSERT / UPDATE / DELETE처럼 결과 표가 없는 SQL을 실행하고, 변경된 행 개수를 반환한다.
        /// </summary>
        public static int Exec(SqliteConnection conn, SqliteTransaction? tx, string sql,
            params (string Name, object? Value)[] parameters)
        {
            using var cmd = CreateCommand(conn, tx, sql, parameters);
            return cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// 방금 INSERT한 행의 번호(id)를 돌려받는 INSERT 전용 실행 도구.
        /// </summary>
        public static long ExecInsert(SqliteConnection conn, SqliteTransaction? tx, string sql,
            params (string Name, object? Value)[] parameters)
        {
            using var cmd = CreateCommand(conn, tx, sql + "; SELECT last_insert_rowid();", parameters);
            return Convert.ToInt64(cmd.ExecuteScalar());
        }

        /// <summary>
        /// 프로그램 시작 시 한 번 호출한다.
        /// 폴더와 DB 파일을 만들고, 필요한 테이블이 없으면 생성한다.
        /// </summary>
        public static void Initialize()
        {
            AppPaths.EnsureFolders();

            using var conn = Database.Open();
            Exec(conn, null, SchemaSql);
            EnsureColumn(conn, "invoice_supplier", "seal_image", "BLOB");
            EnsureColumn(conn, "invoice", "seal_image", "BLOB");
        }

        private static void EnsureColumn(SqliteConnection conn, string table, string column, string type)
        {
            using var cmd = conn.CreateCommand();
            cmd.CommandText = $"PRAGMA table_info({table})";
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader.GetString(1) == column) return;
            }

            reader.Close();
            Exec(conn, null, $"ALTER TABLE {table} ADD COLUMN {column} {type}");
        }

        /// <summary>
        /// 프로그램에서 사용하는 모든 테이블을 만드는 SQL. (이미 있으면 건너뜀)
        /// </summary>
        private const string SchemaSql = @"
-- 내 메일(발신 계정) 설정 : 항상 1건만 존재
CREATE TABLE IF NOT EXISTS mail_account (
    id           INTEGER PRIMARY KEY CHECK (id = 1),
    mail_server  TEXT    NOT NULL DEFAULT '',
    smtp_port    INTEGER NOT NULL DEFAULT 465,
    mail_id      TEXT    NOT NULL DEFAULT '',
    sender_name  TEXT    NOT NULL DEFAULT '',
    password_enc TEXT    NOT NULL DEFAULT '',
    updated_at   TEXT    NOT NULL DEFAULT (datetime('now','localtime'))
);

-- 제목관리 : 메일 제목/내용 양식
CREATE TABLE IF NOT EXISTS mail_template (
    id         INTEGER PRIMARY KEY AUTOINCREMENT,
    name       TEXT NOT NULL,
    title      TEXT NOT NULL,
    content    TEXT NOT NULL DEFAULT '',
    created_at TEXT NOT NULL DEFAULT (datetime('now','localtime')),
    updated_at TEXT NOT NULL DEFAULT (datetime('now','localtime'))
);

-- 첨부파일관리 : 구분(세트)
CREATE TABLE IF NOT EXISTS attachment_category (
    id         INTEGER PRIMARY KEY AUTOINCREMENT,
    name       TEXT NOT NULL,
    created_at TEXT NOT NULL DEFAULT (datetime('now','localtime'))
);

-- 첨부파일관리 : 구분에 속한 파일 (파일 내용 자체를 file_data에 저장)
CREATE TABLE IF NOT EXISTS attachment_file (
    id            INTEGER PRIMARY KEY AUTOINCREMENT,
    category_id   INTEGER NOT NULL REFERENCES attachment_category(id) ON DELETE CASCADE,
    file_name     TEXT    NOT NULL,
    original_path TEXT    NOT NULL DEFAULT '',
    file_size     INTEGER NOT NULL,
    file_hash     TEXT    NOT NULL,
    file_data     BLOB    NOT NULL,
    created_at    TEXT    NOT NULL DEFAULT (datetime('now','localtime'))
);
CREATE UNIQUE INDEX IF NOT EXISTS ux_attachment_file_hash ON attachment_file (category_id, file_hash);

-- 메일 전송 이력
CREATE TABLE IF NOT EXISTS mail_history (
    id               INTEGER PRIMARY KEY AUTOINCREMENT,
    sent_at          TEXT    NOT NULL DEFAULT (datetime('now','localtime')),
    recipient        TEXT    NOT NULL,
    subject          TEXT    NOT NULL,
    body             TEXT    NOT NULL DEFAULT '',
    status           TEXT    NOT NULL,
    error_message    TEXT    NOT NULL DEFAULT '',
    mail_count       INTEGER NOT NULL DEFAULT 1,
    attachment_count INTEGER NOT NULL DEFAULT 0
);

-- 메일 전송 이력에 딸린 첨부파일 (몇 번째 메일에 어떤 파일이 붙었는지)
CREATE TABLE IF NOT EXISTS mail_history_attachment (
    id         INTEGER PRIMARY KEY AUTOINCREMENT,
    history_id INTEGER NOT NULL REFERENCES mail_history(id) ON DELETE CASCADE,
    mail_index INTEGER NOT NULL DEFAULT 1,
    file_name  TEXT    NOT NULL,
    file_path  TEXT    NOT NULL DEFAULT '',
    file_size  INTEGER NOT NULL DEFAULT 0
);

-- 공급자 관리
CREATE TABLE IF NOT EXISTS invoice_supplier (
    id           INTEGER PRIMARY KEY AUTOINCREMENT,
    name         TEXT    NOT NULL,
    reg_no       TEXT    NOT NULL DEFAULT '',
    company_name TEXT    NOT NULL DEFAULT '',
    ceo_name     TEXT    NOT NULL DEFAULT '',
    address      TEXT    NOT NULL DEFAULT '',
    biz_type     TEXT    NOT NULL DEFAULT '',
    biz_item     TEXT    NOT NULL DEFAULT '',
    seal_image   BLOB,
    is_default   INTEGER NOT NULL DEFAULT 0,
    created_at   TEXT    NOT NULL DEFAULT (datetime('now','localtime'))
);

-- 거래명세서 (공급자 정보는 작성 당시 내용을 그대로 복사해서 보관)
CREATE TABLE IF NOT EXISTS invoice (
    id           INTEGER PRIMARY KEY AUTOINCREMENT,
    supply_date  TEXT    NOT NULL,
    buyer_name   TEXT    NOT NULL DEFAULT '',
    supplier_id  INTEGER,
    reg_no       TEXT    NOT NULL DEFAULT '',
    company_name TEXT    NOT NULL DEFAULT '',
    ceo_name     TEXT    NOT NULL DEFAULT '',
    address      TEXT    NOT NULL DEFAULT '',
    biz_type     TEXT    NOT NULL DEFAULT '',
    biz_item     TEXT    NOT NULL DEFAULT '',
    seal_image   BLOB,
    total_count  INTEGER NOT NULL DEFAULT 0,
    total_amount INTEGER NOT NULL DEFAULT 0,
    created_at   TEXT    NOT NULL DEFAULT (datetime('now','localtime')),
    updated_at   TEXT    NOT NULL DEFAULT (datetime('now','localtime'))
);
CREATE INDEX IF NOT EXISTS ix_invoice_supply_date ON invoice (supply_date);

-- 거래명세서 품목
CREATE TABLE IF NOT EXISTS invoice_item (
    id         INTEGER PRIMARY KEY AUTOINCREMENT,
    invoice_id INTEGER NOT NULL REFERENCES invoice(id) ON DELETE CASCADE,
    line_no    INTEGER NOT NULL,
    item_date  TEXT    NOT NULL DEFAULT '',
    name       TEXT    NOT NULL DEFAULT '',
    spec       TEXT    NOT NULL DEFAULT '',
    etc        TEXT    NOT NULL DEFAULT '',
    amount     TEXT    NOT NULL DEFAULT '',
    unit_price TEXT    NOT NULL DEFAULT '',
    tax_amount TEXT    NOT NULL DEFAULT ''
);

-- 거래명세서로 만든 PDF 파일 이력 (PDF 저장을 누를 때마다 1건씩 추가, 기존 PDF는 유지)
CREATE TABLE IF NOT EXISTS invoice_pdf (
    id         INTEGER PRIMARY KEY AUTOINCREMENT,
    invoice_id INTEGER NOT NULL REFERENCES invoice(id) ON DELETE CASCADE,
    pdf_path   TEXT    NOT NULL,
    created_at TEXT    NOT NULL DEFAULT (datetime('now','localtime'))
);
";
    }
}
