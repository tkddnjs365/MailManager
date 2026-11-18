namespace MailSender.Models
{
    /// <summary>
    /// 미리 등록해 두고 사용할 메일 제목/내용(양식)입니다.
    /// </summary>
    public class MailTemplate
    {
        /// <summary>DB에서 자동으로 부여되는 번호</summary>
        public long Id { get; set; }

        /// <summary>양식 이름 (목록에 표시되는 이름)</summary>
        public string Name { get; set; } = "";

        /// <summary>메일 제목</summary>
        public string Title { get; set; } = "";

        /// <summary>메일 내용</summary>
        public string Content { get; set; } = "";

        /// <summary>목록(ListBox)에 표시될 글자는 양식 이름이다.</summary>
        public override string ToString() => Name;
    }
}
