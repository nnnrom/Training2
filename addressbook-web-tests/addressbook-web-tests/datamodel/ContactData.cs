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
        private string homePageLink;
        private string allData;

        public ContactData (string lastname, string firstname)
        {
            SecondName = SecondName;
            FirstName = FirstName;
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
            return SecondName == other.SecondName && FirstName == other.FirstName;
        }
          
        public override string ToString()
        {
            return SecondName + " " + FirstName;
        }
        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            if (SecondName==other.SecondName)
            {
                if (FirstName == other.FirstName)
                {
                    return 0;
                }
                return SecondName.CompareTo(other.SecondName);
            }
            return SecondName.CompareTo(other.SecondName);

        }

        public string SecondName { get; set; }
        public string MiddleName { get; set; }
        public string FirstName { get; set; }
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string SecondaryHome { get; set; }
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
                    return CleanUp(HomePhone) + "\r\n" + CleanUp(MobilePhone) + "\r\n" + CleanUp(WorkPhone) + "\r\n" + CleanUp(SecondaryHome);
                }
            }
            set
            {
                allPhones = value;
            }
        }

        private string CleanUp(string data)
        {
            if (data == null|| data == "")
            {
                return "";
            }
            return data.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "");
        }

        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
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
                    return Email1 + "\r\n" + Email2 + "\r\n" + Email3;
                }
            }
            set
            {
                allEmails = value;
            }
        }
        public string HomePageValue { get; set; }

        public string HomePageLink
        {
            get
            {
                if (homePageLink != null)
                {
                    return homePageLink;
                }
                else
                {
                    //return HomePageValue;
                    return "http://"+ HomePageValue +"/";
                }
            }
            set
            {
                homePageLink = value;
            }
        }
        public string AllData
        {
            get
            {
                if (allData != null)
                {
                    return allData;
                }
                else
                {
                    return FirstName + " " + MiddleName + " " + SecondName;
                        //+ "\r\n"
                              //+ Address + "\r\n"
                              //+ "\r\n"
                              //+ "H: " + HomePhone + "\r\n"
                              //+ "M: " + MobilePhone + "\r\n"
                              //+ "W: " + WorkPhone + "\r\n"
                              //+ "\r\n"
                              //+ Email1 + "\r\n"
                              //+ Email2 + "\r\n"
                              //+ Email3;
                }
            }
            set
            {
                allData = value;
            }
        }
    }
}
