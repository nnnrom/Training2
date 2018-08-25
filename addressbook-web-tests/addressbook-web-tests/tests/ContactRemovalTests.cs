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
        public void ContactRemovalTest()
        {
            if (app.Contact_Property.IsAnyContactPresent() == false)
            {
                ContactData defaultData = new ContactData("default_LastName", "default_LastName");
                defaultData.MiddleName_Property = null;

                app.Contact_Property.Create(defaultData);
            }

            app.Contact_Property.Remove(1);
        }

        //delete
        //[Test]
        //public void ContactRemovalTest()
        //{
        //    app.Contact_Property.Remove(1);
        //}
    }
}
