using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumTests.Helper
{
    public static class Helpers
    {
        internal static string Humanize(string methodName)
        {
            return methodName.Replace('_', ' ');
        }
        internal static int Percent(int a, int b)
        {
            int result;
            if(a > 0)
            {
                result = (b - a) * 100 / a;
            }
            else
            {
                result = 0;
            }
            return result;
        }
    }
}
