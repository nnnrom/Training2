using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;
        private string homepage;

        public ContactData (string firstName, string lastName)
        {
            LastName = lastName;
            FirstName = firstName;
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

        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string FirstName { get; set; }
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }

        //public string AllPhones { get; set; }
        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }
        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
                return "";
            return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
        }

        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        //public string AllEmail { get; set; }
        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (CleanUp(Email1) + CleanUp(Email2) + CleanUp(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }
        //public string HomePage { get; set; }
        public string HomepageValue { get; set; }
        public string HomePageLink
        {
            get
            {
                if (homepage != null)
                {
                    return homepage;
                }
                else
                {
                    return "http://" + HomepageValue;
                }
            }
            set
            {
                homepage = value;
            }
        }
    }
}
