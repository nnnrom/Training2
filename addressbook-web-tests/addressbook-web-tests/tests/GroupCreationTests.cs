using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("Name_Value");
            group.GroupHeader_Property = "Header_Value";
            group.GroupFooter_Property = "Footer_Value";

            List<GroupData> oldGroups = app.Groups_Property.GetGroupList();
            app.Groups_Property.Create(group);
            List<GroupData> newGroups = app.Groups_Property.GetGroupList();

            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);

            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void BadNameGroupCreationTest()
        {
            GroupData group = new GroupData("a'a");
            group.GroupHeader_Property = "";
            group.GroupFooter_Property = "";

            List<GroupData> oldGroups = app.Groups_Property.GetGroupList();
            app.Groups_Property.Create(group);
            List<GroupData> newGroups = app.Groups_Property.GetGroupList();

            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);

            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("");
            group.GroupHeader_Property = "";
            group.GroupFooter_Property = "";

            List<GroupData> oldGroups = app.Groups_Property.GetGroupList();
            app.Groups_Property.Create(group);
            List<GroupData> newGroups = app.Groups_Property.GetGroupList();

            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);

            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
