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
            ContactData defaultData = new ContactData("default_LastName", "default_LastName");
            defaultData.MiddleName_Property = null;

            app.Contact_Property.RemovePresent(1,defaultData);
        }

        //delete
        //[Test]
        //public void ContactRemovalTest()
        //{
        //    app.Contact_Property.Remove(1);
        //}
    }
}
