namespace MailSender.Models
{
    /// <summary>
    /// 메일 전송 1회분의 이력(받는사람, 제목, 내용, 결과)과 그때 첨부된 파일 목록.
    /// </summary>
    public class MailHistoryRecord
    {
        /// <summary>받는 사람 메일 주소</summary>
        public string Recipient { get; set; } = "";

        /// <summary>메일 제목 (여러 통으로 나뉘어도 원본 제목 그대로)</summary>
        public string Subject { get; set; } = "";

        /// <summary>메일 내용</summary>
        public string Body { get; set; } = "";

        /// <summary>전송 결과 ("성공" 또는 "실패")</summary>
        public string Status { get; set; } = "";

        /// <summary>실패했을 때의 오류 내용</summary>
        public string ErrorMessage { get; set; } = "";

        /// <summary>용량 때문에 몇 통으로 나눠 보냈는지</summary>
        public int MailCount { get; set; } = 1;

        /// <summary>첨부된 파일 목록</summary>
        public List<MailHistoryAttachment> Attachments { get; set; } = new();
    }

    /// <summary>
    /// 메일 전송 이력에 기록되는 첨부파일 한 개의 정보.
    /// </summary>
    public class MailHistoryAttachment
    {
        /// <summary>몇 번째 메일에 첨부되었는지 (1부터 시작)</summary>
        public int MailIndex { get; set; } = 1;

        /// <summary>첨부된 파일 이름</summary>
        public string FileName { get; set; } = "";

        /// <summary>첨부파일의 원본 경로</summary>
        public string FilePath { get; set; } = "";

        /// <summary>파일 크기(byte)</summary>
        public long FileSize { get; set; }
    }
}

namespace MailSender.Models
{
    /// <summary>
    /// 전송 이력 목록에 보여줄 한 줄 요약.
    /// </summary>
    public class MailHistoryRow
    {
        public long Id { get; set; }
        public string SentAt { get; set; } = "";
        public string Recipient { get; set; } = "";
        public string Subject { get; set; } = "";
        public string Body { get; set; } = "";
        public string Status { get; set; } = "";
        public string ErrorMessage { get; set; } = "";
        public int MailCount { get; set; }
        public int AttachmentCount { get; set; }
    }
}
