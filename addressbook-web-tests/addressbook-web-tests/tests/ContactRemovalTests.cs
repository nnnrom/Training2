using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void PresentContactRemovalTest()
        {
            if (app.Contacts.IsAnyContactPresent() == false)
            {
                ContactData defaultData = new ContactData("default_LastName", "default_LastName");
                defaultData.MiddleName = null;

                app.Contacts.Create(defaultData);
            }

            app.Contacts.Remove(0);
        }

        [Test]
        public void ContactRemovalTest()
        {
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.Remove(0);
            List<ContactData> newContacts = app.Contacts.GetContactList();

            Assert.AreEqual(oldContacts.Count - 1, newContacts.Count);

            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
            
        }

        //delete
        //[Test]
        //public void ContactRemovalTest()
        //{
        //    app.Contact_Property.Remove(1);
        //}
    }
}
