using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests_Namespace
{
    public class TestBase_Class
    {
        protected IWebDriver driver;
        private StringBuilder verificationErrors;
        protected string baseURL;

        [SetUp]
        public void SetupTest_Method()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.BrowserExecutableLocation = @"c:\Program Files\Mozilla Firefox\firefox.exe";
            options.UseLegacyImplementation = false;
            driver = new FirefoxDriver(options);
            baseURL = "http://localhost/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest_Method()
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



        protected void GoToHomePage_AdditMethod()
        {
            // Open homepage. No needs in comment due to Name of Method is enough 
            driver.Navigate().GoToUrl(baseURL + "addressbook/group.php");
        }

        protected void Login_AdditMethod(AccountData_Class account)
        {
            driver.FindElement(By.Name("user")).Clear();
            driver.FindElement(By.Name("user")).SendKeys(account.Username_Property);
            driver.FindElement(By.Name("pass")).Clear();
            driver.FindElement(By.Name("pass")).SendKeys(account.Password_property);
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }

        protected void GoToGroupsPage_AdditMethod()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }

        protected void ReturnToGroupsPage_AdditMethod()
        {
            driver.FindElement(By.LinkText("group page")).Click();
        }

        protected void InitNewGroupCreation_AdditMethod()
        {
            driver.FindElement(By.Name("new")).Click();
        }

        protected void FillGroupForm_AdditMethod(GroupData_Class group)
        {
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys(group.GroupName_Property);
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(group.GroupHeader_Property);
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(group.GroupFooter_Property);
        }

        protected void SubmitGroupCreation_AdditMethod()
        {
            driver.FindElement(By.Name("submit")).Click();
        }
        
        protected void SelectExistingGroup_AdditMethod(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
        }

        protected void RemoveSelectedGroup_AdditMethod()
        {
            driver.FindElement(By.Name("delete")).Click();
        }

        protected void InitContactCreation_AdditMethod()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }

        protected void FillContactForm_AdditMethod(ContactData_Class contact)
        {
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.ContactFirstName_Property);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.ContactLastName_Property);
        }

        protected void SubmitContactCreation_AdditMethod()
        {
            driver.FindElement(By.Name("submit")).Click();
        }
        
        protected void Logout_AdditMethod()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }
    }
}
