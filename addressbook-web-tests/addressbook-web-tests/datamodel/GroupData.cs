using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class GroupData
    {
        private string Name;
        private string Header="";
        private string Footer = "";

        public GroupData(string groupName_Parametr)
        {
            Name = groupName_Parametr;
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
