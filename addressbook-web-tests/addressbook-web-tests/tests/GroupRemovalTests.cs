using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void PresentGroupRemovalTest()
        {
            if (app.Groups_Property.IsAnyGroupPresent() == false)
            {
                GroupData defaultData = new GroupData("DefaultName");
                defaultData.GroupHeader_Property = "DefaultHeader";
                defaultData.GroupFooter_Property = "DefaultFooter";

                app.Groups_Property.Create(defaultData);
            }

            List<GroupData> oldGroups = app.Groups_Property.GetGroupList();
            app.Groups_Property.Remove(1);
            List<GroupData> newGroups = app.Groups_Property.GetGroupList();
            Assert.AreEqual(oldGroups.Count - 1, newGroups.Count);
            oldGroups.RemoveAt(0);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        
        [Test]
        public void GroupRemovalTest()
        {
            List<GroupData> oldGroups = app.Groups_Property.GetGroupList();
            app.Groups_Property.Remove(1);
            List<GroupData> newGroups = app.Groups_Property.GetGroupList();
            Assert.AreEqual(oldGroups.Count - 1, newGroups.Count);
            oldGroups.RemoveAt(0);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        
    }
}
