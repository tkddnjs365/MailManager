namespace MailSender.Models
{
    /// <summary>
    /// 거래명세서의 품목 한 줄.
    /// </summary>
    public class InvoiceItem
    {
        public string Date { get; set; } = "";          // 일자
        public string Name { get; set; } = "";          // 품명
        public string Spec { get; set; } = "";          // 규격
        public string Etc { get; set; } = "";           // 기타
        public string Amt { get; set; } = "";           // 공급가액
        public string UnitPrice { get; set; } = "";     // 단가 (화면에서는 숨김)
        public string TaxAmount { get; set; } = "";     // 세액

        /// <summary>공급가액을 숫자로 바꾼 값. (숫자가 아니면 0)</summary>
        public decimal SupplyAmount
        {
            get
            {
                decimal.TryParse(Amt?.Replace(",", ""), out var p);
                return p;
            }
        }
    }

    /// <summary>
    /// 거래명세서 한 건. 화면 입력, DB 저장, PDF 생성에 공통으로 사용한다.
    /// </summary>
    public class InvoiceData
    {
        /// <summary>DB 번호. 아직 저장 전인 새 명세서는 0</summary>
        public long Id { get; set; }

        /// <summary>작성 당시 선택한 공급자 번호 (공급자를 지워도 명세서 내용은 그대로 유지됨)</summary>
        public long? SupplierId { get; set; }

        /// <summary>공급일자</summary>
        public DateTime SupplyDate { get; set; } = DateTime.Today;

        /// <summary>PDF에 표시되는 날짜 글자 (예: 2026년 11월 17일)</summary>
        public string Date => SupplyDate.ToString("yyyy년 MM월 dd일");

        /// <summary>공급받는자 (귀하)</summary>
        public string BuyerName { get; set; } = "";

        /// <summary>합계금액 (천 단위 콤마 포함 글자)</summary>
        public string Amt { get; set; } = "";

        /// <summary>합계금액을 숫자로 바꾼 값. DB의 전체금액 컬럼에 저장된다.</summary>
        public long TotalAmount =>
            decimal.TryParse(Amt?.Replace(",", ""), out var v) ? (long)Math.Round(v) : 0;

        /// <summary>(공급자) 사업자등록번호</summary>
        public string RegNo { get; set; } = "";

        /// <summary>(공급자) 상호</summary>
        public string CompanyName { get; set; } = "";

        /// <summary>(공급자) 성명</summary>
        public string CeoName { get; set; } = "";

        /// <summary>(공급자) 주소</summary>
        public string Address { get; set; } = "";

        /// <summary>(공급자) 업태</summary>
        public string BizType { get; set; } = "";

        /// <summary>(공급자) 종목</summary>
        public string BizItem { get; set; } = "";

        /// <summary>작성 당시 공급자의 직인 이미지</summary>
        public byte[]? SealImage { get; set; }

        /// <summary>품목 목록</summary>
        public List<InvoiceItem> Items { get; set; } = new();

        public decimal SupplyTotal => Items.Sum(i => i.SupplyAmount);

        public decimal TaxTotal => Items.Sum(i =>
        {
            decimal.TryParse(i.TaxAmount?.Replace(",", ""), out var t);
            return t;
        });

        public decimal GrandTotal => SupplyTotal + TaxTotal;
    }

    /// <summary>
    /// 공급자 정보 (제목관리처럼 별도 화면에서 등록해 두고 불러다 쓴다).
    /// </summary>
    public class InvoiceSupplier
    {
        /// <summary>DB에서 자동으로 부여되는 번호</summary>
        public long Id { get; set; }

        /// <summary>목록/콤보박스에 표시될 이름</summary>
        public string Name { get; set; } = "";

        public string RegNo { get; set; } = "";         // 사업자등록번호
        public string CompanyName { get; set; } = "";   // 상호(법인명)
        public string CeoName { get; set; } = "";       // 성명
        public string Address { get; set; } = "";       // 사업장 주소
        public string BizType { get; set; } = "";       // 업태
        public string BizItem { get; set; } = "";       // 종목

        /// <summary>새 거래명세서를 열 때 기본으로 선택할 공급자인지 여부</summary>
        public bool IsDefault { get; set; }

        /// <summary>등록된 직인 이미지</summary>
        public byte[]? SealImage { get; set; }

        /// <summary>목록에 표시될 글자는 이름이다.</summary>
        public override string ToString() => Name;
    }

    /// <summary>
    /// 저장된 거래명세서 목록 그리드에 보여줄 요약 정보.
    /// </summary>
    public class InvoiceSummary
    {
        public long Id { get; set; }
        public string SupplyDate { get; set; } = "";    // 공급일자 (yyyy-MM-dd)
        public string BuyerName { get; set; } = "";     // 공급받는자
        public int TotalCount { get; set; }             // 전체건수 (품목 개수)
        public long TotalAmount { get; set; }           // 전체금액
    }
}
