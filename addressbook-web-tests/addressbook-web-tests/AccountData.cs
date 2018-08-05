using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests_Namespace
{
    public class AccountData_Class
    {
        private string username_Field;
        private string password_Field;

        public AccountData_Class(string username_Parameter, string password_Parameter) //constructor klassa AccountData_Class
        {
            username_Field = username_Parameter;
            password_Field = password_Parameter;
        }

        public string Username_Property
        {
            get {return username_Field;}
            set {username_Field = value;}
        }

        public string Password_property
        {
            get {return password_Field;}
            set {password_Field = value;}
        }
    }
}
