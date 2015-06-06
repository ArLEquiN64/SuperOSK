using System;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Windows.Media;
using System.Windows.Resources;
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

       /*
        * private void FaceMe_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            FaceMe.Visibility = Visibility.Collapsed;
            Loading.Visibility = Visibility.Visible;
        } 
        */
        private void WindowsFormsHost_Loaded(object sender, RoutedEventArgs e)
        {
            WindowsFormsHost host = (WindowsFormsHost)sender;
            PictureBox picBox = (PictureBox)host.Child;
            StreamResourceInfo streamInfo =
                System.Windows.Application.GetResourceStream(
                    new Uri("Assets/loading.gif", UriKind.Relative));
            picBox.Image = (Bitmap)Bitmap.FromStream(streamInfo.Stream);
        }

    }
}
