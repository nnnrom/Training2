using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class AuthTestBase:TestBase
    {
        [SetUp]
        public void SetupLogin()
        {
            // убрали раньше app = TestSuiteFixture.app;
            // убираем app = ApplicationManager.GetInstance();
            app.Auth_Property.Login(new AccountData("admin", "secret"));
        }
    }
}
