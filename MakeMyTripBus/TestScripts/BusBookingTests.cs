
using MakeMyTripBus.PageObjects;
using MakeMyTripBus.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeMyTripBus.TestScripts
{
    [TestFixture]
    internal class BusBookingTests:CoreCodes
    {
        List<BookBusData>? excelDataList;
        [Test, Category("End to End Testing")]
        public void UserBusBooking()
        {
            var homePage = new MakeMyTripHomePage(driver);
            if (!driver.Url.Contains("https://www.makemytrip.com/"))
            {
                driver.Navigate().GoToUrl("https://www.makemytrip.com/");
            }
            var searchBusPage = homePage.ClickBusesOption();
            Thread.Sleep(5000);
            Assert.That(driver.Url.Contains("bus"));


            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string? excelFilePath = currDir + "/TestData/InputData.xlsx";
            string? sheetName = "Bus";

            excelDataList = BookBusUtils.ReadExcelData(excelFilePath, sheetName);

            foreach (var excelData in excelDataList)
            {
                string? fromInput = excelData?.FromInput;
                searchBusPage.ClickOnFromInput();
                Thread.Sleep(3000);
                Console.WriteLine($"From Input: {fromInput}");
                searchBusPage.ClickFromInput(fromInput);
                Thread.Sleep(2000);
                searchBusPage.ClickOnSelectFromInput();
                Thread.Sleep(2000);


                string? toInput = excelData?.ToInput;
                Console.WriteLine($"To Input: {toInput}");
               // searchBusPage.ClickOnToInput();
                Thread.Sleep(3000);
                searchBusPage.ClickOnSelectToInput();
                Thread.Sleep(2000);

                string? date = excelData?.Date;
                Console.WriteLine($"Date: {date}");
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].innerText = " + excelData.Date + " ;", searchBusPage.Date);

                string? month = excelData?.Month;
                Console.WriteLine($"Month: {month}");
                js.ExecuteScript("arguments[0].innerText = '" + excelData.Month + "' ;", searchBusPage.Month);

                string? year = excelData?.Year;
                Console.WriteLine($"Year: {year}");
                js.ExecuteScript("arguments[0].innerText = " + excelData.Year + " ;", searchBusPage.Year);
                Thread.Sleep(5000);
            }
            var displayBusListsFilterPage = searchBusPage.ClickSearchButton();

            displayBusListsFilterPage.ClickAC();
            displayBusListsFilterPage.ClickSeatType();

        }
    }
}
