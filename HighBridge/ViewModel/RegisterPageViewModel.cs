﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HighBridge.Common.Commands;
using HighBridge.Common.Util;
using HighBridge.Model;
using HighBridge.View;

namespace HighBridge.ViewModel
{
    internal class RegisterPageViewModel : ViewModelBase
    {
        private string _deviceName;
        private string _userName;

        public RegisterPageViewModel()
        {
            ConnectCommand = new AlwaysExecutableDelegateCommand(o =>
            {
                AddUser();
            });
        }

        private async void AddUser()
        {
            if (UserName == null) return;
            VideoCaptureDeviceManager.Connect(DeviceName);
            var data = await GetBitMapAsync();
            var newUser = new UserData(/*FaceDate.GetFaceDate(data)*/ "this_is_ID", UserName);
            AccountManager.AddUser(newUser);

        }

        private async Task<Bitmap> GetBitMapAsync()
        {
            return VideoCaptureDeviceManager.Bitmap;
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

        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value; 
                OnpropertyChanged();
            }
        }
    }
}
