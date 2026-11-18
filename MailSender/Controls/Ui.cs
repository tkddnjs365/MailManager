using System.Drawing.Drawing2D;

namespace MailSender.Controls
{
    /// <summary>
    /// 프로그램 전체에서 공통으로 쓰는 색상 팔레트와 그리기 도구 모음. (웹의 CSS 변수 역할)
    /// </summary>
    public static class Ui
    {
        /// <summary>화면 전체 배경색 (연한 회색)</summary>
        public static readonly Color Bg = Color.FromArgb(245, 246, 248);

        /// <summary>카드/입력 영역의 흰색 바탕</summary>
        public static readonly Color Surface = Color.White;

        /// <summary>입력창, 보조 영역의 아주 연한 회색 바탕</summary>
        public static readonly Color Surface2 = Color.FromArgb(249, 250, 251);

        /// <summary>테두리 색상</summary>
        public static readonly Color Border = Color.Black;

        /// <summary>기본 글자색</summary>
        public static readonly Color Text = Color.FromArgb(17, 24, 39);

        /// <summary>보조 설명 글자색 (회색)</summary>
        public static readonly Color Muted = Color.FromArgb(107, 114, 128);

        /// <summary>주요 강조색 (파란색)</summary>
        public static readonly Color Primary = Color.FromArgb(59, 91, 219);

        /// <summary>주요 강조색의 연한 배경</summary>
        public static readonly Color PrimarySoft = Color.FromArgb(238, 242, 255);

        /// <summary>성공/저장 색상 (초록색)</summary>
        public static readonly Color Ok = Color.FromArgb(14, 159, 110);

        /// <summary>성공 색상의 연한 배경</summary>
        public static readonly Color OkSoft = Color.FromArgb(227, 248, 238);

        /// <summary>삭제/오류 색상 (빨간색)</summary>
        public static readonly Color Danger = Color.FromArgb(225, 29, 72);

        /// <summary>삭제/오류 색상의 연한 배경</summary>
        public static readonly Color DangerSoft = Color.FromArgb(255, 228, 233);

        /// <summary>경고 색상 (주황 갈색)</summary>
        public static readonly Color Warn = Color.FromArgb(180, 83, 9);

        /// <summary>경고 색상의 연한 배경</summary>
        public static readonly Color WarnSoft = Color.FromArgb(254, 243, 199);


        /// <summary>
        /// 모서리가 둥근 사각형 경로를 만든다.
        /// </summary>
        /// <param name="r">사각형 영역</param>
        /// <param name="radius">모서리 반지름(px)</param>
        public static GraphicsPath RoundRect(Rectangle r, int radius)
        {
            int d = Math.Max(1, Math.Min(radius * 2, Math.Min(r.Width, r.Height)));

            var path = new GraphicsPath();

            path.AddArc(r.X, r.Y, d, d, 180, 90);
            path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);

            path.CloseFigure();

            return path;
        }


        /// <summary>
        /// 컨트롤 뒤에 보이는 배경색을 찾는다. (둥근 모서리 바깥을 같은 색으로 칠하기 위해 사용)
        /// 부모가 카드(UiCard)면 카드의 바탕색, 투명이면 더 위의 부모를 확인한다.
        /// </summary>
        public static Color BackdropOf(Control c)
        {
            for (Control? p = c.Parent; p != null; p = p.Parent)
            {
                if (p is UiCard card)
                    return card.FillColor;

                if (p.BackColor.A == 255)
                    return p.BackColor;
            }

            return Bg;
        }
    }
}