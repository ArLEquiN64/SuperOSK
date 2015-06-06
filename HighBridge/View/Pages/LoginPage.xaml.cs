using System.Windows.Controls;
using HighBridge.ViewModel;

namespace HighBridge.View.Pages
{
    /// <summary>
    /// LoginPage.xaml の相互作用ロジック
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
            DataContext = new LoginPageViewModel();
        }
    }
}
