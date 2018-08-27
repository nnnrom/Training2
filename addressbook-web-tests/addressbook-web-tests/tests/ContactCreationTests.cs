using System;
using System.Collections.Generic;
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

            List<ContactData> oldContacts = app.Contact_Property.GetContactList();
            app.Contact_Property.Create(contact);
            List<ContactData> newContacts = app.Contact_Property.GetContactList();
            
            Assert.AreEqual(oldContacts.Count + 1, newContacts.Count);
            
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

        }
    }
}
