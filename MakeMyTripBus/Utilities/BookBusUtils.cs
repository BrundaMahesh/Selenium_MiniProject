using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeMyTripBus.Utilities
{
    internal class BookBusUtils
    {
        public static List<BookBusData> ReadExcelData(string excelFilePath, string sheetName)
        {
            List<BookBusData> excelDataList = new List<BookBusData>();
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
                            BookBusData excelData = new BookBusData
                            {
                                FromInput = GetValueOrDefault(row, "frominput"),
                                ToInput = GetValueOrDefault(row, "toinput"),
                                Date = GetValueOrDefault(row, "date"),
                                SeatPosition = GetValueOrDefault(row,"seatposition"),
                                MobileNumber = GetValueOrDefault(row,"mobilenumber")
                                
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
