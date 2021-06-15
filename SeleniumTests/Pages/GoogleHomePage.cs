using OpenQA.Selenium;
using System;
using SeleniumTests.Base;
using SeleniumTests.Extensions;

namespace SeleniumTests.Pages
{
    public class GoogleHomePage : BasicPage
    {
        private IWebElement SearchField => Find("//input[@name = 'q']");
        private IWebElement SearchButton => Find("//input[@name = 'btnK']");

        internal void InputSearchValue() => SearchField.SendKeys("London");
        internal void ClickOnSearchButton() => SearchButton.Click();
    }
}
