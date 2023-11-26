using MakeMyTrip.PageObjects;
using MakeMyTrip.Utilities;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeMyTrip.TestScripts
{
    [TestFixture]
    internal class MakeMyTripTests:CoreCodes
    {
        [Test]
        public void HomePageTest()
        {
            MakeMyTripHomePage makeMyTripHomePage = new MakeMyTripHomePage(driver);
            makeMyTripHomePage.ClickSignInPopup();
            //Thread.Sleep(2000);
          
            makeMyTripHomePage.ClickLogoCheck();
            Assert.That(driver.Url.Contains("makemytrip"));

           // Thread.Sleep(5000);
            makeMyTripHomePage.ClickFlightOption();
            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string? excelFilePath = currDir + "/TestData/InputData.xlsx";
            string? sheetName = "SearchFlight";

            List<ExcelData> excelDataList = ExcelUtils.ReadExcelData(excelFilePath, sheetName);

            foreach (var excelData in excelDataList)
            {

                string? fromInput = excelData?.FromInput;
                Console.WriteLine($"From Input: {fromInput}");
                makeMyTripHomePage.ClickFromInput(excelData.FromInput);

                string? toInput = excelData?.ToInput;
                Console.WriteLine($"To Input: {toInput}");
                makeMyTripHomePage.ClickFromInput(excelData.ToInput);
                
               // makeMyTripHomePage.ClickTravellers();
                //makeMyTripHomePage.ClickApplyButton();
               // makeMyTripHomePage.ClickSearchButton();
                Thread.Sleep(3000);
            }

        }
    }
}
