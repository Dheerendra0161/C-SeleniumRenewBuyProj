using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;



namespace SeleniumC_WebTesting.Utils
{
    /** static classes in C#:
No Instances: You cannot create an instance of a static class using the new keyword.
Static Members Only: All members of a static class must be static. You cannot declare instance members like fields, properties, or methods.
No Inheritance: Static classes cannot inherit from other classes, and no class can inherit from a static class.
Sealed by Default: Static classes are implicitly sealed, meaning they cannot be extended.
    * */

    public static class WaitHelpers
    {

        /// Waits for the specified element to be clickable.
        public static IWebElement WaitForElementToBeClickable(IWebDriver driver, IWebElement element, int timeoutInSeconds)
        {
            TimeSpan timeout = TimeSpan.FromSeconds(timeoutInSeconds);
            WebDriverWait wait = new WebDriverWait(driver, timeout);
            return wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }

        /// Waits for the specified text to be present in the element.
        public static bool WaitForTextToBePresentInElement(IWebDriver driver, IWebElement element, string text, int timeoutInSeconds)
        {
            TimeSpan timeout = TimeSpan.FromSeconds(timeoutInSeconds);
            WebDriverWait wait = new WebDriverWait(driver, timeout);
            return wait.Until(ExpectedConditions.TextToBePresentInElement(element, text));
        }

        /// Waits for an alert to be present on the page.
        public static IAlert WaitForAlert(IWebDriver driver, int timeoutInSeconds)
        {
            TimeSpan timeout = TimeSpan.FromSeconds(timeoutInSeconds);
            WebDriverWait wait = new WebDriverWait(driver, timeout);
            return wait.Until(ExpectedConditions.AlertIsPresent());
        }

        /// Waits for the page title to contain the specified text.
        public static bool WaitForTitleToContainText(IWebDriver driver, string titleFragment, int timeoutInSeconds)
        {
            TimeSpan timeout = TimeSpan.FromSeconds(timeoutInSeconds);
            WebDriverWait wait = new WebDriverWait(driver, timeout);
            return wait.Until(ExpectedConditions.TitleContains(titleFragment));
        }



        /*
         * Key Characteristics of Fluent Wait:
    Customizable Timeout: You can specify the maximum time to wait for a condition to be met.
    Polling Interval: You can define how often the condition is checked.
    Exception Handling: You can configure the wait to ignore specific exceptions while waiting.
         * */
        // Method to wait for an element with Fluent Wait, handling multiple exceptions
        public static IWebElement WaitForElementWithFluentWait(IWebDriver driver, By locator, int timeoutInSeconds, int pollingIntervalInSeconds)
        {
            TimeSpan timeout = TimeSpan.FromSeconds(timeoutInSeconds); // Max wait time of 30 seconds
            TimeSpan pollingInterval = TimeSpan.FromMicroseconds(pollingIntervalInSeconds); // Polling interval of 300 micro second

            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver)
            {
                Timeout = timeout, // Sets the max time to wait
                PollingInterval = pollingInterval // Sets how often to check for the condition
            };

            // Ignore multiple exception types
            fluentWait.IgnoreExceptionTypes(
                typeof(NoSuchElementException),
                typeof(StaleElementReferenceException),
                typeof(ElementNotInteractableException)
            );
            // drv is shortend form of driver and represents the IWebDriver instance being passed to the lambda.
            return fluentWait.Until(drv =>
            {
                try
                {
                    IWebElement element = drv.FindElement(locator);
                    return element.Displayed && element.Enabled ? element : null;  //if-else conditions after ? True:False
                }
                catch (NoSuchElementException)
                {
                    return null; // Element not found, keep waiting
                }
                catch (StaleElementReferenceException)
                {
                    return null; // Element is stale, keep waiting
                }
                catch (ElementNotInteractableException)
                {
                    return null; // Element not interactable, keep waiting
                }
            });
        }
    }
}


