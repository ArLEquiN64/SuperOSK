using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AForge.Video;
using AForge.Video.DirectShow;

namespace HighBridge.Model
{
    internal static class VideoCaptureDeviceManager
    {
        public static VideoCaptureDevice Device { get; set; }
        public static event NewFrameEventHandler NewFrameGot = delegate { };

        public static void Connect(string deviceName)
        {
            if(deviceName=="")return;
            Device = new VideoCaptureDevice(deviceName);
            Device.NewFrame += NewFrameGot;
            Device.Start();
        }

        public static void DisConnect()
        {
            Device.NewFrame -= NewFrameGot;
            Device.SignalToStop();
            Device = null;
        }
    }
}
