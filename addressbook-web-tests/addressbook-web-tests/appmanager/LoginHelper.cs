﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager) { }

        public LoginHelper Login(AccountData account)
        {
            Type(By.Name("user"), account.Username_Property);
            Type(By.Name("pass"), account.Password_property);
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
            return this;
        }
        public LoginHelper Logout()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
            return this;
        }
    }
}
