using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests_Namespace
{
    [TestFixture]
    public class GroupCreationTests_Class
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest_AdditMethod()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.BrowserExecutableLocation = @"c:\Program Files\Mozilla Firefox\firefox.exe";
            options.UseLegacyImplementation = false;
            driver = new FirefoxDriver(options);
            baseURL = "http://localhost/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest_AdditMethod()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void GroupCreationTest_Method()
        {
            OpenHomePage_AdditMethod();
            Login_AdditMethod(new AccountData_Class("admin","secret"));
            GoToGroupsPage_AdditMethod();
            InitNewGroupCreation_AdditMethod();
            GroupData_Class group = new GroupData_Class("Name_Value");
            group.GroupHeader_Property = "Header_Value";
            group.GroupFooter_Property = "Footer_Value";
            FillGroupForm_AdditMethod(group);
            SubmitGroupCreation_AdditMethod();
            ReturnToGroupsPage_AdditMethod();
            Logout_AdditMethod();
        }

        private void Logout_AdditMethod()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }

        private void ReturnToGroupsPage_AdditMethod()
        {
            driver.FindElement(By.LinkText("group page")).Click();
        }

        private void SubmitGroupCreation_AdditMethod()
        {
            driver.FindElement(By.Name("submit")).Click();
        }

        private void FillGroupForm_AdditMethod(GroupData_Class group)
        {
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys(group.GroupName_Property);
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(group.GroupHeader_Property);
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(group.GroupFooter_Property);
        }

        private void InitNewGroupCreation_AdditMethod()
        {
            driver.FindElement(By.Name("new")).Click();
        }

        private void GoToGroupsPage_AdditMethod()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }

        private void Login_AdditMethod(AccountData_Class account)
        {
            driver.FindElement(By.Name("user")).Clear();
            driver.FindElement(By.Name("user")).SendKeys(account.Username_Property);
            driver.FindElement(By.Name("pass")).Clear();
            driver.FindElement(By.Name("pass")).SendKeys(account.Password_property);
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }

        private void OpenHomePage_AdditMethod()
        {
            // Open homepage. No needs in comment due to Name of Method is enough 
            driver.Navigate().GoToUrl(baseURL + "addressbook/group.php");
        }

        private bool IsElementPresent_AutoMethod(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent_AutoMethod()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText_AutoMethod()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
