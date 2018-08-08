using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests:TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("NewName");
            newData.GroupHeader_Property = "NewHeader";
            newData.GroupFooter_Property = "NewFooter";

            app.Groups_Property.Modify(1, newData);
        }
    }
}
