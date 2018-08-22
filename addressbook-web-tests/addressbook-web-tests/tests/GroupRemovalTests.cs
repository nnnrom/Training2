using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void PresentGroupRemovalTest()
        {
            GroupData defaultData = new GroupData("DefaultName");
            defaultData.GroupHeader_Property = "DefaultHeader";
            defaultData.GroupFooter_Property = "DefaultFooter";

            app.Groups_Property.RemovePresent(1, defaultData);
        }

        //Delete
        //[Test]
        //public void GroupRemovalTest()
        //{
        //    app.Groups_Property.Remove(1);
        //}

        
    }
}
