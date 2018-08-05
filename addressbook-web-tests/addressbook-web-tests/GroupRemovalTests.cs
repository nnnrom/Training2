using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests_Namespace
{
    [TestFixture]
    public class GroupRemovalTests_Class : TestBase_Class
    {
        [Test]
        public void GroupRemovalTests_Method()
        {
            GoToHomePage_AdditMethod();
            Login_AdditMethod(new AccountData_Class("Admin","secret"));
            GoToGroupsPage_AdditMethod();
            SelectExistingGroup_AdditMethod(1);
            RemoveSelectedGroup_AdditMethod();
            ReturnToGroupsPage_AdditMethod();
        }
    }
}
