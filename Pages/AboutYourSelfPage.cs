using System;
using OpenQA.Selenium;
using SeleniumC_WebTesting.Utils;  // Import the namespace where WaitHelpers is defined

namespace SeleniumC_WebTesting.Pages
{
    public class AboutYourSelfPage
    {
        private readonly IWebDriver driver;

       //  private By FullNameFieldLocator => By.Id("auto-fullName"); This is the By Locator
        private IWebElement FullNameField => driver.FindElement(By.Id("auto-fullName"));
        private IWebElement MobileField => driver.FindElement(By.Id("auto-mobile"));
        private IWebElement EmailField => driver.FindElement(By.Id("auto-email"));
        private IWebElement GetStartedButton => driver.FindElement(By.Id("auto-getStarted"));

        public AboutYourSelfPage(IWebDriver driver)
        {
            this.driver = driver;
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
            var element = WaitHelpers.WaitForElementToBeClickable(driver, MobileField, 10);
            element.SendKeys(mobile);
            return this;
        }

        // Enter email and return the current instance for chaining
        public AboutYourSelfPage EnterEmail(string email)
        {
            var element = WaitHelpers.WaitForElementToBeClickable(driver, EmailField,10);
            element.SendKeys(email);
            return this;
        }

        // Click the Get Started button and navigate to the next page
        public FamilyMemberInsurancePage ClickGetStarted()
        {
            var element = WaitHelpers.WaitForElementToBeClickable(driver, GetStartedButton, 10);
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
