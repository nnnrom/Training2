using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {

        private string FirstName;
        private string MiddleName="";
        private string LastName;

        public ContactData (string LastName, string FirstName)
        {
            this.LastName = LastName;
            this.FirstName = FirstName;
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return LastName == other.LastName && FirstName == other.FirstName;
        }
          
        public override string ToString()
        {
            return LastName + " " + FirstName;
        }
        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            if (LastName==other.LastName)
            {
                if (FirstName == other.FirstName)
                {
                    return 0;
                }
                return LastName.CompareTo(other.LastName);
            }
            return LastName.CompareTo(other.LastName);

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
