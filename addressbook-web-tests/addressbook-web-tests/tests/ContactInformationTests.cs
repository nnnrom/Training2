﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            ContactData fromTable = app.Contact_Property.GetContactInformationFromTable(0);
            ContactData fromForm = app.Contact_Property.GetContactInformationFromEditForm(0);
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.LastName, fromForm.LastName);
            Assert.AreEqual(fromTable.FirstName, fromForm.FirstName);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.HomePageLink, fromForm.HomePageLink);
        }
    }
}