using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class LoginTests:TestBase
    {
        [Test]
        public void LoginWithaValidCredentials()
         {
            // prepare
            app.Auth_Property.Logout();

            //action
            AccountData account = new AccountData("admin", "secret");
            app.Auth_Property.Login(account);

            // verification
            Assert.IsTrue(app.Auth_Property.IsLoggedIn(account));
        }

        [Test]
        public void LoginWithAgainValidCredentials()
        {
            // prepare
            app.Auth_Property.Logout();

            //action
            AccountData account = new AccountData("admin", "secret");
            app.Auth_Property.Login(account);

            // verification
            Assert.IsTrue(app.Auth_Property.IsLoggedIn(account));
        }
        [Test]
        public void LoginWithAgainAgainValidCredentials()
        {
            // prepare
            app.Auth_Property.Logout();

            //action
            AccountData account = new AccountData("admin", "secret");
            app.Auth_Property.Login(account);
            
            // verification
            Assert.IsTrue(app.Auth_Property.IsLoggedIn(account));
        }
        [Test]
        public void LoginWithInvalidCredentials()
        {
            // prepare
            app.Auth_Property.Logout();

            //action
            AccountData account = new AccountData("admin", "123");
            app.Auth_Property.Login(account);

            // verification
            Assert.IsFalse(app.Auth_Property.IsLoggedIn(account));
        }
    }
}
