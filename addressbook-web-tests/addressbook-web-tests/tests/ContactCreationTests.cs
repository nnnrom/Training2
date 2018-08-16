using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
    {
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {

            ContactData contact = new ContactData("newLastName", "newFirstName");
            //contact.ContactMiddleName_Property = "MiddleName_Value";

            app.Contact_Property.Create(contact);
        }
    }
}
