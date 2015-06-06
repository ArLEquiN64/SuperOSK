using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using HighBridge.Model;

namespace HighBridge.Common.Util
{
    interface IRegister
    {
        void AddUser(UserData userdata);
    }

}
