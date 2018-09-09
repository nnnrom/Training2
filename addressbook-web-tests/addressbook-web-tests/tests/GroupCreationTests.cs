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
            group.Header = "Header_Value";
            // ekranirivanie slash i kavichka, tabulyaciya i perevod stroki: group.Header = "\\\"\t\n";
            // verbatim stroki s @ bez ekranirovaniya: group.Header = @"d\d""
            //d";
            group.Footer = "Footer_Value";

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
            group.Header = "";
            group.Footer = "";

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
            group.Header = "";
            group.Footer = "";

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
