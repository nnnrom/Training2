﻿using System;
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
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("LastName_newValue", "FirstName_newValue");
            newData.MiddleName_Property = null;

            app.Contact_Property.Modify(1, newData);
        }
    }
}
