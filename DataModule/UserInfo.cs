using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModule
{
    public class UserInfo
    {
        private string seq;
        private string name;
        private string fullname;
        

        public void setSeq(string seq)
        {
            this.seq = seq;
        }
        public string getSeq()
        {
            return this.seq;
        }


        public void setName(string name)
        {
            this.name = name;
        }
        public string getName()
        {
            return this.name;
        }

        public void setFullname(string name, string title, string deptName )
        {
            this.fullname = name + " " + deptName + " " + title;
        }
        public string getFullname()
        {
            return this.fullname;
        }


    }
    
}
