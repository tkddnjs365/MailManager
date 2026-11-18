using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace MailSender.Controls
{
    /// <summary>
    /// 모서리가 둥글고 테두리가 있는 카드 모양 패널. 내용을 묶어서 보여줄 때 사용한다.
    /// </summary>
    public class UiCard : Panel
    {
        private Color _fill = Ui.Surface;
        private Color _border = Ui.Border;
        private int _radius = 14;

        /// <summary>
        /// 카드를 만들고, 깜빡임 없이 부드럽게 그리도록 설정한다.
        /// </summary>
        public UiCard()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw |
                     ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
        }

        /// <summary>카드 안쪽을 채우는 색</summary>
        [Category("Appearance"), DefaultValue(typeof(Color), "White")]
        public Color FillColor { get => _fill; set { _fill = value; Invalidate(); } }

        /// <summary>카드 테두리 색 (투명이면 테두리 없음)</summary>
        [Category("Appearance")]
        public Color BorderColor { get => _border; set { _border = value; Invalidate(); } }

        /// <summary>모서리 둥근 정도(px)</summary>
        [Category("Appearance"), DefaultValue(14)]
        public int Radius { get => _radius; set { _radius = value; Invalidate(); } }

        /// <summary>FillColor는 기본값(흰색)일 때 디자이너 코드에 저장하지 않는다.</summary>
        private bool ShouldSerializeFillColor() => _fill != Ui.Surface;

        /// <summary>BorderColor는 기본값일 때 디자이너 코드에 저장하지 않는다.</summary>
        private bool ShouldSerializeBorderColor() => _border != Ui.Border;

        /// <summary>
        /// 카드 배경(둥근 사각형 + 테두리)을 그린다.
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // 둥근 모서리 바깥은 부모의 색으로 먼저 칠한다.
            Color back = Parent is UiCard pc ? pc.FillColor : (Parent?.BackColor.A == 255 ? Parent.BackColor : Ui.Bg);
            g.Clear(back);

            using var path = Ui.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), _radius);
            using var brush = new SolidBrush(_fill);
            g.FillPath(brush, path);

            if (_border.A > 0)
            {
                using var pen = new Pen(_border);
                g.DrawPath(pen, path);
            }
        }
    }
}
