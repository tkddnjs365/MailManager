using SkiaSharp;

namespace MailSender.Services
{
    /// <summary>
    /// 첨부파일 목록 옆에 작은 미리보기(썸네일)를 보여주기 위한 서비스
    /// </summary>
    public static class ThumbnailService
    {
        /// <summary>
        /// 파일 이름(확장자 확인용)과 파일 내용(byte)으로 정사각형 썸네일 이미지를 만든다.
        /// 이미지/PDF는 실제 내용을 그리고, 그 외 파일이나 실패한 경우에는 확장자가 적힌 기본 아이콘을 만든다.
        /// </summary>
        /// <param name="fileName">파일 이름 (확장자로 종류를 구분)</param>
        /// <param name="data">DB에서 읽어온 파일 내용</param>
        /// <param name="size">썸네일 한 변의 크기(px)</param>
        public static Image CreateThumbnail(string fileName, byte[] data, int size)
        {
            var ext = Path.GetExtension(fileName).ToLowerInvariant();

            try
            {
                if (ext is ".png" or ".jpg" or ".jpeg" or ".bmp" or ".gif")
                {
                    // GDI+ 이미지는 만들어진 동안 스트림이 열려 있어야 하므로 stream을 먼저 선언한다.
                    using var stream = new MemoryStream(data);
                    using var original = Image.FromStream(stream);
                    return ResizeToSquare(original, size);
                }

                if (ext == ".pdf")
                {
                    // PDF 첫 페이지를 이미지로 그린 뒤 썸네일 크기로 줄인다.
                    using var stream = new MemoryStream(data);
                    using var skBitmap = PDFtoImage.Conversion.ToImage(stream, page: 0);
                    using var encoded = skBitmap.Encode(SKEncodedImageFormat.Png, 90);
                    using var ms = new MemoryStream(encoded.ToArray());
                    using var pageImage = Image.FromStream(ms);

                    return ResizeToSquare(pageImage, size);
                }
            }
            catch
            {
                // 렌더링 실패(손상된 파일 등) 시 아래 기본 아이콘으로 대체
            }

            return CreatePlaceholderIcon(ext, size);
        }

        private static Image ResizeToSquare(Image source, int size)
        {
            var bmp = new Bitmap(size, size);
            using var g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            var ratio = Math.Min((float)size / source.Width, (float)size / source.Height);
            var w = source.Width * ratio;
            var h = source.Height * ratio;
            var x = (size - w) / 2f;
            var y = (size - h) / 2f;
            g.DrawImage(source, x, y, w, h);

            return bmp;
        }

        private static Image CreatePlaceholderIcon(string ext, int size)
        {
            var bmp = new Bitmap(size, size);
            using var g = Graphics.FromImage(bmp);
            g.Clear(Color.FromArgb(0xF2, 0xF4, 0xF8));
            using var pen = new Pen(Color.FromArgb(0xC1, 0x44, 0x3C), 2);
            g.DrawRectangle(pen, 3, 3, size - 7, size - 7);

            var label = string.IsNullOrEmpty(ext) ? "FILE" : ext.TrimStart('.').ToUpperInvariant();
            using var font = new Font("맑은 고딕", Math.Max(8f, size / 6f), FontStyle.Bold);
            var textSize = g.MeasureString(label, font);
            g.DrawString(label, font, Brushes.DimGray, (size - textSize.Width) / 2f, (size - textSize.Height) / 2f);

            return bmp;
        }
    }
}
