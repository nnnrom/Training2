using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
        public string Name;
        private string Header="";
        private string Footer = "";

        public GroupData(string groupName_Parametr)
        {
            Name = groupName_Parametr;
        }

        public bool Equals(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this,other))
            {
                return true;
            }
            return Name == other.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
        public override string ToString()
        {
            return "name="+Name;
        }
        public int CompareTo(GroupData other)
        {
            if (Object.ReferenceEquals(other,null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }

        public string GroupName_Property
        {
            get { return Name; }
            set { Name = value; }
        }
        public string GroupHeader_Property
        {
            get { return Header; }
            set { Header = value; }
        }
        public string GroupFooter_Property
        {
            get { return Footer; }
            set { Footer = value; }
        }

    }
}
