using DataModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myChat.Service
{
    public sealed class  LoginModule
    {
        private LoginModule() { }
        private static LoginModule _loginModule = new LoginModule();
        public static UserInfo userInfo
        {
            get { return userInfo; }
            set { userInfo = value; }
        }

        public static LoginModule getLoginModule()
        {
            if(_loginModule == null)
            {
                _loginModule = new LoginModule();
            }
            return _loginModule;
        }
        
    }
}
