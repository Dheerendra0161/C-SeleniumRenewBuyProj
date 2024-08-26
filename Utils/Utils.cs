using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelDataReader;
using System.IO;
namespace SeleniumC_WebTesting.Utils
{
    public class ExcelReader
    {
        public static DataTable ReadExcelFile(string filePath, string sheetName)
        {
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var dataSet = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = _ => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });
                    return dataSet.Tables[sheetName];
                }
            }
        }
    }
}
