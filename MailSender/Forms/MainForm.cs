using MailSender.Controls;
using MailSender.Services;
using MailSender.Views;

namespace MailSender.Forms
{
    /// <summary>
    /// 프로그램의 메인 창. 왼쪽 메뉴(메일 작성 / 거래명세서 / 전송 이력 / 관리)로
    /// 오른쪽에 보여줄 화면(View)을 바꿔 주는 껍데기 역할만 한다.
    /// 실제 기능은 Views 폴더의 각 화면에 들어 있다.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>화면 이름 → (화면 컨트롤, 왼쪽 메뉴 버튼) 연결표</summary>
        private readonly Dictionary<string, (Control View, UiButton Nav)> _views = new();

        /// <summary>
        /// 창을 만들고 화면/메뉴를 연결한 뒤 "메일 작성" 화면부터 보여준다.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            _views["compose"] = (composeView, btnNavCompose);
            _views["invoice"] = (invoiceView, btnNavInvoice);
            _views["history"] = (historyView, btnNavHistory);
            _views["manage"] = (manageView, btnNavManage);

            // 다른 화면에서 "이 화면으로 이동해 주세요" 요청이 오면 처리한다.
            AppEvents.NavigateRequested += OnNavigateRequested;

            ShowView("compose", null);
        }

        /// <summary>
        /// 창이 닫힐 때 화면 이동 알림 연결을 해제한다.
        /// </summary>
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            AppEvents.NavigateRequested -= OnNavigateRequested;
            base.OnFormClosed(e);
        }

        /// <summary>
        /// 왼쪽 메뉴 버튼을 누르면 그 버튼에 연결된 화면을 보여준다.
        /// </summary>
        private void btnNav_Click(object? sender, EventArgs e)
        {
            foreach (var (name, pair) in _views)
            {
                if (pair.Nav == sender)
                {
                    ShowView(name, null);
                    return;
                }
            }
        }

        /// <summary>
        /// 다른 화면이 보낸 이동 요청을 받아 해당 화면으로 전환한다.
        /// </summary>
        private void OnNavigateRequested(string view, string? tab)
        {
            ShowView(view, tab);
        }

        /// <summary>
        /// 지정한 화면만 보이게 하고, 메뉴의 선택 표시를 맞춘 뒤 최신 데이터로 새로 고친다.
        /// </summary>
        /// <param name="name">화면 이름 (compose / invoice / history / manage)</param>
        /// <param name="tab">관리 화면일 때 열 탭 이름 (tpl / cat / sup / acc), 없으면 null</param>
        private void ShowView(string name, string? tab)
        {
            if (!_views.ContainsKey(name)) return;

            foreach (var (key, pair) in _views)
            {
                bool on = key == name;
                pair.View.Visible = on;
                pair.Nav.Checked = on;
            }

            if (name == "manage" && tab != null)
            {
                manageView.SelectTab(tab);
            }

            if (_views[name].View is IRefreshable refreshable)
            {
                refreshable.RefreshView();
            }
        }
    }
}
