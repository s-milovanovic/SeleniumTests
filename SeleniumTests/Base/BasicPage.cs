using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using SeleniumTests.Extensions;
using SeleniumTests.WebDriver;
using SeleniumTests.Reporter;
using System.Collections.ObjectModel;
using System.Linq;

namespace SeleniumTests.Base
{
    public abstract class BasicPage : Basic
    {     
        internal virtual IWebElement Find(string xpath = "", string className = "", int timeout = 0)
        {
            return DriverExtensions.FindElement(xpath, className, timeout);
        }
        internal virtual ReadOnlyCollection<IWebElement> Finds(string xpath = "", string className = "")
        {
            return DriverExtensions.FindElements(DriverContext.Driver, xpath, className);
        }
    }
}
