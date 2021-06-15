using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using SeleniumTests.WebDriver;

namespace SeleniumTests.Extensions
{

    public static class ElementExtensions
    {
        public static string ReadContent(this IWebElement element)
        {
            //IJavaScriptExecutor js = (IJavaScriptExecutor)WebDriver.Driver;
            //return js.ExecuteScript("return arguments[0].textContent;", element).ToString();
            return element.ReadText();
        }    
        public static void ScrollIntoView(this IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)DriverContext.Driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }
        public static string ReadText(this IWebElement element)
        {
            //return element.GetAttribute("innerText"); // work for textContent also
            return element.Text;
            /*IJavaScriptExecutor js = (IJavaScriptExecutor)WebDriver.driver;
            return js.ExecuteScript("return arguments[0].innerText;", element).ToString();*/
        }
        public static void ClickOnElementJS(this IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)DriverContext.Driver;
            js.ExecuteScript("arguments[0].click()", element);
        }
        public static void EnterValue(this IWebElement element, string text)
        {
            element.SendKeys(Keys.Backspace);
            element.Clear();
            element.SendKeys(text);
            element.SendKeys(Keys.Enter);
        }
        public static string GetSelectedDropDown(this IWebElement element)
        {
            SelectElement ddl = new SelectElement(element);
            return ddl.AllSelectedOptions.First().ToString();
        }

        public static void ZoomOut()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)DriverContext.Driver;
            js.ExecuteScript("document.body.style.zoom = '0.5'");
        }

        public static IList<IWebElement> GetSelectedListOptions(this IWebElement element)
        {
            SelectElement ddl = new SelectElement(element);
            return ddl.AllSelectedOptions;
        }

        public static void Hover (this IWebElement element)
        {
            Actions actions = new Actions(DriverContext.Driver);
            actions.MoveToElement(element).Perform();
        }

        public static void SelectDropDownList(this IWebElement element, string value)
        {
            SelectElement ddl = new SelectElement(element);
            ddl.SelectByText(value);
        }

        public static bool AssertElementPresent(this IWebElement element)
        {
            return IsElementPresent(element) ? true : throw new Exception(string.Format("Element not present exception"));
        }
        public static void FocusOnElementAndClick(this IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)DriverContext.Driver;
            js.ExecuteScript("window.focus();");
            Actions actions = new Actions(DriverContext.Driver);
            actions.MoveToElement(element).Click().Perform();
        }
        public static void FocusOnElement(this IWebElement element)
        {
            /*IJavaScriptExecutor js = (IJavaScriptExecutor)DriverContext.Driver;
            js.ExecuteScript("window.focus();");*/
            Actions actions = new Actions(DriverContext.Driver);
            actions.MoveToElement(element).Perform();
        }
        public static string FocusOnElementAndRead(this IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)DriverContext.Driver;
            js.ExecuteScript("window.focus();");
            Actions actions = new Actions(DriverContext.Driver);
            actions.MoveToElement(element).Perform();
            return element.ReadContent();
        }
        public static void FocusOnElementJS(this IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)DriverContext.Driver;
            element.SendKeys(Keys.Shift);
            js.ExecuteScript("element.focus();");
        }

        public static bool IsElementPresent(this IWebElement element)
        {
            try
            {
                bool el = element.Displayed;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
