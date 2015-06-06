using System;
using System.Windows.Controls;
using AForge.Video;
using HighBridge.Common.Util;

namespace HighBridge.View
{
    /// <summary>
    /// MainPage.xaml の相互作用ロジック
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            camDeviceCtrl.NewFrameGot += CamDeviceCtrlNewFrameGot;
        }
        private void CamDeviceCtrlNewFrameGot(object sender, NewFrameEventArgs eventArgs)
        {
            picture.Dispatcher.Invoke(() =>
            {
                picture.Source = BitmapToBitmapFrame.Convert(eventArgs.Frame);
            });
        }
    }
}
