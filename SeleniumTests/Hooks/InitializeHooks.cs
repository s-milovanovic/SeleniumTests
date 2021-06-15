using NUnit.Framework;
using SeleniumTests.Base;
using SeleniumTests.Reporter;
using SeleniumTests.WebDriver;

namespace SeleniumTests.Hooks
{
    public class InitializeHooks : TestInitializeHook
    {
        public InitializeHooks()
        {
            InitializeSettings();
            NavigateToWebsite();
        }

        [TearDown]
        public void TearDown()
        {
            Report.ReportTestOutcome();
            //DriverContext.CloseAndQuit();
        }
    }
     
}
