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
                defaultData.MiddleName_Property = null;

                app.Contact_Property.Create(defaultData);
            }

            ContactData newData = new ContactData("new_LastName", "new_FirstName");
            newData.MiddleName_Property = "new_MiddleName";
                        
            app.Contact_Property.Modify(1, newData);
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
