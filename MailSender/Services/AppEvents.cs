namespace MailSender.Services
{
    /// <summary>
    /// 화면(View)끼리 서로 직접 알지 못해도 "데이터가 바뀌었어요 / 이 화면으로 이동해 주세요"를 전달하는 공용 알림 창구.
    /// 예) 관리 화면에서 양식을 저장하면 메일 작성 화면이 양식 목록을 새로 읽는다.
    /// </summary>
    public static class AppEvents
    {
        /// <summary>메일 양식이 추가/수정/삭제되었을 때</summary>
        public static event Action? TemplatesChanged;

        /// <summary>첨부파일 구분/파일이 바뀌었을 때</summary>
        public static event Action? CategoriesChanged;

        /// <summary>공급자가 추가/수정/삭제되었을 때</summary>
        public static event Action? SuppliersChanged;

        /// <summary>메일 전송 이력이 새로 쌓였을 때</summary>
        public static event Action? HistoryChanged;

        /// <summary>다른 화면으로 이동 요청 (화면 이름, 관리 화면의 탭 이름)</summary>
        public static event Action<string, string?>? NavigateRequested;

        /// <summary>양식 변경 알림을 보낸다.</summary>
        public static void RaiseTemplatesChanged() => TemplatesChanged?.Invoke();

        /// <summary>첨부파일 변경 알림을 보낸다.</summary>
        public static void RaiseCategoriesChanged() => CategoriesChanged?.Invoke();

        /// <summary>공급자 변경 알림을 보낸다.</summary>
        public static void RaiseSuppliersChanged() => SuppliersChanged?.Invoke();

        /// <summary>전송 이력 변경 알림을 보낸다.</summary>
        public static void RaiseHistoryChanged() => HistoryChanged?.Invoke();

        /// <summary>화면 이동을 요청한다. (view: compose / invoice / history / manage)</summary>
        public static void Navigate(string view, string? tab = null) => NavigateRequested?.Invoke(view, tab);
    }

    /// <summary>
    /// 모든 화면이 함께 사용하는 DB 저장소 객체들. (화면마다 새로 만들지 않고 하나를 공유)
    /// </summary>
    public static class AppServices
    {
        /// <summary>첨부파일 구분/파일 저장소</summary>
        public static readonly CategoryStore Categories = new();

        /// <summary>메일 양식 저장소</summary>
        public static readonly TemplateStore Templates = new();

        /// <summary>공급자 저장소</summary>
        public static readonly SupplierStore Suppliers = new();

        /// <summary>거래명세서 저장소</summary>
        public static readonly InvoiceStore Invoices = new();
    }
}
