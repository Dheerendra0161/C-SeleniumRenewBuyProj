using NUnit.Framework;
using SeleniumC_WebTesting.Pages;
using SeleniumC_WebTesting.TestData;

namespace SeleniumC_WebTesting.Tests
{
    [TestFixture, Order(3)]
    public class FamilyMemberInsurancePageTests : Base
    {
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
        }

        [Test]
        public void TestSelectSelfCheckbox()
        {
            familyMemberInsurancePage.CheckSelfCheckbox("39");
            familyMemberInsurancePage.ClickContinue();
            // Add assertions to verify the selected age or the checkbox state
        }

    }
}
