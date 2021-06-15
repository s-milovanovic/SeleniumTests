using System.Collections.Generic;
using System.IO;

namespace SeleniumTests.Data
{
    public static class DataReader
    {
        internal static void GetUserCredentials()
        {
            GetJsonString("UsersData.json");
        }
        public static string GetJsonString(string path)
        {
            StreamReader reader = new StreamReader(path);
            string jsonString = reader.ReadToEnd();
            return jsonString;
        }

    }
}
