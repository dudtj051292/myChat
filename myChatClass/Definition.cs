using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myChatClass
{
    public enum LOGIN_STATUS
    {
        FAIL = 0,
        SUCCESS = 1,
    }
    public static class Definition
    {
        public static string SERVER_IP= "127.0.0.1";
        public static int SERVER_PORT = 9999;
        public readonly static Encoding encoder = Encoding.GetEncoding("utf-8");
        
        
    }
}
