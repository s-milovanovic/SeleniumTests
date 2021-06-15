using NUnit.Framework;
using SeleniumTests.Config;
using SeleniumTests.Data;
using SeleniumTests.Hooks;
using SeleniumTests.Pages;

namespace SasoMangeTests.Tests
{
    public class UserLoginTest : InitializeHooks
    {
        [Test]
        public void GoogleInputResultsTest()
        {
            GoogleHomePage homePage = new GoogleHomePage();
            homePage.InputSearchValue();
            homePage.ClickOnSearchButton();
        }
    }
}
