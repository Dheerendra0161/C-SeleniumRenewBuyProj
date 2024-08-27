using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using NUnit.Framework;
using System;
using SeleniumC_WebTesting.TestData;

namespace SeleniumC_WebTesting.Tests
{
    public class Base
    {
        protected IWebDriver driver;

        public IWebDriver SetUp()
        {
            string browser = TestConfig.Browser.ToLower(); // Get the browser from TestConfig

            switch (browser)
            {
                case "chrome":
                    driver = new ChromeDriver();
                    break;

                case "firefox":
                    driver = new FirefoxDriver();
                    break;

                case "edge":
                    driver = new EdgeDriver();
                    break;

                default:
                    throw new NotSupportedException($"{browser} is not a supported browser.");
            }

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(TestConfig.BaseUrl);
            return driver;
        }

        [TearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }
        }
    }
}
