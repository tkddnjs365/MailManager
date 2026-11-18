namespace MailSender.Models
{
    /// <summary>
    /// 첨부파일 세트의 구분. 예) "홍길동-지게차" 구분 아래에 여러 첨부파일이 속한다.
    /// </summary>
    public class AttachmentCategory
    {
        /// <summary>DB에서 자동으로 부여되는 번호</summary>
        public long Id { get; set; }

        /// <summary>구분 이름</summary>
        public string Name { get; set; } = "";

        /// <summary>이 구분에 등록된 첨부파일 목록 (파일 내용은 제외, 필요할 때 DB에서 따로 읽는다)</summary>
        public List<AttachmentFile> Files { get; set; } = new();

        /// <summary>목록(ListBox)에 표시될 글자는 구분 이름이다.</summary>
        public override string ToString() => Name;
    }

    /// <summary>
    /// DB에 저장된 첨부파일 한 개의 정보. 실제 파일 내용(BLOB)은 용량이 커서 여기에 담지 않는다.
    /// </summary>
    public class AttachmentFile
    {
        /// <summary>DB에서 자동으로 부여되는 번호</summary>
        public long Id { get; set; }

        /// <summary>이 파일이 속한 구분의 번호</summary>
        public long CategoryId { get; set; }

        /// <summary>파일 이름 (메일에 첨부될 때 표시되는 이름)</summary>
        public string FileName { get; set; } = "";

        /// <summary>파일을 처음 추가했을 때의 원본 경로 (기록용)</summary>
        public string OriginalPath { get; set; } = "";

        /// <summary>파일 크기(byte)</summary>
        public long FileSize { get; set; }

        /// <summary>파일 내용의 SHA256 값. 같은 파일이 중복 등록/중복 첨부되는 것을 막는 데 사용</summary>
        public string FileHash { get; set; } = "";

        /// <summary>목록에 "파일명   (크기)" 형태로 표시한다.</summary>
        public override string ToString() => $"{FileName}   ({FormatSize(FileSize)})";

        /// <summary>
        /// byte 단위 크기를 KB / MB처럼 읽기 쉬운 글자로 바꾼다.
        /// </summary>
        private static string FormatSize(long bytes)
        {
            if (bytes >= 1024 * 1024) return $"{bytes / 1024.0 / 1024.0:N1} MB";
            if (bytes >= 1024) return $"{bytes / 1024.0:N0} KB";
            return $"{bytes} B";
        }
    }
}
