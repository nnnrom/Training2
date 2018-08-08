using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData
    {
        private string FirstName;
        private string MiddleName="";
        private string LastName;

        public ContactData (string LastName, string FirstName)
        {
            this.LastName = LastName;
            this.FirstName = FirstName;
        }

        public string ContactLastName_Property
        {
            get { return LastName; }
            set { LastName = value; }
        }

        public string ContactMiddleName_Property
        {
            get { return MiddleName; }
            set { MiddleName = value; }
        }

        public string ContactFirstName_Property
        {
            get { return FirstName; }
            set { FirstName = value; }
        }
    }
}
