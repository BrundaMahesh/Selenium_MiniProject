using MakeMyTripBus.PageObjects;
using MakeMyTripBus.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
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
            string? logfilepath = currdir + "/Logs/BusTicketBookinglog_" +
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
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement? element = driver.FindElement(By.XPath("//*[@id=\"SW\"]/div[1]/div[2]/div[2]/div"));
            IJavaScriptExecutor? executor = (IJavaScriptExecutor)driver;
            executor?.ExecuteScript("arguments[0].click();", element);
            Log.Information("Closed Sign in popup");
            

            var searchBusPage = homePage.ClickBusesOption();
            Log.Information("Bus Option clicked");

            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string? excelFilePath = currDir + "/TestData/InputData.xlsx";
            string? sheetName = "Bus";

            excelDataList = BookBusUtils.ReadExcelData(excelFilePath, sheetName);
            foreach (var excelData in excelDataList)
            { 
                string? fromInput = excelData?.FromInput;
                searchBusPage.ClickOnFromInput();
                Log.Information("Clicked from input box");
                Console.WriteLine($"From Input: {fromInput}");
                searchBusPage.ClickFromInput(fromInput);
                Thread.Sleep(3000);
                Log.Information("Entered from input");
                searchBusPage.ClickOnSelectFromInput();
                Log.Information("Selected particular entered city from the drop down");
                Thread.Sleep(5000);
                //I tried all waits in the "From" location case it's not working.So, I added this Thread.Sleep(1000);

                string? toInput = excelData?.ToInput;
                searchBusPage.ClickToInputText(toInput);
                Thread.Sleep(1000);
                Log.Information("Clicked To input box and entered To input");
                searchBusPage.ClickOnSelectToInput();
                Thread.Sleep(5000);
                Log.Information("Selected particular entered city from the drop down");
                //I tried all waits in the "To" location case it's not working.So, I added this Thread.Sleep(1000);

                string? date = excelData?.Date;
                Console.WriteLine($"date: {date}");
                searchBusPage.ClickGetDate(date);
                Log.Information("Selected particular date");
               

                var displayBusListsFilterPage = searchBusPage.ClickSearchButton();
                Log.Information("Clicked on Search button");
                displayBusListsFilterPage.ClickAC();
                Log.Information("Clicked AC");
                displayBusListsFilterPage.ClickSeatType();
                Log.Information("Clicked Sleeper Seat");
                displayBusListsFilterPage.ClickSelectSeatButton();
                Log.Information("Clicked Seat Button");
                
                string? seatposition = excelData.SeatPosition;
                Console.WriteLine($"Seat position: {seatposition}");
                ScrollIntoView(driver, driver.FindElement(By.XPath("//*[@id=\"busList\"]/div[2]/div[2]/div[1]/div[3]/div/div/div[1]/div")));
                displayBusListsFilterPage.ClickParticularSeat(seatposition);
                Log.Information("Selected particular seat");

                string seat=driver.FindElement(By.XPath("//div[@class='makeAbsolute']/div/li/span")).GetAttribute("data-testid");
                Console.WriteLine(seat);
                if (seat.Contains("unavailable"))
                {
                    Console.WriteLine("Particular seat not available");
                    driver.Close();
                    break;
                }
                ScrollIntoView(driver, driver.FindElement(By.XPath("//*[@id=\"busList\"]/div[2]/div[2]/div[1]/div[3]/div/div/div[2]")));
                displayBusListsFilterPage.ClickPickUpPoint();
                Log.Information("Selected pick up point");
                
                ScrollIntoView(driver, driver.FindElement(By.XPath("//*[@id=\"busList\"]/div[2]/div[2]/div[1]/div[3]/div/div/div[2]")));
                displayBusListsFilterPage.ClickDropPoint();
                Log.Information("Selected drop point");

                ScrollIntoView(driver, driver.FindElement(By.XPath("//*[@id=\"busList\"]/div[2]/div[2]/div[1]/div[3]/div/div/div[2]/div[3]")));
                var passengerDetailsPage = displayBusListsFilterPage.ClickContinueButton();
                Log.Information("Clicked on Continue button");
                
                string? sheetName1 = "PassengerDetails";
                passengerDataList = PassengerUtils.ReadExcelData(excelFilePath, sheetName1);

                foreach (var excelData1 in passengerDataList)
                {
                    string? name = excelData1?.Name;
                    Console.WriteLine($"First name: {name}");
                    passengerDetailsPage.ClickNameInput(name);
                    Log.Information("Entered passenger name");

                    string? age = excelData1?.Age;
                    Console.WriteLine($"Age: {age}");
                    passengerDetailsPage.ClickAgeInput(age);
                    Log.Information("Entered passenger age");

                    passengerDetailsPage.ClickGender();
                    Log.Information("Selected passenger gender");
                    passengerDetailsPage.ClickStateDropDown();
                    Log.Information("Clicked State dropdown");
                    passengerDetailsPage.ClickParticularState();
                    Log.Information("Selected state from the dropdown");
                    passengerDetailsPage.ClickConfirmAndSaveCheckBox();
                    Log.Information("Clicked Confirm and Save checkbox");

                    string? email = excelData1?.Email;
                    Console.WriteLine($"Email: {email}");
                    passengerDetailsPage.ClickEmailInput(email);
                    Log.Information("Entered passenger email");

                    string? mobilenumber = excelData1?.MobileNumber;
                    Console.WriteLine($"Mobile Number: {mobilenumber}");
                    passengerDetailsPage.ClickMobileNumberInput(mobilenumber);
                    Log.Information("Entered passenger Mobile number");

                    passengerDetailsPage.ClickSecureTripCheckbox();
                    Log.Information("Clicked Secure trip checkbox");

                    var paymentPage = passengerDetailsPage.ClickContinueButton();
                    Log.Information("Clicked Continue button");
                    
                    Thread.Sleep(8000);
                    //I tried all waits here but not working.
                    paymentPage.ClickUpiOption();
                    
                    Log.Information("Clicked UPI option");

                    string? upiId = excelData1?.UpiId;
                    Console.WriteLine($"Upi Id: {upiId}");
                    paymentPage.ClickUpiIdInput(upiId);
                    Log.Information("Entered UPI id");

                    paymentPage.ClickVerifyAndPayButton();
                    Log.Information("Clicked Verify and Pay Button");
                    paymentPage.ClickCancelButton();
                    Log.Information("Clicked Cancel Button");
                }
                try
                {
                    TakeScreenShot();
                    Assert.That(driver.Url.Contains("payments"));
                    Log.Information("Test passed for Bus Ticket Booking");
                    test = extent.CreateTest("Bus Ticket Booking");
                    test.Pass("Bus Ticket Booked Successfully");
                }
                catch (AssertionException ex)
                {
                    Log.Error($"Test failed for Bus Ticket Booking. \n Exception: {ex.Message}");
                    test = extent.CreateTest("Bus Ticket Booking");
                    test.Fail("Bus Ticket Booked failed");
                }
            }
        }
    }
}
