using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
    {
    [TestFixture]
    public class ContactCreationIfExistsTests : AuthTestBase
    {
        [Test]
        public void ContactCreationIfExistsTest()
        {

            ContactData contact = new ContactData("newLastName", "newFirstName");
            //contact.ContactMiddleName_Property = "MiddleName_Value";

            app.Contact_Property.CreateIfExists(contact);
        }
    }
}
