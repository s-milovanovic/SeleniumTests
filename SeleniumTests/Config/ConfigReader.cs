
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using SeleniumTests.WebDriver;
using System;
using System.IO;
using System.Xml;
using System.Xml.XPath;

namespace SeleniumTests.Config
{
    public class ConfigReader
    {
        public static void SetFrameworkSettings()
        {
            /*var builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json");

            IConfigurationRoot configurationRoot = builder.Build();*/

            //Settings.SUT = configurationRoot.GetSection("testSettings").Get<TestSettings>().SUT.QA.ToString();
            //Settings.TestType = configurationRoot.GetSection("testSettings").Get<TestSettings>().TestType;
            //Settings.BrowserType = configurationRoot.GetSection("testSettings").Get<TestSettings>().Browser;
            //Settings.MobileDevice = configurationRoot.GetSection("testSettings").Get<TestSettings>().MobileDevice;
            var _browserType = TestContext.Parameters.Get("Browser");
            System.Console.WriteLine("BrowserType: " + _browserType);
            Settings.SUT = TestContext.Parameters.Get("Sut", "https://www.google.com");
            Settings.BrowserType = (BrowserType)Enum.Parse(typeof(BrowserType), _browserType);
            Settings.HeadlessMode = TestContext.Parameters.Get("HeadlessMode", false);
            Settings.MobileDevice = TestContext.Parameters.Get("MobileDevice", null);
        }
    }
}
