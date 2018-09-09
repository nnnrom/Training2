using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void PresentContactModificationTest()
        {
            if (app.Contact_Property.IsAnyContactPresent() == false)
            {
                ContactData defaultData = new ContactData("default_LastName", "default_LastName");
                defaultData.MiddleName = null;

                app.Contact_Property.Create(defaultData);
            }

            ContactData newData = new ContactData("new_LastName", "new_FirstName");
            newData.MiddleName = "new_MiddleName";
                        
            app.Contact_Property.Modify(0, newData);


        }

        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("new_LastName", "new_FirstName");
            newData.MiddleName = "new_MiddleName";

            List<ContactData> oldContacts = app.Contact_Property.GetContactList();
            app.Contact_Property.Modify(0, newData);
            List<ContactData> newContacts = app.Contact_Property.GetContactList();

            Assert.AreEqual(oldContacts.Count, newContacts.Count);

            oldContacts[0].FirstName = newData.FirstName;
            oldContacts[0].LastName = newData.LastName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

        }

        //delete
        //[Test]
        //public void ContactModificationTest()
        //{
        //    ContactData newData = new ContactData("LastName_newValue", "FirstName_newValue");
        //    newData.MiddleName_Property = null;
        //
        //    app.Contact_Property.Modify(1, newData);
        //}
    }
}
