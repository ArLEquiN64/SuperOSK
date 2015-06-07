using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using HighBridge.Common.Commands;
using HighBridge.Common.Util;

namespace HighBridge.ViewModel
{
    class AlertControleViewModel:ViewModelBase
    {
        private bool _visibility;

        public AlertControleViewModel(string str,Action act)
        {
            Text = str;
            Visibility = false;
            Command=new AlwaysExecutableDelegateCommand(o =>
            {
                act();
            });
        }

        public bool Visibility
        {
            get { return _visibility; }
            set
            {
                _visibility = value;
                OnpropertyChanged();
            }
        }

        public string Text { get; set; }

        public AlwaysExecutableDelegateCommand Command { get; set; }
    }
}
