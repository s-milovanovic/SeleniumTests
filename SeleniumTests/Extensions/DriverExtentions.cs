using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using SeleniumTests.Base;
using SeleniumTests.WebDriver;
using System.Collections.ObjectModel;
using System.Linq;

namespace SeleniumTests.Extensions
{
    public static class DriverExtensions
    {
        public static void WaitForPageLoaded(this IWebDriver driver)
        {
            driver.WaitForCondition(dri =>
            {
                string state = dri.ExecuteJs("return document.readyState").ToString();
                return state == "complete";

            }, 10);
        }
        public static void WaitForCondition<T>(this T obj, Func <T, bool> condition, int timeOut)
        {
            bool execute(T arg)
            {
                try
                {
                    return condition(arg);
                }
                catch (Exception)
                {

                    return false;
                }
            }
            var stopWatch = Stopwatch.StartNew();
            while (stopWatch.ElapsedMilliseconds < timeOut)
            {
                if (execute(obj))
                {
                    break;
                }
            }
        }
        internal static ReadOnlyCollection<IWebElement> FindElements(IWebDriver driver, string xpath, string className)
        {
            if (!string.IsNullOrEmpty(xpath))
                return driver.FindElements(By.XPath(xpath));
            return driver.FindElements(By.ClassName(className));
        }
        internal static object ExecuteJs(this IWebDriver driver, string script)
        {
            return ((IJavaScriptExecutor)DriverContext.Driver).ExecuteScript(script);
        }
        public static void OpenNewTab()
        {
            ExecuteJs(DriverContext.Driver, "window.open();");
        }
        public static void SwitchToLastTab(IWebDriver driver)
        {
            driver.SwitchTo().Window(driver.WindowHandles.Last());
        }
        public static void SwitchToFirstTab(IWebDriver driver)
        {
            driver.SwitchTo().Window(driver.WindowHandles.First());
        }
        public static IWebElement FindElement(string xpath, string className, int timeout)
        {
            return FindAndWait(DriverContext.Driver, xpath, className, timeout);
        }
        private static IWebElement FindAndWait(IWebDriver driver, string xpath, string className, int timeout)
        {
            // Install-Package DotNetSeleniumExtras.WaitHelpers -Version 3.11.0

            if (timeout > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(WebDriverTimeoutException));
                if (!string.IsNullOrEmpty(xpath))
                    return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName(className)));
            }
            if (!string.IsNullOrEmpty(xpath))
                return driver.FindElement(By.XPath(xpath));
            return driver.FindElement(By.ClassName(className));
        }
        public static void NavigateToPreviousPage()
        {
            DriverContext.Driver.Navigate().Back();
        }
    }
}
