using SeleniumTests.WebDriver;

namespace SeleniumTests.Config
{
    public class Settings
    {
        public static bool HeadlessMode { get; set; }
        public static string TestType { get; set; }
        public static string SUT { get; set; }
        public static string Build { get; set; }
        public static BrowserType BrowserType { get; set; }
        public static string IsLog { get; set; }
        public static string LogPath { get; set; }
        public static string MobileDevice { get; set; }
    }
}
