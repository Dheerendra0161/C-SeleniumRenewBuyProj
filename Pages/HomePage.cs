using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumC_WebTesting.Pages
{
    public class HomePage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        private IWebElement HealthImage => wait.Until(d => d.FindElement(By.XPath("//img[@alt='Health']")));

        public AboutYourSelfPage ClickHealthImage()
        {
            HealthImage.Click();
            return new AboutYourSelfPage(driver);
        }
    }
}
