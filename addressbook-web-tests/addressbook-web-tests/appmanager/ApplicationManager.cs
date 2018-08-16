﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;

        protected LoginHelper loginHelper;
        protected NavigationHelper navigator;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.BrowserExecutableLocation = @"c:\Program Files\Mozilla Firefox\firefox.exe";
            options.UseLegacyImplementation = false;
            driver = new FirefoxDriver(options);
            baseURL = "http://localhost/";

            loginHelper = new LoginHelper(this);
            navigator = new NavigationHelper(this, baseURL);
            groupHelper = new GroupHelper(this);
            contactHelper = new ContactHelper(this);
        }

        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

            public static ApplicationManager GetInstance()
        {
            if (! app.IsValueCreated)
            {
                //app.Value = new ApplicationManager();
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.navigator.GoToHomePage();
                app.Value = newInstance;
                //app.Navigator_Property.GoToHomePage();
            }
            return app.Value;
        }

        public IWebDriver Driver
        { get { return driver; } }

        public LoginHelper Auth_Property
        { get { return loginHelper; } }

        public NavigationHelper Navigator_Property
        { get { return navigator; } }

        public GroupHelper Groups_Property 
            {get {return groupHelper;} }

        public ContactHelper Contact_Property
        { get { return contactHelper; } }
    }
}
