using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace MailSender.Controls
{
    /// <summary>버튼의 모양(색상 스타일) 종류</summary>
    public enum ButtonKind
    {
        /// <summary>파란색 채움 (주요 동작)</summary>
        Primary,
        /// <summary>흰색 + 테두리 (보조 동작)</summary>
        Secondary,
        /// <summary>초록색 채움 (저장)</summary>
        Success,
        /// <summary>흰색 + 빨간 글자 (삭제)</summary>
        Danger,
        /// <summary>빨간색 채움 (삭제 확인)</summary>
        DangerSolid,
        /// <summary>배경 없이 파란 글자 (링크)</summary>
        Link,
        /// <summary>왼쪽 메뉴 항목</summary>
        Nav,
        /// <summary>둥근 알약 모양 (선택/해제 가능)</summary>
        Chip,
    }

    /// <summary>
    /// 둥근 모서리의 모던한 버튼. Kind 속성으로 색상 스타일을 정하고,
    /// Chip/Nav 스타일은 Checked 속성으로 선택 상태를 표현한다.
    /// </summary>
    public class UiButton : Button
    {
        private ButtonKind _kind = ButtonKind.Secondary;
        private bool _checked;
        private bool _hover;
        private bool _down;

        /// <summary>
        /// 버튼을 만들고 기본 모양(플랫, 손가락 커서)을 설정한다.
        /// </summary>
        public UiButton()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            Cursor = Cursors.Hand;
            Font = new Font("맑은 고딕", 10F, FontStyle.Bold);
        }

        /// <summary>버튼 색상 스타일</summary>
        [Category("Appearance"), DefaultValue(ButtonKind.Secondary)]
        public ButtonKind Kind { get => _kind; set { _kind = value; Invalidate(); } }

        /// <summary>선택된 상태인지 여부 (Chip, Nav 스타일에서 사용)</summary>
        [Category("Appearance"), DefaultValue(false)]
        public bool Checked { get => _checked; set { _checked = value; Invalidate(); } }

        /// <summary>true이면 클릭할 때마다 Checked가 켜졌다 꺼진다. (Chip 스타일)</summary>
        [Category("Behavior"), DefaultValue(false)]
        public bool Checkable { get; set; }

        /// <summary>Checked 값이 사용자 클릭으로 바뀌었을 때 발생한다.</summary>
        public event EventHandler? CheckedChanged;

        /// <summary>마우스가 올라오면 hover 색상으로 다시 그린다.</summary>
        protected override void OnMouseEnter(EventArgs e) { _hover = true; Invalidate(); base.OnMouseEnter(e); }

        /// <summary>마우스가 벗어나면 원래 색상으로 다시 그린다.</summary>
        protected override void OnMouseLeave(EventArgs e) { _hover = false; _down = false; Invalidate(); base.OnMouseLeave(e); }

        /// <summary>마우스를 누르는 동안 눌린 색상으로 그린다.</summary>
        protected override void OnMouseDown(MouseEventArgs mevent) { _down = true; Invalidate(); base.OnMouseDown(mevent); }

        /// <summary>마우스를 떼면 원래 색상으로 되돌린다.</summary>
        protected override void OnMouseUp(MouseEventArgs mevent) { _down = false; Invalidate(); base.OnMouseUp(mevent); }

        /// <summary>
        /// 클릭 시 Checkable이면 선택 상태를 뒤집고 CheckedChanged 이벤트를 발생시킨다.
        /// </summary>
        protected override void OnClick(EventArgs e)
        {
            if (Checkable)
            {
                _checked = !_checked;
                CheckedChanged?.Invoke(this, EventArgs.Empty);
                Invalidate();
            }
            base.OnClick(e);
        }

        /// <summary>
        /// 색상 스타일(Kind)과 상태(hover/눌림/선택/비활성)에 맞춰 버튼을 직접 그린다.
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Ui.BackdropOf(this));

            Color bg, fg, border = Color.Transparent;
            bool left = false;
            int radius = 10;

            switch (_kind)
            {
                case ButtonKind.Primary:
                    bg = Shade(Ui.Primary); fg = Color.White; break;
                case ButtonKind.Success:
                    bg = Shade(Ui.Ok); fg = Color.White; break;
                case ButtonKind.DangerSolid:
                    bg = Shade(Ui.Danger); fg = Color.White; break;
                case ButtonKind.Danger:
                    bg = _hover ? Ui.DangerSoft : Ui.Surface; fg = Ui.Danger; border = Ui.Border; break;
                case ButtonKind.Link:
                    bg = Ui.BackdropOf(this); fg = _hover ? Color.FromArgb(0x2B, 0x44, 0xB0) : Ui.Primary; break;
                case ButtonKind.Nav:
                    bg = _checked ? Ui.PrimarySoft : (_hover ? Ui.Surface2 : Ui.BackdropOf(this));
                    fg = _checked ? Ui.Primary : Ui.Muted;
                    border = _checked ? Color.FromArgb(199, 210, 254)
                        : (_hover ? Color.FromArgb(209, 213, 219) : Color.FromArgb(229, 231, 235));
                    left = true;
                    break;
                case ButtonKind.Chip:
                    radius = Height / 2;
                    bg = _checked ? Ui.Primary : (_hover ? Ui.Surface2 : Ui.Surface);
                    fg = _checked ? Color.White : Ui.Text;
                    border = _checked ? Ui.Primary : (_hover ? Ui.Primary : Ui.Border);
                    break;
                default: // Secondary
                    bg = _hover ? Ui.Surface2 : Ui.Surface; fg = Ui.Text; border = Ui.Border; break;
            }

            if (!Enabled)
            {
                bg = Ui.Surface2; fg = Ui.Muted; border = Ui.Border;
            }

            using var path = Ui.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), radius);
            using (var brush = new SolidBrush(bg)) g.FillPath(brush, path);
            if (border.A > 0)
            {
                using var pen = new Pen(border);
                g.DrawPath(pen, path);
            }

            var flags = TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis | TextFormatFlags.NoPrefix |
                        (left ? TextFormatFlags.Left : TextFormatFlags.HorizontalCenter);
            var rect = left ? new Rectangle(14, 0, Width - 20, Height) : new Rectangle(4, 0, Width - 8, Height);
            TextRenderer.DrawText(g, Text, Font, rect, fg, flags);
        }

        /// <summary>
        /// 마우스 상태에 따라 색을 조금 어둡게 만든다. (hover: 약간, 누름: 더)
        /// </summary>
        private Color Shade(Color c)
        {
            if (_down) return ControlPaint.Dark(c, 0.1f);
            if (_hover) return ControlPaint.Light(c, 0.12f);
            return c;
        }
    }
}
