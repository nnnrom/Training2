using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests_Namespace
    {
    [TestFixture]
    public class ContactCreationTests_Class : TestBase_Class
    {
        [Test]
        public void ContactCreationTests_Method()
        {
            GoToHomePage_AdditMethod();
            Login_AdditMethod(new AccountData_Class("admin","secret"));
            InitContactCreation_AdditMethod();

            ContactData_Class contact = new ContactData_Class("LastName_Value", "FirstName_Value");
            contact.ContactMiddleName_Property = "MiddleName_Value";

            FillContactForm_AdditMethod(contact);
            SubmitContactCreation_AdditMethod();
            GoToHomePage_AdditMethod();
            Logout_AdditMethod();
        }
    }
}
