using CsvHelper.Configuration;

namespace SeleniumC_WebTesting.Utils
{
    public sealed class TestDataMap : ClassMap<ReadCSVFile.TestData>
    {
        public TestDataMap()
        {
            // Map properties to CSV columns
            Map(m => m.FullName).Name("fullName");
            Map(m => m.Mobile).Name("mobile");
            Map(m => m.Email).Name("email");
        }
    }
}
