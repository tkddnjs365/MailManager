using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace MailSender.Controls
{
    /// <summary>
    /// 선택 항목이 둥근 파란 배경으로 표시되는 모던한 목록. 항목 오른쪽에 보조 글자(힌트)도 보여줄 수 있다.
    /// </summary>
    public class UiListBox : ListBox
    {
        /// <summary>
        /// 목록을 만들고 직접 그리기 모드로 설정한다.
        /// </summary>
        public UiListBox()
        {
            DrawMode = DrawMode.OwnerDrawFixed;
            ItemHeight = 42;
            BorderStyle = BorderStyle.None;
            BackColor = Ui.Surface;
            IntegralHeight = false;
            DoubleBuffered = true;
        }

        /// <summary>항목 오른쪽에 표시할 보조 글자를 돌려주는 함수 (없으면 null)</summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Func<object, string?>? HintSelector { get; set; }

        /// <summary>
        /// 항목 하나를 그린다. 선택된 항목은 연한 파란 배경 + 파란 테두리로 표시한다.
        /// </summary>
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (var back = new SolidBrush(BackColor)) g.FillRectangle(back, e.Bounds);
            if (e.Index < 0 || e.Index >= Items.Count) return;

            var r = Rectangle.Inflate(e.Bounds, -4, -2);
            bool selected = (e.State & DrawItemState.Selected) != 0;

            if (selected)
            {
                using var path = Ui.RoundRect(r, 10);
                using var fill = new SolidBrush(Ui.PrimarySoft);
                using var pen = new Pen(Ui.Primary);
                g.FillPath(fill, path);
                g.DrawPath(pen, path);
            }

            object item = Items[e.Index]!;
            string? hint = HintSelector?.Invoke(item);
            int hintWidth = 0;

            if (!string.IsNullOrEmpty(hint))
            {
                hintWidth = TextRenderer.MeasureText(hint, Font).Width + 8;
                TextRenderer.DrawText(g, hint, Font, new Rectangle(r.Right - hintWidth - 6, r.Y, hintWidth, r.Height),
                    Ui.Muted, TextFormatFlags.VerticalCenter | TextFormatFlags.Right | TextFormatFlags.NoPrefix);
            }

            TextRenderer.DrawText(g, GetItemText(item), Font,
                new Rectangle(r.X + 10, r.Y, r.Width - 20 - hintWidth, r.Height),
                selected ? Ui.Primary : Ui.Text,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.EndEllipsis | TextFormatFlags.NoPrefix);
        }
    }
}
