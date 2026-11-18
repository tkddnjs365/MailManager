namespace MailSender.Services
{
    /// <summary>
    /// 프로그램에서 사용하는 폴더/파일 경로를 한 곳에서 관리하는 클래스.
    /// </summary>
    public static class AppPaths
    {
        /// <summary>
        /// SQLite DB 파일이 저장되는 폴더. (미수금 관리 프로그램과 같은 C:\DataBase 사용)
        /// </summary>
        public static string DbFolder { get; } = @"C:\DataBase";

        /// <summary>
        /// SQLite DB 파일의 전체 경로. (C:\DataBase\mailSender.db)
        /// </summary>
        public static string DbFile => Path.Combine(DbFolder, "mailSender.db");

        /// <summary>
        /// 거래명세서 PDF 파일이 만들어지는 폴더. (바탕화면\거래명세서)
        /// </summary>
        public static string InvoiceFolder => Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "거래명세서");

        /// <summary>
        /// 프로그램 실행에 필요한 폴더(DB 폴더, 거래명세서 폴더)가 없으면 만든다.
        /// </summary>
        public static void EnsureFolders()
        {
            Directory.CreateDirectory(DbFolder);
            Directory.CreateDirectory(InvoiceFolder);
        }
    }
}
