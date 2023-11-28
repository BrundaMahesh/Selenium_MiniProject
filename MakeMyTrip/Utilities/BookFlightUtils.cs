using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeMyTrip.Utilities
{
    internal class BookFlightUtils
    {
        public static List<BookFlightData> ReadExcelData(string excelFilePath, string sheetName)
        {
            List<BookFlightData> excelDataList = new List<BookFlightData>();
            Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            using (var stream = new FileStream(excelFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true,
                        }
                    });

                    var dataTable = result.Tables[sheetName];

                    if (dataTable != null)
                    {
                        foreach (DataRow row in dataTable.Rows)
                        {
                            BookFlightData excelData = new BookFlightData
                            {
                                FromInput = GetValueOrDefault(row, "frominput"),
                                ToInput = GetValueOrDefault(row,"toinput"),
                                Date = GetValueOrDefault(row,"date"),
                                Month = GetValueOrDefault(row,"month"),
                                Year = GetValueOrDefault(row,"year"),
                                Adult = GetValueOrDefault(row,"adult"),
                                TravelClass = GetValueOrDefault(row,"travelclass")
                            };

                            excelDataList.Add(excelData);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Sheet '{sheetName}' not found in the Excel file.");
                    }
                }
            }

            return excelDataList;
        }

        static string GetValueOrDefault(DataRow row, string columnName)
        {
            Console.WriteLine(row + "  " + columnName);
            return row.Table.Columns.Contains(columnName) ? row[columnName]?.ToString() : null;
        }
    }
}

