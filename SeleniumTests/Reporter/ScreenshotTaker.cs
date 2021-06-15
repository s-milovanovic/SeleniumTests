using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumTests.WebDriver;

namespace SeleniumTests.Reporter
{
    public class ScreenshotTaker
    {
        private readonly string filename;

        public ScreenshotTaker()
        {
            filename = TestContext.CurrentContext.Test.MethodName + "_" + System.Guid.NewGuid().ToString().Substring(0, 7);
        }

        public string FullFileName { get; private set; }
        
        public bool TakeScreenshotForFailure()
        {
            return TryToSaveScreenshot(GetScreenshot());
        }
        
        private bool TryToSaveScreenshot(Screenshot ss)
        {
            try
            {
                SaveScreenshot(filename, ss);
                return true;
            }
            catch
            {                
                return false;
            }
        }

        private void SaveScreenshot(string screenshotName, Screenshot ss)
        {
            if (ss == null)
                return;

            var filepath = $"{Report.FullPath}\\{screenshotName}.jpg";
            filepath = filepath.Replace('/', ' ').Replace('"', ' ');
            ss.SaveAsFile(filepath, ScreenshotImageFormat.Png);

            FullFileName = filepath;
        }

        private static Screenshot GetScreenshot()
        {
            return ((ITakesScreenshot)DriverContext.Driver)?.GetScreenshot();
        }
    }
}