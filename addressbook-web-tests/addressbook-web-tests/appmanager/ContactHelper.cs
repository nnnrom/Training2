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
            manager.Navigator_Property.GoToContactPage();
            return IsElementPresent(By.XPath("(//img[@alt='Edit'])"));
        }

        
         public ContactHelper Modify (int index, ContactData newData)
         {
             manager.Navigator_Property.GoToContactPage();
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
            manager.Navigator_Property.GoToContactPage();
            SelectExistingContact(index);
            InitContactRemoval();
            ConfirmContactRemoval();
            manager.Navigator_Property.GoToHomePage();
            return this;
        }

        public ContactHelper InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }


        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.FirstName_Property);
            Type(By.Name("lastname"), contact.LastName_Property);
            Type(By.Name("middlename"), contact.MiddleName_Property);
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public ContactHelper SelectModifyContact(int index)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + index + "]")).Click();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public ContactHelper SelectExistingContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
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
            return this;
        }

        public ContactHelper ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }




    }
}
