using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;

namespace SeleniumC_WebTesting.Pages
{
    public class FamilyMemberInsurancePage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public FamilyMemberInsurancePage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        private IWebElement SelfCheckbox =>
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='auto_self']//descendant::div[text()='Select Age']")));

        private IWebElement ContinueButton =>
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("auto-Continue")));

        private IWebElement TraceIdElement =>
           wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//p[contains(text(),'Trace Id')]")));



        public FamilyMemberInsurancePage CheckSelfCheckbox(string age)
        {
            var checkbox = SelfCheckbox;
            // Use Actions class to type the age and press Enter if required
            var actions = new Actions(driver);
            actions.MoveToElement(checkbox)
                   .Click()
                   .SendKeys(age)
                   .SendKeys(Keys.Enter)
                   .Perform();
            return this;
        }

        public CityPage ClickContinue()
        {
            ContinueButton.Click();
            return new CityPage(driver); // Navigate to the CityPage
        }


        // Method to assert the presence of the 'Trace Id'
       public void AssertTraceIdIsPresent()
        {
            Assert.That(TraceIdElement.Displayed, Is.True, "Trace Id is not present on the page.");
           
        }

      

    }
}


