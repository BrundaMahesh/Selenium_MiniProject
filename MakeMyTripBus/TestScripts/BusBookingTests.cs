using MakeMyTripBus.PageObjects;
using MakeMyTripBus.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Serilog;
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
        List<PassengerData>? passengerDataList;

        [Test, Category("End to End Testing")]
       
        public void UserBusTicketBookingTest()
        {
            string? currdir = Directory.GetParent(@"../../../")?.FullName;
            string? logfilepath = currdir + "/Logs/log_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";

            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day)
            .CreateLogger();

            var homePage = new MakeMyTripHomePage(driver);
            if (!driver.Url.Contains("https://www.makemytrip.com/"))
            {
                driver.Navigate().GoToUrl("https://www.makemytrip.com/");
            }
            Log.Information("User bus ticket booking test started");

            IWebElement element = driver.FindElement(By.XPath("//*[@id=\"SW\"]/div[1]/div[2]/div[2]/div"));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].click();", element);


            var searchBusPage = homePage.ClickBusesOption();
            try
            {
                Assert.That(driver.Url.Contains("bus"));
                Log.Information("Test passed for Bus Option Clicking");
                test = extent.CreateTest("Bus Page Loading");
                test.Pass("Bus Page Loaded Successfully");
            }
            catch (AssertionException ex)
            {
                Log.Error($"Test failed for Bus Option Clicking. \n Exception: {ex.Message}");
                test = extent.CreateTest("Bus Page Loading");
                test.Fail("Bus Page Loading failed");
            }
            Thread.Sleep(5000);

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
                /*Console.WriteLine($"To Input: {toInput}");
                searchBusPage.ClickOnToInput();
                Thread.Sleep(3000);*/

                searchBusPage.ClickToInputText(toInput);
                Thread.Sleep(3000);
                searchBusPage.ClickOnSelectToInput();
                Thread.Sleep(5000);

                string? date = excelData.Date;
                Console.WriteLine($"date: {date}");
                searchBusPage.ClickGetDate(date);
                Thread.Sleep(5000);
                

                var displayBusListsFilterPage = searchBusPage.ClickSearchButton();
                Thread.Sleep(5000);

                displayBusListsFilterPage.ClickAC();
                displayBusListsFilterPage.ClickSeatType();
                displayBusListsFilterPage.ClickSelectSeatButton();
                Thread.Sleep(5000);
                string? seatposition = excelData.SeatPosition;
                Console.WriteLine($"Seat position: {seatposition}");
                ScrollIntoView(driver, driver.FindElement(By.XPath("//*[@id=\"busList\"]/div[2]/div[2]/div[1]/div[3]/div/div/div[1]/div")));
                displayBusListsFilterPage.ClickParticularSeat(seatposition);
                //displayBusListsFilterPage.ClickParticularSeat();

                string seat=driver.FindElement(By.XPath("//div[@class='makeAbsolute']/div/li/span")).GetAttribute("data-testid");
                Console.WriteLine(seat);
                if (seat.Contains("unavailable"))
                {
                    Console.WriteLine("Particular seat not available");
                    driver.Close();
                }
                Thread.Sleep(5000);
                ScrollIntoView(driver, driver.FindElement(By.XPath("//*[@id=\"busList\"]/div[2]/div[2]/div[1]/div[3]/div/div/div[2]")));
                displayBusListsFilterPage.ClickPickUpPoint();
                Thread.Sleep(5000);
                ScrollIntoView(driver, driver.FindElement(By.XPath("//*[@id=\"busList\"]/div[2]/div[2]/div[1]/div[3]/div/div/div[2]")));
                displayBusListsFilterPage.ClickDropPoint();
                Thread.Sleep(5000);

                ScrollIntoView(driver, driver.FindElement(By.XPath("//*[@id=\"busList\"]/div[2]/div[2]/div[1]/div[3]/div/div/div[2]/div[3]")));
                Thread.Sleep(5000);
                var passengerDetailsPage = displayBusListsFilterPage.ClickContinueButton();

                Thread.Sleep(5000);
                string? sheetName1 = "PassengerDetails";

                passengerDataList = PassengerUtils.ReadExcelData(excelFilePath, sheetName1);

                foreach (var excelData1 in passengerDataList)
                {
                    string? name = excelData1?.Name;
                    Console.WriteLine($"First name: {name}");
                    passengerDetailsPage.ClickNameInput(name);

                    string? age = excelData1?.Age;
                    Console.WriteLine($"Last name: {age}");
                    passengerDetailsPage.ClickAgeInput(age);


                    passengerDetailsPage.ClickGender();
                    passengerDetailsPage.ClickStateDropDown();
                    Thread.Sleep(5000);
                    passengerDetailsPage.ClickParticularState();
                    Thread.Sleep(5000);
                    passengerDetailsPage.ClickConfirmAndSaveCheckBox();

                    string? email = excelData1?.Email;
                    Console.WriteLine($"Email: {email}");
                    passengerDetailsPage.ClickEmailInput(email);


                    string? mobilenumber = excelData1?.MobileNumber;
                    Console.WriteLine($"Mobile Number: {mobilenumber}");
                    passengerDetailsPage.ClickMobileNumberInput(mobilenumber);


                    passengerDetailsPage.ClickSecureTripCheckbox();

                    var paymentPage = passengerDetailsPage.ClickContinueButton();
                    Thread.Sleep(7000);
                    paymentPage.ClickUpiOption();
                    Thread.Sleep(5000);

                    string? upiId = excelData1?.UpiId;
                    Console.WriteLine($"Upi Id: {upiId}");
                    paymentPage.ClickUpiIdInput(upiId);
                    Thread.Sleep(5000);

                    paymentPage.ClickVerifyAndPayButton();
                    Thread.Sleep(5000);
                    paymentPage.ClickCancelButton();
                }
            }
        }
    }
}
