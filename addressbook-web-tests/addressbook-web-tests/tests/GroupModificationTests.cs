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
            if (app.Groups_Property.IsAnyGroupPresent() == false)
            {
                GroupData defaultData = new GroupData("DefaultName");
                defaultData.GroupHeader_Property = "DefaultHeader";
                defaultData.GroupFooter_Property = "DefaultFooter";
                                
                app.Groups_Property.Create(defaultData);
            }

            GroupData newData = new GroupData("NewName");
            newData.GroupHeader_Property = null;
            newData.GroupFooter_Property = "NewFooter";

            app.Groups_Property.Modify(1, newData);
        }

        
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("NewName");
            newData.GroupHeader_Property = null;
            newData.GroupFooter_Property = "NewFooter";

            List<GroupData> oldGroups = app.Groups_Property.GetGroupList();
            app.Groups_Property.Modify(1, newData);
            List<GroupData> newGroups = app.Groups_Property.GetGroupList();
            Assert.AreEqual(oldGroups.Count, newGroups.Count);
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
