using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModule
{
    public sealed class fncUser
    {
        private fncUser() {
            fulltxt = string.Format("{0} {1} }", name, fulltxt);
        }

        private static readonly Lazy<fncUser> _user = new Lazy<fncUser>(() => new fncUser());

        public static fncUser getUser {
            get { return _user.Value; }
        }


        private static string sabun;
        private static string name;
        private static string ename;
        private static string dept;
        private static string position;
        private static string mobile;
        private static string officetel;
        private static string fulltxt;

        public static string Sabun { get { return sabun; }       set { sabun = value; } }
        public static string Name { get { return name; }         set { name = value; }}
        public static string Ename { get { return ename; }       set { ename = value; } }
        public static string Dept{ get { return dept; }          set { dept = value; } }
        public static string Position { get { return position; } set { position = value; } }
        public static string Mobile { get { return mobile; }      set { mobile = value; } }
        public static string Officetel{ get { return officetel; }    set { officetel = value; } }
        public static string Fulltxt{ get { return sabun; } set { fulltxt = value; } }


    }
    
}
