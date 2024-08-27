using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumC_WebTesting.Pages
{
    public class HomePage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        // Constructor to initialize WebDriver and WebDriverWait
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            // Initialize the WebDriverWait with a timeout of 10 seconds
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        private IWebElement HealthImage => wait.Until(d => d.FindElement(By.XPath("//img[@alt='Health']")));

        public AboutYourSelfPage ClickHealthImage()
        {
            HealthImage.Click();
            return new AboutYourSelfPage(driver);
        }
    }
}
