using System.Windows.Controls;
using AForge.Video;
using HighBridge.Common.Util;
using HighBridge.ViewModel;

namespace HighBridge.View.Pages
{
    /// <summary>
    /// MainPage.xaml の相互作用ロジック
    /// </summary>
    public partial class MainPage : Page
    {
        private MainPageViewModel ViewModel { get; set; }
        public MainPage()
        {
            InitializeComponent();
            CamDeviceCtrl.NewFrameGot += CamDeviceCtrlNewFrameGot;
        }
        private void CamDeviceCtrlNewFrameGot(object sender, NewFrameEventArgs eventArgs)
        {
            ViewModel.ImageSource = eventArgs.Frame;
            Picture.Dispatcher.Invoke(() =>
            {
                Picture.Source = BitmapToBitmapFrame.Convert(eventArgs.Frame);
            });
        }
    }
}
