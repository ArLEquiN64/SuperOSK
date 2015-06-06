using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HighBridge.Model;

namespace HighBridge.Common.Util
{
    interface IUserSerch
    {
        UserData[] Serch(Bitmap userdata);
    }
}
