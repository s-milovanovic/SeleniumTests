using OpenQA.Selenium;

namespace SeleniumTests.WebDriver
{
    public class Browsers
    {
        public BrowserType Type { get; set; }
    }
    public enum BrowserType
    {
        InternetExplorer,
        FireFox,
        Chrome
    }
}
