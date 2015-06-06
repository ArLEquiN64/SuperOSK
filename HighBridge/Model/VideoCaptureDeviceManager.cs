using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AForge.Video;
using AForge.Video.DirectShow;

namespace HighBridge.Model
{
    public static class VideoCaptureDeviceManager
    {
        public static VideoCaptureDevice Device { get; set; }
        public static event NewFrameEventHandler NewFrameGot = delegate { };
        public static Bitmap Bitmap { get; set; }

        public static void Connect(string deviceName)
        {
            if(deviceName==null)return;
            Device = new VideoCaptureDevice(deviceName);
            Device.NewFrame += NewFrameGot;
            Device.Start();
            NewFrameGot += CamDeviceCtrlNewFrameGot;
        }

        private static void CamDeviceCtrlNewFrameGot(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap = eventArgs.Frame;
        }

        public static void DisConnect()
        {
            Device.NewFrame -= NewFrameGot;
            Device.SignalToStop();
            Device = null;
        }
    }
}
