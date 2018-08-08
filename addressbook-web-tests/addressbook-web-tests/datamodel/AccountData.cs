using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class AccountData
    {
        private string username;
        private string password;

        public AccountData(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public string Username_Property
        {
            get {return username;}
            set {username = value;}
        }

        public string Password_property
        {
            get {return password;}
            set {password = value;}
        }
    }
}
