using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests_Namespace
{
    [TestFixture]
    public class GroupCreationTests_Class : TestBase_Class
    {
        [Test]
        public void GroupCreationTest_Method()
        {
            GoToHomePage_AdditMethod();
            Login_AdditMethod(new AccountData_Class("admin","secret"));
            GoToGroupsPage_AdditMethod();
            InitNewGroupCreation_AdditMethod();
            GroupData_Class group = new GroupData_Class("Name_Value");
            group.GroupHeader_Property = "Header_Value";
            group.GroupFooter_Property = "Footer_Value";
            FillGroupForm_AdditMethod(group);
            SubmitGroupCreation_AdditMethod();
            ReturnToGroupsPage_AdditMethod();
            Logout_AdditMethod();
        }
    }
}
