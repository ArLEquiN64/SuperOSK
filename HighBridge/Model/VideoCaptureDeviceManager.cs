using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using AForge.Video;
using AForge.Video.DirectShow;
using HighBridge.Common.Util;

namespace HighBridge.Model
{
    public static class VideoCaptureDeviceManager
    {
        public static VideoCaptureDevice Device { get; set; }
        public static event NewFrameEventHandler NewFrameGot = delegate { };
        private static Timer _timer;
        public static BitmapFrame Frame { get; set; }
        public static Bitmap Bitmap { get; set; }

        public static void Connect(string deviceName)
        {
            if(deviceName==null)return;
            Device = new VideoCaptureDevice(deviceName);
            Device.Start();
            Device.NewFrame += CamDeviceCtrlNewFrameGot;
        }

        private static void CamDeviceCtrlNewFrameGot(object sender, NewFrameEventArgs eventArgs)
        {
            Frame = BitmapToBitmapFrame.Convert(eventArgs.Frame);
            Bitmap = new Bitmap(eventArgs.Frame);
            NewFrameGot(sender, eventArgs);
        }

        public static void DisConnect()
        {
            Device.NewFrame -= NewFrameGot;
            Device.SignalToStop();
            Device = null;
        }
    }
}
