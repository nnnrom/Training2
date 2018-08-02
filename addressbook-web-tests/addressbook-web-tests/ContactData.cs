using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests_Namespace
{
    class ContactData_Class
    {
        private string contactFirstName_Field;
        private string contactMiddleName_Field="";
        private string contactLastName_Field;

        public ContactData_Class (string contactLastName_Parametr, string contactFirstName_Parametr)
        {
            contactLastName_Field = contactLastName_Parametr;
            contactFirstName_Field = contactFirstName_Parametr;
        }

        public string ContactLastName_Property
        {
            get { return contactLastName_Field; }
            set { contactLastName_Field = value; }
        }

        public string ContactMiddleName_Property
        {
            get { return contactMiddleName_Field; }
            set { contactMiddleName_Field = value; }
        }

        public string ContactFirstName_Property
        {
            get { return contactFirstName_Field; }
            set { contactFirstName_Field = value; }
        }
    }
}
