using SeleniumTests.Base;
using Newtonsoft.Json;
using SeleniumTests.WebDriver;
using System;

namespace SeleniumTests.Config
{
    [JsonObject("testSettings")]
    public class TestSettings
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("sut")]
        public Sut SUT { get; set; }

        [JsonProperty("browser")]
        public BrowserType Browser { get; set; }

        [JsonProperty("testType")]
        public string TestType { get; set; }

        [JsonProperty("isLog")]
        public string IsLog { get; set; }

        [JsonProperty("logPath")]
        public string LogPath { get; set; }

        [JsonProperty("autConnectionString")]
        public string AUTConnectionString { get; set; }

        [JsonProperty("mobileDevice")]
        public string MobileDevice { get; set; }
    }
    public partial class Sut
    {
        [JsonProperty("dev")]
        public Uri DEV { get; set; }

        [JsonProperty("qa")]
        public Uri QA { get; set; }

        [JsonProperty("localhost")]
        public Uri Localhost { get; set; }

        [JsonProperty("AWS")]
        public Uri AWS { get; set; }

        [JsonProperty("prod")]
        public Uri PROD { get; set; }
    }
}
