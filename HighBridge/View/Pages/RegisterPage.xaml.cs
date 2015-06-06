using System.Windows;
using System.Windows.Controls;
using HighBridge.Model;
using HighBridge.ViewModel;

namespace HighBridge.View.Pages
{
    /// <summary>
    /// RegisterPage.xaml の相互作用ロジック
    /// </summary>
    public partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            InitializeComponent();
            DataContext=new RegisterPageViewModel();
        }
    }
}
