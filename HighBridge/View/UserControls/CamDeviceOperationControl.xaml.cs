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
        private VideoCaptureDevice device;

        public CamDeviceOperationControl()
        {
            InitializeComponent();
        }

        private void Connect_Click(object sender, RoutedEventArgs e)
        {
            device = new VideoCaptureDevice((string)deviceListCombo.SelectedValue);
            device.NewFrame += NewFrameGot;
            device.Start();
        }

        private void Disconnect_Click(object sender, RoutedEventArgs e)
        {
            device.NewFrame -= NewFrameGot;
            device.SignalToStop();
            device = null;
        }
    }
}
