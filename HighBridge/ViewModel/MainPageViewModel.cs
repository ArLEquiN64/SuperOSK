using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using HighBridge.Common.Util;
using HighBridge.Model;

namespace HighBridge.ViewModel
{
    class MainPageViewModel:ViewModelBase
    {
        private BitmapFrame _imageSource;
        private Timer _timer;

        public MainPageViewModel()
        {
            TwitterId = AccountManager.MyData.TwitterId;
            Comment = AccountManager.MyData.Comment;
            //_timer=new Timer((state =>
            //{
            //    if (VideoCaptureDeviceManager.Bitmap==null)return;
            //    ImageSource = BitmapToBitmapFrame.Convert(VideoCaptureDeviceManager.Bitmap);
            //}),null,100,100);

            VideoCaptureDeviceManager.NewFrameGot += (s, e) =>
            {
                if (VideoCaptureDeviceManager.Bitmap == null) return;
                ImageSource = BitmapToBitmapFrame.Convert(VideoCaptureDeviceManager.Bitmap);
            };
        }

        public BitmapFrame ImageSource
        {
            get { return _imageSource; }
            set
            {
                _imageSource = value; 
                OnpropertyChanged("ImageSource");
            }
        }

        public string TwitterId { get; set; }
        public string Comment { get; set; }


    }
}
