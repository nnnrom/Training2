using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    class ContactModificationIfExistsTests : TestBase
    {
        [Test]
        public void ContactModificationIfExistsTest()
        {
            ContactData newData = new ContactData("LastName_newValue", "FirstName_newValue");
            newData.MiddleName_Property = null;

            app.Contact_Property.ModifyIfExists(1, newData);
        }
    }
}
