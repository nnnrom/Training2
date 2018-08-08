using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("Name_Value");
            group.GroupHeader_Property = "Header_Value";
            group.GroupFooter_Property = "Footer_Value";

            app.Groups_Property.Create(group);
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("");
            group.GroupHeader_Property = "";
            group.GroupFooter_Property = "";

            app.Groups_Property.Create(group);
        }
    }
}
