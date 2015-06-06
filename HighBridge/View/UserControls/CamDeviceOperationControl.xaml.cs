using System.Windows;
using System.Windows.Controls;
using AForge.Video;
using AForge.Video.DirectShow;
using HighBridge.Model;

namespace HighBridge.View.UserControls
{
    /// <summary>
    /// CamDeviceOperationControl.xaml の相互作用ロジック
    /// </summary>
    public partial class CamDeviceOperationControl : UserControl
    {
        public CamDeviceOperationControl()
        {
            InitializeComponent();
        }

        private void Connect_Click(object sender, RoutedEventArgs e)
        {
            VideoCaptureDeviceManager.Connect((string)DeviceListCombo.SelectedValue);
        }

        private void Disconnect_Click(object sender, RoutedEventArgs e)
        {
           VideoCaptureDeviceManager.DisConnect();
        }
    }
}
