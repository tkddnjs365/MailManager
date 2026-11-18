using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace MailSender.Controls
{
    /// <summary>
    /// 둥근 모서리의 입력창. 안쪽에 일반 TextBox를 품고 있으며,
    /// 포커스를 받으면 테두리가 파란색으로 바뀐다.
    /// </summary>
    public class UiTextBox : Control
    {
        private readonly TextBox _tb = new();
        private bool _focused;
        private bool _multiline;

        /// <summary>
        /// 입력창을 만들고 안쪽 TextBox를 설정한다.
        /// </summary>
        public UiTextBox()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            Font = new Font("맑은 고딕", 10F);
            _tb.BorderStyle = BorderStyle.None;
            _tb.ForeColor = Ui.Text;
            _tb.BackColor = Ui.Surface2;
            _tb.Font = Font;
            _tb.GotFocus += (_, _) => { _focused = true; _tb.BackColor = Ui.Surface; Invalidate(); };
            _tb.LostFocus += (_, _) => { _focused = false; _tb.BackColor = Ui.Surface2; Invalidate(); };
            _tb.TextChanged += (_, e) => OnTextChanged(e);
            _tb.KeyPress += (_, e) => OnKeyPress(e);
            Controls.Add(_tb);
            Size = new Size(200, 38);
        }

        /// <summary>안쪽 TextBox (포커스 이동 등에 사용)</summary>
        [Browsable(false)]
        public TextBox Inner => _tb;

        /// <summary>입력된 글자</summary>
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), DefaultValue("")]
        public override string Text { get => _tb.Text; set => _tb.Text = value; }

        /// <summary>여러 줄 입력 여부</summary>
        [Category("Behavior"), DefaultValue(false)]
        public bool Multiline
        {
            get => _multiline;
            set { _multiline = value; _tb.Multiline = value; _tb.ScrollBars = value ? ScrollBars.Vertical : ScrollBars.None; LayoutInner(); }
        }

        /// <summary>입력 전에 흐리게 보이는 안내 문구</summary>
        [Category("Appearance"), DefaultValue("")]
        public string PlaceholderText { get => _tb.PlaceholderText; set => _tb.PlaceholderText = value; }

        /// <summary>읽기 전용 여부</summary>
        [Category("Behavior"), DefaultValue(false)]
        public bool ReadOnly { get => _tb.ReadOnly; set => _tb.ReadOnly = value; }

        /// <summary>비밀번호처럼 글자를 가릴지 여부</summary>
        [Category("Behavior"), DefaultValue(false)]
        public bool UseSystemPasswordChar { get => _tb.UseSystemPasswordChar; set => _tb.UseSystemPasswordChar = value; }

        /// <summary>글자 정렬(왼쪽/오른쪽/가운데)</summary>
        [Category("Appearance"), DefaultValue(HorizontalAlignment.Left)]
        public HorizontalAlignment TextAlign { get => _tb.TextAlign; set => _tb.TextAlign = value; }

        /// <summary>글꼴이 바뀌면 안쪽 TextBox도 같은 글꼴로 맞추고 위치를 다시 잡는다.</summary>
        protected override void OnFontChanged(EventArgs e) { _tb.Font = Font; LayoutInner(); base.OnFontChanged(e); }

        /// <summary>크기가 바뀌면 안쪽 TextBox 위치/크기를 다시 계산한다.</summary>
        protected override void OnResize(EventArgs e) { LayoutInner(); base.OnResize(e); }

        /// <summary>
        /// 안쪽 TextBox를 여백을 두고 배치한다. 한 줄 입력은 세로 가운데, 여러 줄은 꽉 채운다.
        /// </summary>
        private void LayoutInner()
        {
            if (_multiline)
            {
                _tb.SetBounds(12, 10, Math.Max(10, Width - 24), Math.Max(10, Height - 20));
            }
            else
            {
                _tb.Width = Math.Max(10, Width - 24);
                _tb.Location = new Point(12, Math.Max(0, (Height - _tb.Height) / 2));
            }
        }

        /// <summary>
        /// 둥근 입력창 배경과 테두리를 그린다. (포커스 중이면 파란 테두리)
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Ui.BackdropOf(this));

            using var path = Ui.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), 10);
            using (var brush = new SolidBrush(_focused ? Ui.Surface : Ui.Surface2)) g.FillPath(brush, path);
            using var pen = new Pen(_focused ? Ui.Primary : Ui.Border, _focused ? 1.6f : 1f);
            g.DrawPath(pen, path);
        }

        /// <summary>입력창의 빈 곳을 클릭해도 글자 입력 상태가 되도록 포커스를 넘긴다.</summary>
        protected override void OnMouseDown(MouseEventArgs e) { _tb.Focus(); base.OnMouseDown(e); }
    }
}
