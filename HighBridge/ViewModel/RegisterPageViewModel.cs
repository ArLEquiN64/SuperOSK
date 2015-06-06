using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HighBridge.Common.Commands;
using HighBridge.Common.Util;
using HighBridge.Model;

namespace HighBridge.ViewModel
{
    class RegisterPageViewModel:ViewModelBase
    {
        private string _deviceName;

        public RegisterPageViewModel()
        {
            ConnectCommand=new AlwaysExecutableDelegateCommand(o =>
            {
                VideoCaptureDeviceManager.Connect(DeviceName);
            });
        }

        public AlwaysExecutableDelegateCommand ConnectCommand { get; set; }

        public string DeviceName
        {
            get { return _deviceName; }
            set
            {
                _deviceName = value; 
                OnpropertyChanged();
            }
        }
    }
}
