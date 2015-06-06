using System.Windows;
using System.Windows.Controls;
using AForge.Video;
using AForge.Video.DirectShow;

namespace HighBridge.View.UserControls
{
    /// <summary>
    /// CamDeviceOperationControl.xaml の相互作用ロジック
    /// </summary>
    public partial class CamDeviceOperationControl : UserControl
    {
        public event NewFrameEventHandler NewFrameGot = delegate { };
        private VideoCaptureDevice _device;

        public CamDeviceOperationControl()
        {
            InitializeComponent();
        }

        private void Connect_Click(object sender, RoutedEventArgs e)
        {
            _device = new VideoCaptureDevice((string)DeviceListCombo.SelectedValue);
            _device.NewFrame += NewFrameGot;
            _device.Start();
        }

        private void Disconnect_Click(object sender, RoutedEventArgs e)
        {
            _device.NewFrame -= NewFrameGot;
            _device.SignalToStop();
            _device = null;
        }
    }
}
