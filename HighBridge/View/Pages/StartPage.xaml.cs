using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AForge.Video.DirectShow;
using HighBridge.Model;
using HighBridge.ViewModel;

namespace HighBridge.View.Pages
{
    /// <summary>
    /// StartPage.xaml の相互作用ロジック
    /// </summary>
    public partial class StartPage : Page
    {
        public StartPage()
        {
            InitializeComponent();
            DataContext = new StartPageViewModel();
            FilterInfoCollection infocolection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if(infocolection.Count==0)return;
            VideoCaptureDeviceManager.Connect(infocolection[0].MonikerString);
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegisterPage());
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginPage());
        }
    }
}
