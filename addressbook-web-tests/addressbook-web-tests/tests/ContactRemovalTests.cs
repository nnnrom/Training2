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
            if (app.Contact_Property.IsAnyContactPresent() == false)
            {
                ContactData defaultData = new ContactData("default_LastName", "default_LastName");
                defaultData.MiddleName_Property = null;

                app.Contact_Property.Create(defaultData);
            }

            app.Contact_Property.Remove(1);
        }

        [Test]
        public void ContactRemovalTest()
        {
            List<ContactData> oldContacts = app.Contact_Property.GetContactList();
            app.Contact_Property.Remove(1);
            List<ContactData> newContacts = app.Contact_Property.GetContactList();

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
