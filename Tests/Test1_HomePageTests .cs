using NUnit.Framework;
using SeleniumC_WebTesting.Pages;

namespace SeleniumC_WebTesting.Tests
{
    [TestFixture,Order(1)]
    public class HomePageTests : Base
    {
        private HomePage homePage;

        [SetUp]
        public void setup()
        {
            driver = SetUp();
            homePage = new HomePage(driver);

        }

        [Test]
        public void TestClickHealthImage()
        {
           
            homePage.ClickHealthImage();
            
            
        }
    }
}
