using MailSender.Forms;
using MailSender.Services;

namespace MailSender
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;
            QuestPDF.Settings.UseSystemFonts = true;
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // 프로그램 시작 시 SQLite DB 파일과 테이블을 준비한다. (없으면 새로 만든다)
            try
            {
                Database.Initialize();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"데이터베이스를 준비하지 못했습니다.\n\n경로 : {AppPaths.DbFile}\n\n{ex.Message}",
                    "DB 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Application.Run(new MainForm());
        }
    }
}
