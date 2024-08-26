using NUnit.Framework;
using SeleniumC_WebTesting.Pages;

namespace SeleniumC_WebTesting.Tests
{

    [TestFixture, Order(4)] // [TestFixture]-Shows this class contains the Tests
    public class CityPageTests : Base
    {
        private CityPage cityPage;


        private FamilyMemberInsurancePage familyMemberInsurancePage;
        private AboutYourSelfPage aboutYourSelfPage;
        private HomePage homePage;

        [SetUp]
        public void setup()
        {
            driver = SetUp();
            homePage = new HomePage(driver);
            aboutYourSelfPage = homePage.ClickHealthImage();
            aboutYourSelfPage.EnterAllFieldsAndClickGetStarted("dheerendra", "9865986598", "dherendra@gmail.com");
            familyMemberInsurancePage = aboutYourSelfPage.ClickGetStarted(); 
            Thread.Sleep(5000);
            cityPage = familyMemberInsurancePage.CheckSelfCheckbox("39").ClickContinue();
        }


        [Test]
        public void TestSelectCity()
        {
            cityPage.SelectCity();
            // Add assertions to verify the city selection
        }
    }
}
