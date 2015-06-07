using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using HighBridge.Common.Util;
using HighBridge.View;
using HighBridge.View.Pages;

namespace HighBridge.ViewModel
{
    class LoginPageViewModel : ViewModelBase
    {
        private Timer _timer;
        private readonly AlertControleViewModel _controleData;

        public LoginPageViewModel()
        {
            UserName = "wang ?";
            _controleData = new AlertControleViewModel(UserName, (() =>
                  MainWindow.Instance.Dispatcher.Invoke(() =>
                  {
                      MainWindow.Instance.NavigationService.Navigate(new MainPage());
                  })
              ));
            _timer = new Timer((state =>
            {
                _timer.Dispose();
                ControleData.Visibility = true;
                OnpropertyChanged();
            }), null, 1000, 1000);
        }

        private string UserName { get; set; }

        public AlertControleViewModel ControleData
        {
            get { return _controleData; }
        }
    }
}
