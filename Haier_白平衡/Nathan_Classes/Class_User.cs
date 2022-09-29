using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Automation.Nathan_Classes
{
    [Serializable]
    public class Class_User
    {
        public int index { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Authority Level { get; set; }

        List<Class_User> listUser = new List<Class_User>();
       
        public enum Authority
        {
            Admin
        }
    }

    
}
