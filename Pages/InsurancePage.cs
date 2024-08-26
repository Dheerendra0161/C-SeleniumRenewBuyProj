using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumC_WebTesting.Pages
{
    public class InsurancePage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public InsurancePage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        // Properties to find elements
        private IWebElement HealthImage => wait.Until(d => d.FindElement(By.XPath("//img[@alt='Health']")));
        private IWebElement FullNameField => wait.Until(d => d.FindElement(By.Id("auto-fullName")));
        private IWebElement MobileField => wait.Until(d => d.FindElement(By.Id("auto-mobile")));
        private IWebElement EmailField => wait.Until(d => d.FindElement(By.Id("auto-email")));
        private IWebElement GetStartedButton => wait.Until(d => d.FindElement(By.Id("auto-getStarted")));
        private IWebElement ContinueButton => wait.Until(d => d.FindElement(By.CssSelector(".sc-ikkxIA")));
        private IWebElement FamilyFloaterOption => wait.Until(d => d.FindElement(By.CssSelector("div:nth-child(1) > .RadioButton__RadioLabel-sc-o9qvnl-1")));
        private IWebElement ContinueButtonAgain => wait.Until(d => d.FindElement(By.Id("auto-Continue")));

        // Methods to interact with elements
        public void ClickHealthImage() => HealthImage.Click();
        public void EnterFullName(string name) => FullNameField.SendKeys(name);
        public void EnterMobileNumber(string number) => MobileField.SendKeys(number);
        public void EnterEmail(string email) => EmailField.SendKeys(email);
        public void ClickGetStarted() => GetStartedButton.Click();
        public void ClickContinue() => ContinueButton.Click();
        public void SelectFamilyFloater() => FamilyFloaterOption.Click();
        public void ClickContinueAgain() => ContinueButtonAgain.Click();

        public void SelectOptionById(string elementId, string value)
        {
            var inputField = wait.Until(d => d.FindElement(By.Id(elementId)));
            inputField.SendKeys(value);
            inputField.SendKeys(Keys.Enter);

            var option = wait.Until(d => d.FindElement(By.CssSelector(".css-1oveqx0-control .css-19bb58m")));
            option.Click();
        }

        public void SelectLocation(string cssSelector)
        {
            var location = wait.Until(d => d.FindElement(By.CssSelector(cssSelector)));
            location.Click();
            var locationHeader = wait.Until(d => d.FindElement(By.CssSelector($"{cssSelector} > .typography--variant-subheading1")));
            locationHeader.Click();
        }
    }
}
