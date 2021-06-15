using OpenQA.Selenium;

namespace SeleniumTests.WebDriver
{
    public static class DriverContext
    {

        private static IWebDriver _driver;

        public static IWebDriver Driver
        {
            get
            {
                return _driver;
            }
            set
            {
                _driver = value;
            }
        }

        public static Browsers Browser { get; set; }

        public static void GoToUrl(string url)
        {
            Driver.Url = url;
        }

        internal static void CloseAndQuit()
        {
            if (Driver == null)
                return;

            Driver.Close();
            Driver.Quit();
            _driver = null;
        }
    }
}
