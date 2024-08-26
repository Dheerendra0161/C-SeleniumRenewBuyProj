using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumC_WebTesting.TestData
{
    public class TestConfig
    {
        public static string BaseUrl => Environment.GetEnvironmentVariable("BASE_URL") ?? "https://www.renewbuyinsurance.com";
    }
}
    

