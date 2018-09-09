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
            if (app.Groups.IsAnyGroupPresent() == false)
            {
                GroupData defaultData = new GroupData("DefaultName");
                defaultData.Header = "DefaultHeader";
                defaultData.Footer = "DefaultFooter";
                                
                app.Groups.Create(defaultData);
            }

            GroupData newData = new GroupData("NewName");
            newData.Header = null;
            newData.Footer = "NewFooter";

            app.Groups.Modify(0, newData);
        }

        
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("NewName");
            newData.Header = null;
            newData.Footer = "NewFooter";

            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData oldData = oldGroups[0];
            app.Groups.Modify(0, newData);
            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
            Assert.AreEqual(oldGroups.Count, newGroups.Count);
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }
        }
    }
}
