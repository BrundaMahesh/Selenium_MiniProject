using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeMyTripBus.Utilities
{
    internal class PassengerUtils
    {
        public static List<PassengerData> ReadExcelData(string excelFilePath, string sheetName)
        {
            List<PassengerData> passengerDataList = new List<PassengerData>();
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
                            PassengerData excelData1 = new PassengerData
                            {
                                Name = GetValueOrDefault(row, "name"),
                                Age = GetValueOrDefault(row, "age"),
                                Email = GetValueOrDefault(row, "email"),
                                MobileNumber = GetValueOrDefault(row, "mobilenumber"),
                                UpiId = GetValueOrDefault(row, "upiid"),

                            };

                            passengerDataList.Add(excelData1);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Sheet '{sheetName}' not found in the Excel file.");
                    }
                }
            }

            return passengerDataList;
        }

        static string GetValueOrDefault(DataRow row, string columnName)
        {
            Console.WriteLine(row + "  " + columnName);
            return row.Table.Columns.Contains(columnName) ? row[columnName]?.ToString() : null;
        }
    }
}
