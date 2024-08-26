using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using NUnit.Framework;

namespace SeleniumC_WebTesting.Utils
{
    public static class ReadCSVFile
    {
        public static List<TestData> GetTestData(string csvFilePath)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true, // Treat the first row as header
                HeaderValidated = null, // Disable header validation
                MissingFieldFound = null // Ignore missing fields
            };

            using (var reader = new StreamReader(csvFilePath))
            using (var csv = new CsvReader(reader, config))
            {
                // Register the class map
                csv.Context.RegisterClassMap<TestDataMap>();

                // Skip the header row
                csv.Read();
                csv.ReadHeader();

                // Read records starting from the first data row
                return new List<TestData>(csv.GetRecords<TestData>());
            }
        }

        public static IEnumerable<TestCaseData> GetCsvData(string csvFilePath)
        {
            var testDataList = GetTestData(csvFilePath);

            foreach (var testData in testDataList)
            {
                yield return new TestCaseData(testData.FullName, testData.Mobile, testData.Email);
            }
        }

        public class TestData
        {
            public string FullName { get; set; }
            public string Mobile { get; set; }
            public string Email { get; set; }
        }
    }
}
