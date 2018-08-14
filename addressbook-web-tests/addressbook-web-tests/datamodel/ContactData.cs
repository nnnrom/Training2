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

        public string LastName_Property
        {
            get { return LastName; }
            set { LastName = value; }
        }

        public string MiddleName_Property
        {
            get { return MiddleName; }
            set { MiddleName = value; }
        }

        public string FirstName_Property
        {
            get { return FirstName; }
            set { FirstName = value; }
        }
    }
}
