using MailSender.Controls;

namespace MailSender.Views
{
    /// <summary>
    /// "관리" 화면. 위쪽 탭(메일 양식 / 첨부파일 / 공급자 / 메일 계정)으로 관리 화면을 전환한다.
    /// </summary>
    public partial class ManageView : UserControl, IRefreshable
    {
        /// <summary>탭 이름 → (탭 버튼, 관리 컨트롤) 연결표</summary>
        private readonly Dictionary<string, (UiButton Tab, Control Page)> _tabs = new();

        /// <summary>현재 열려 있는 탭 이름</summary>
        private string _current = "tpl";

        /// <summary>
        /// 화면을 만들고 탭과 관리 컨트롤을 연결한다.
        /// </summary>
        public ManageView()
        {
            InitializeComponent();

            _tabs["tpl"] = (btnTabTpl, templateControl);
            _tabs["cat"] = (btnTabCat, categoryControl);
            _tabs["sup"] = (btnTabSup, supplierControl);
            _tabs["acc"] = (btnTabAcc, accountControl);
        }

        /// <summary>
        /// 탭 버튼을 누르면 그 탭의 관리 화면으로 바꾼다.
        /// </summary>
        private void btnTab_Click(object? sender, EventArgs e)
        {
            foreach (var (key, pair) in _tabs)
            {
                if (pair.Tab == sender) { SelectTab(key); return; }
            }
        }

        /// <summary>
        /// 지정한 탭만 보이게 하고 버튼의 선택 표시를 맞춘 뒤 최신 데이터로 새로 고친다.
        /// </summary>
        /// <param name="key">tpl(메일 양식) / cat(첨부파일) / sup(공급자) / acc(메일 계정)</param>
        public void SelectTab(string key)
        {
            if (!_tabs.ContainsKey(key)) key = "tpl";
            _current = key;

            foreach (var (k, pair) in _tabs)
            {
                pair.Tab.Checked = k == key;
                pair.Page.Visible = k == key;
            }

            RefreshView();
        }

        /// <summary>
        /// 현재 열려 있는 탭의 데이터를 DB에서 새로 읽는다.
        /// </summary>
        public void RefreshView()
        {
            if (_tabs[_current].Page is IRefreshable r) r.RefreshView();
        }
    }
}
