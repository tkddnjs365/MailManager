namespace MailSender.Views
{
    /// <summary>
    /// 화면이 다시 보여질 때 DB에서 최신 데이터를 읽어 화면을 새로 고치는 기능을 가진 화면을 표시하는 약속.
    /// </summary>
    public interface IRefreshable
    {
        /// <summary>
        /// DB의 최신 데이터로 화면을 다시 그린다.
        /// </summary>
        void RefreshView();
    }
}
