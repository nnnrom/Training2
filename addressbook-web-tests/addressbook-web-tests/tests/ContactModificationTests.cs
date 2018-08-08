using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("LastName_newValue", "FirstName_newValue");
            newData.ContactMiddleName_Property = "MiddleName_newValue";

            app.Contact_Property.Modify(2, newData);
        }
    }
}
