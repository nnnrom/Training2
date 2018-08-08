using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class TestBase
    {
        protected ApplicationManager app;

        [SetUp]
        public void SetupTest()
        {
            app = new ApplicationManager();
            app.Navigator_Property.GoToHomePage();
            app.Auth_Property.Login(new AccountData("admin", "secret"));
        }

        [TearDown]
        public void TearDown()
        {
            app.Stop();
        }
    }
}
