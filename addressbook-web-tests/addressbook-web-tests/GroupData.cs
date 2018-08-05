using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests_Namespace
{
    public class GroupData_Class
    {
        private string groupName_Field;
        private string groupHeader_Field="";
        private string groupFooter_Field = "";

        public GroupData_Class(string groupName_Parametr)
        {
            groupName_Field = groupName_Parametr;
        }

        public string GroupName_Property
        {
            get { return groupName_Field; }
            set { groupName_Field = value; }
        }
        public string GroupHeader_Property
        {
            get { return groupHeader_Field; }
            set { groupHeader_Field = value; }
        }
        public string GroupFooter_Property
        {
            get { return groupFooter_Field; }
            set { groupFooter_Field = value; }
        }

    }
}
