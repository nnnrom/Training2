using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests:AuthTestBase
    {
        [Test]
        public void PresentGroupModificationTest()
        {
            GroupData newData = new GroupData("NewName");
            newData.GroupHeader_Property = null;
            newData.GroupFooter_Property = "NewFooter";

            GroupData defaultData = new GroupData("DefaultName");
            defaultData.GroupHeader_Property = "DefaultHeader";
            defaultData.GroupFooter_Property = "DefaultFooter";

            app.Groups_Property.ModifyPresent(1, newData, defaultData);
        }

        //delete
        //[Test]
        //public void GroupModificationTest()
        //{
        //    GroupData newData = new GroupData("NewName");
        //    newData.GroupHeader_Property = null;
        //    newData.GroupFooter_Property = "NewFooter";

        //    app.Groups_Property.Modify(1, newData);
        //}
    }
}
