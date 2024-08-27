using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumC_WebTesting.TestData
{
    public static class TestConfig
    {
        // Property to get the base URL from an environment variable or use a default value
        public static string BaseUrl => Environment.GetEnvironmentVariable("BASE_URL") ?? "https://www.renewbuyinsurance.com";

        // Property to get the browser type from an environment variable or use a default value
        public static string Browser => Environment.GetEnvironmentVariable("BROWSER")?? "Chrome";

    }
}


