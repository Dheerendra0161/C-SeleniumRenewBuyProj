using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumC_WebTesting.Pages;
using SeleniumC_WebTesting.TestData;
using SeleniumC_WebTesting.Utils;

namespace SeleniumC_WebTesting.Tests
{
    [TestFixture, Order(2)]
    public class AboutYourSelfPageTests : Base
    {
        private AboutYourSelfPage aboutYourSelfPage;
        private HomePage homePage;
        private FamilyMemberInsurancePage familyMemberInsurancePage;

        // Use relative path to the TestData.xlsx file
        private static readonly string ExcelFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\TestData\TestData.xlsx");
        private static readonly string CSVFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\TestData\CSVTestData.csv");


        [SetUp]
        public void setup()
        {
            driver = SetUp();
            homePage = new HomePage(driver);
            aboutYourSelfPage = homePage.ClickHealthImage();


        }

        [Test, Order(3)]
        [TestCase("Dheerendra", "9865832536", "dheerendra546@gmail.com")]
        [TestCase("Vikas", "9885832536", "vikas875@gmail.com")]
        [TestCase("Pranav", "9885232536", "pranav741@gmail.com")]

        public void TestEnterAllValidCredential(string fullName, string mobile, string email)
        {
            // Ensure EnterAllFields returns FamilyMemberInsurancePage
            aboutYourSelfPage.EnterAllFieldsAndClickGetStarted(fullName, mobile, email);
            aboutYourSelfPage.ClickGetStarted();

            familyMemberInsurancePage = aboutYourSelfPage.ClickGetStarted();
            // Assert the presence of Trace Id
            familyMemberInsurancePage.AssertTraceIdIsPresent();
        }





        public static IEnumerable<object[]> TestData
        {
            get
            {
                var excelReader = new ReadExcelFile(ExcelFilePath);
                foreach (var row in excelReader.GetTestData("Sheet1"))
                {
                    yield return new object[] { row.FullName, row.Mobile, row.Email };
                    //yield return: Used to return each value in a sequence one at a time.
                }
            }
        }

        [Retry(3)]
        [Test, TestCaseSource(nameof(TestData)), Order(2)]
        public void TestEnterAllValidCredentialFromExcel(string fullName, string mobile, string email)
        {
            // Ensure EnterAllFields returns FamilyMemberInsurancePage
            aboutYourSelfPage.EnterAllFieldsAndClickGetStarted(fullName, mobile, email);
            aboutYourSelfPage.ClickGetStarted();

            familyMemberInsurancePage = aboutYourSelfPage.ClickGetStarted();
            // Assert the presence of Trace Id
            familyMemberInsurancePage.AssertTraceIdIsPresent();
        }




        public static IEnumerable<TestCaseData> GetTestData()
        {
            return ReadCSVFile.GetCsvData(CSVFilePath);
        }

        [Test, TestCaseSource(nameof(GetTestData)), Order(1)]
        public void TestEnterAllValidCredentialFromCSVFile(string fullName, string mobile, string email)
        {
            try
            {
                // Ensure EnterAllFields returns FamilyMemberInsurancePage
                aboutYourSelfPage.EnterAllFieldsAndClickGetStarted(fullName, mobile, email);
                aboutYourSelfPage.ClickGetStarted();

                familyMemberInsurancePage = aboutYourSelfPage.ClickGetStarted();
                // Assert the presence of Trace Id
                familyMemberInsurancePage.AssertTraceIdIsPresent();
            }
            catch (NoSuchElementException ex)
            {
                // Log the exception details
                Console.WriteLine($"Element not found: {ex.Message}");
                throw; // Re-throw the exception to fail the test
            }
        }

    }

}






