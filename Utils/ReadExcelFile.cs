using System.Collections.Generic;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel; // For .xlsx files
using NPOI.HSSF.UserModel; // For .xls files

namespace SeleniumC_WebTesting.TestData
{
    public class ReadExcelFile
    {
        private readonly string _filePath;

        public ReadExcelFile(string filePath)
        {
            _filePath = filePath;
        }

        public IEnumerable<TestDataRow> GetTestData(string sheetName)
        {
            var testData = new List<TestDataRow>();

            if (!File.Exists(_filePath))
            {
                throw new FileNotFoundException($"The file at {_filePath} does not exist.");
            }

            IWorkbook workbook;
            using (var fileStream = new FileStream(_filePath, FileMode.Open, FileAccess.Read))
            {
                var fileExtension = Path.GetExtension(_filePath);
                if (fileExtension.Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
                {
                    workbook = new XSSFWorkbook(fileStream);
                }
                else if (fileExtension.Equals(".xls", StringComparison.OrdinalIgnoreCase))
                {
                    workbook = new HSSFWorkbook(fileStream);
                }
                else
                {
                    throw new NotSupportedException("File format not supported.");
                }
            }

            var sheet = workbook?.GetSheet(sheetName);
            if (sheet == null)
            {
                throw new ArgumentException($"Sheet with name '{sheetName}' does not exist in the Excel file.");
            }

            var headerRow = sheet.GetRow(0);
            if (headerRow == null)
            {
                throw new ArgumentException("The sheet does not contain a header row.");
            }

            var headerMap = new Dictionary<string, int>();

            // Map the header row to column indices
            for (int col = 0; col < headerRow.LastCellNum; col++)
            {
                var headerCell = headerRow.GetCell(col);
                if (headerCell != null && !string.IsNullOrEmpty(headerCell.ToString()))
                {
                    headerMap[headerCell.ToString()] = col;
                }
            }

            // Check if the required columns exist
            if (!headerMap.ContainsKey("FullName") || !headerMap.ContainsKey("Mobile") || !headerMap.ContainsKey("Email"))
            {
                throw new ArgumentException("One or more required columns (FullName, Mobile, Email) are missing.");
            }

            // Read data rows
            for (int row = 1; row <= sheet.LastRowNum; row++)
            {
                var dataRow = sheet.GetRow(row);
                if (dataRow == null) continue;

                var fullName = dataRow.GetCell(headerMap["FullName"])?.ToString();
                var mobile = dataRow.GetCell(headerMap["Mobile"])?.ToString();
                var email = dataRow.GetCell(headerMap["Email"])?.ToString();

                yield return new TestDataRow
                {
                    FullName = fullName ?? string.Empty,
                    Mobile = mobile ?? string.Empty,
                    Email = email ?? string.Empty
                };
            }
        }
    }

    public class TestDataRow
    {
        public string FullName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
    }
}
