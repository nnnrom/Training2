using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [SetUpFixture]
    public class TestSuiteFixture
    {
        //public static ApplicationManager app;

        [SetUp]
        public void InitApplicationManager()
        {
            //app = ApplicationManager.GetInstance
            ApplicationManager app = ApplicationManager.GetInstance();
            app.Navigator_Property.GoToHomePage();
            app.Auth_Property.Login(new AccountData("admin", "secret"));
        }

    }
}
