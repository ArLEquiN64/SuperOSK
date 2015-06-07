using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using HighBridge.Common.Util;

namespace HighBridge.ViewModel
{
    class MainPageViewModel:ViewModelBase
    {
        public MainPageViewModel()
        {
            
        }
        public Bitmap ImageSource { get; set; }

    }
}
