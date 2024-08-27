using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumC_WebTesting.Utils;  // Import the namespace where WaitHelpers is defined

namespace SeleniumC_WebTesting.Pages
{
    public class AboutYourSelfPage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        //  private By FullNameFieldLocator => By.Id("auto-fullName"); This is the By Locator
        private IWebElement FullNameField => driver.FindElement(By.Id("auto-fullName"));
        private IWebElement MobileField => driver.FindElement(By.Id("auto-mobile"));
        private IWebElement EmailField => driver.FindElement(By.Id("auto-email"));
        private IWebElement GetStartedButton => driver.FindElement(By.Id("auto-getStarted"));

        public AboutYourSelfPage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        // Enter full name and return the current instance for chaining
        public AboutYourSelfPage EnterFullName(string fullName)
        {
            var element = WaitHelpers.WaitForElementToBeClickable(driver, FullNameField, 10);
            element.SendKeys(fullName);
            return this;
        }

        // Enter mobile and return the current instance for chaining
        public AboutYourSelfPage EnterMobile(string mobile)
        {
            var element = WaitHelpers.WaitForElementToBeClickable(driver, MobileField, 20);
            element.SendKeys(mobile);
            return this;
        }

        // Enter email and return the current instance for chaining
        public AboutYourSelfPage EnterEmail(string email)
        {
            var element = WaitHelpers.WaitForElementToBeClickable(driver, EmailField,20);
            element.SendKeys(email);
            return this;
        }

        // Click the Get Started button and navigate to the next page
        public FamilyMemberInsurancePage ClickGetStarted()
        {
            var element = WaitHelpers.WaitForElementToBeClickable(driver, GetStartedButton, 20);
            element.Click();
            return new FamilyMemberInsurancePage(driver);
        }

        // Method to enter all fields and click the Get Started button
        public void EnterAllFieldsAndClickGetStarted(string fullName, string mobile, string email)
        {
            EnterFullName(fullName)
                .EnterMobile(mobile)
                .EnterEmail(email);
            ClickGetStarted();
        }
    }
}
