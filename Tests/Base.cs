using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System;
using SeleniumC_WebTesting.TestData;

namespace SeleniumC_WebTesting.Tests
{
    public class Base
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;

        
        public IWebDriver SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            
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
