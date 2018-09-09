using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager) { }

        public ContactHelper Create(ContactData contact)
        {
            InitContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();
            ReturnToHomePage();
            return this;
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(index);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string fax = driver.FindElement(By.Name("fax")).GetAttribute("value");
            string email1 = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");
            string homepageValue = driver.FindElement(By.Name("homepage")).GetAttribute("value");

            return new ContactData(lastName, firstName)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Fax = fax,
                Email1 = email1,
                Email2 = email2,
                Email3 = email3,
                HomePageValue = homepageValue,
            };
        }

        private void InitContactModification(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allPhones = cells[5].Text;
            string allEmails = cells[4].Text;
            //string homePageLink = cells[9].FindElement(By.TagName("a")).GetAttribute("title");
            string homePageLink = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[9].FindElement(By.TagName("a")).GetAttribute("href");


            return new ContactData(lastName, firstName)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmails = allEmails,
                HomePageLink = homePageLink
            };
        }


        //public ContactHelper ModifyIfPresent (int index, ContactData newData, ContactData defaultData)
        //{
        //    manager.Navigator_Property.GoToContactPage();
        //    if (IsAnyContactPresent() == false)
        //    {
        //        Create(defaultData);
        //        manager.Navigator_Property.GoToContactPage();
        //    }
        //    SelectModifyContact(index);
        //    FillContactForm(newData);
        //    SubmitContactModification();
        //    ReturnToHomePage();
        //    return this;
        //}

        public bool IsAnyContactPresent()
        {
            manager.Navigator.GoToContactPage();
            return IsElementPresent(By.XPath("(//img[@alt='Edit'])"));
        }

        
         public ContactHelper Modify (int index, ContactData newData)
         {
             manager.Navigator.GoToContactPage();
             SelectModifyContact(index);
             FillContactForm(newData);
             SubmitContactModification();
             ReturnToHomePage();
             return this;            
         }


        //public ContactHelper RemovePresent(int index, ContactData defaultData)
        //{
        //    manager.Navigator_Property.GoToContactPage();
        //    if (IsAnyContactPresent() == false)
        //    {
        //        Create(defaultData);
        //        manager.Navigator_Property.GoToContactPage();
        //    }
        //    SelectExistingContact(index);
        //    InitContactRemoval();
        //    ConfirmContactRemoval();
        //    manager.Navigator_Property.GoToHomePage();
        //    return this;
        //}

        
        public ContactHelper Remove(int index)
        {
            manager.Navigator.GoToContactPage();
            SelectExistingContact(index);
            InitContactRemoval();
            ConfirmContactRemoval();
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }


        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.FirstName);
            Type(By.Name("lastname"), contact.SecondName);
            Type(By.Name("middlename"), contact.MiddleName);
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper SelectModifyContact(int index)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + (index+1) + "]")).Click();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper SelectExistingContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + 1 + "]")).Click();
            return this;
        }

        public ContactHelper InitContactRemoval()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }

        public ContactHelper ConfirmContactRemoval()
        {
            driver.SwitchTo().Alert().Accept();
            contactCache = null;
            return this;
        }

        public ContactHelper ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }

        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.GoToContactPage();
                ICollection<IWebElement> elementsLast = driver.FindElements(By.XPath("(//tr[@name='entry'])"));

                int i = 0;

                foreach (IWebElement element in elementsLast)
                {
                    i = i + 1;
                    string last = driver.FindElement(By.XPath("(//tr[@name='entry'][" + i + "]//td[2])")).Text;

                    string first = driver.FindElement(By.XPath("(//tr[@name='entry'][" + i + "]//td[3])")).Text;
                    //System.Console.Out.Write(first);

                    contactCache.Add(new ContactData(last, first));
                }
            }
            return new List<ContactData>(contactCache);
        }


    }
}
