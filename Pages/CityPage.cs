using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumC_WebTesting.Pages
{
    public class CityPage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public CityPage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }

        // Use ExpectedConditions to wait until the element is clickable
        private IWebElement CityCheckbox => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//h6[normalize-space()='Bangalore']")));

        public void SelectCity()
        {
            var cityCheckbox = CityCheckbox;
            if (cityCheckbox != null && cityCheckbox.Displayed)
            {
                cityCheckbox.Click();
            }
            else
            {
                throw new NoSuchElementException("City checkbox with the text 'Bangalore' is not found or is not visible.");
            }
        }
    }
}
