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
    public class ContactCreationTests_Class
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest_AutoMethod()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.BrowserExecutableLocation = @"c:\Program Files\Mozilla Firefox\firefox.exe";
            options.UseLegacyImplementation = false;
            driver = new FirefoxDriver(options);
            baseURL = "http://localhost/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest_AutoMethod()
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
        public void ContactCreationTests_Method()
        {
            GoToHomepage_AdditMethod();
            Login_AdditMethod(new AccountData_Class("admin","secret"));
            InitContactCreation_AdditMethod();

            ContactData_Class contact = new ContactData_Class("LastName_Value", "FirstName_Value");
            contact.ContactMiddleName_Property = "MiddleName_Value";

            FillContactForm_AdditMethod(contact);
            SubmitContactCreation_AdditMethod();
            GoToHomePage_AdditMethod();
            Logout_AdditMethod();
        }

        private void Logout_AdditMethod()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }

        private void GoToHomePage_AdditMethod()
        {
            driver.FindElement(By.LinkText("home page")).Click();
        }

        private void SubmitContactCreation_AdditMethod()
        {
            driver.FindElement(By.Name("submit")).Click();
        }

        private void FillContactForm_AdditMethod(ContactData_Class contact)
        {
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.ContactFirstName_Property);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.ContactLastName_Property);
        }

        private void InitContactCreation_AdditMethod()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }

        private void Login_AdditMethod(AccountData_Class account)
        {
            driver.FindElement(By.Name("user")).Clear();
            driver.FindElement(By.Name("user")).SendKeys(account.Username_Property);
            driver.FindElement(By.Name("pass")).Clear();
            driver.FindElement(By.Name("pass")).SendKeys(account.Password_property);
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }

        private void GoToHomepage_AdditMethod()
        {
            driver.Navigate().GoToUrl(baseURL + "addressbook/");
        }

        private bool IsElementPresent(By by)
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

        private bool IsAlertPresent()
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

        private string CloseAlertAndGetItsText()
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
