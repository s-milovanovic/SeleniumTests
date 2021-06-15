using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using SeleniumTests.Config;
using SeleniumTests.Base;
using OpenQA.Selenium;
using System;
using SeleniumTests.WebDriver;
using OpenQA.Selenium.Remote;

namespace SeleniumTests.Hooks
{
    public abstract class TestInitializeHook : Basic
    {
        public static bool HeadlessMode { get; set; } = true;
        public static void InitializeSettings()
        {
            //Set all the settings for framework
            ConfigReader.SetFrameworkSettings();

            //OpenBrowser
            OpenBrowser(GetBrowserOption(Settings.BrowserType)
                , Settings.HeadlessMode
                , Settings.MobileDevice);
        }

        public virtual void NavigateToWebsite()
        {
            DriverContext.GoToUrl(Settings.SUT);
        }

        private static void OpenBrowser(DriverOptions driverOptions, bool headlessMode, string mobileDevice = null)
        {
            //Istantiate Web Driver based on browser type
            switch (driverOptions)
            {
                case InternetExplorerOptions internetExplorerOptions:
                    //ToDo: Set the Desired capabilities
                    DriverContext.Driver = new InternetExplorerDriver(internetExplorerOptions);
                    break;
                case FirefoxOptions firefoxOptions:
                    firefoxOptions.Profile = new FirefoxProfile();
                    /*firefoxOptions.AddAdditionalCapability(CapabilityType.BrowserName, "firefox");
                    firefoxOptions.AddAdditionalCapability(CapabilityType.Platform, new Platform(PlatformType.Windows));
                    firefoxOptions.BrowserExecutableLocation = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";*/
                    DriverContext.Driver = new FirefoxDriver(firefoxOptions);
                    break;
                case ChromeOptions chromeOptions:
                    if (!string.IsNullOrEmpty(mobileDevice))
                    {
                        chromeOptions.EnableMobileEmulation(mobileDevice);                       
                    }
                    else
                    {
                        ChromeOptions(chromeOptions, headlessMode);
                    }
                    DriverContext.Driver = new ChromeDriver(chromeOptions);
                    break;
            }
        }

        private static void ChromeOptions(ChromeOptions chromeOptions, bool headlessMode)
        {
            chromeOptions.AddArgument("start-maximized");
            chromeOptions.AddArgument("ignore-certificate-errors");
            chromeOptions.AddArgument("disable-popup-blocking");
            chromeOptions.AddArgument("disable-infobars");
            chromeOptions.AddArgument("disable-notifications");
            chromeOptions.AddArgument("disable-extensions");
            chromeOptions.AddArgument("no-sandbox");

            if (headlessMode)
                chromeOptions.AddArgument("--headless");
            //options.AddUserProfilePreference("download.default_directory", Consts.DOWNLOAD_FOLDER);
            //chromeOptions.AddUserProfilePreference("download.prompt_for_download", false);
            //chromeOptions.AddUserProfilePreference("profile.default_content_setting_values.automatic_downloads", 1);
            //options.AddUserProfilePreference("disable-popup-blocking", "true");
        }

        public static DriverOptions GetBrowserOption(BrowserType browserType) => browserType switch
        {
            //Istantiate Driver options based on browser type
            BrowserType.InternetExplorer => new InternetExplorerOptions(),
            BrowserType.FireFox => new FirefoxOptions(),
            BrowserType.Chrome => new ChromeOptions(),
            _ => throw new ArgumentNullException(nameof(browserType))
        };
    }
}
