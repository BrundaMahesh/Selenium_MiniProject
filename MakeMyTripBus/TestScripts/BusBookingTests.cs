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
            Log.Information("Sign up pop closed");


            var searchBusPage = homePage.ClickBusesOption();
            Log.Information("Bus Option clicked");

            
            //Thread.Sleep(5000);

            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string? excelFilePath = currDir + "/TestData/InputData.xlsx";
            string? sheetName = "Bus";

            excelDataList = BookBusUtils.ReadExcelData(excelFilePath, sheetName);

            foreach (var excelData in excelDataList)
            {
                
                string? fromInput = excelData?.FromInput;
                searchBusPage.ClickOnFromInput();
                Log.Information("Clicked from input box");
                Thread.Sleep(3000);
                Console.WriteLine($"From Input: {fromInput}");
                searchBusPage.ClickFromInput(fromInput);
                Log.Information("Entered from input");
                Thread.Sleep(2000);
                searchBusPage.ClickOnSelectFromInput();
                Log.Information("Selected particular entered city from the drop down");
                Thread.Sleep(2000);


                string? toInput = excelData?.ToInput;
                /*Console.WriteLine($"To Input: {toInput}");
                searchBusPage.ClickOnToInput();
                Thread.Sleep(3000);*/

                searchBusPage.ClickToInputText(toInput);
                Log.Information("Clicked To input box and entered To input");
                Thread.Sleep(3000);
                searchBusPage.ClickOnSelectToInput();
                Log.Information("Selected particular entered city from the drop down");
                Thread.Sleep(5000);

                string? date = excelData.Date;
                Console.WriteLine($"date: {date}");
                searchBusPage.ClickGetDate(date);
                Log.Information("Selected particular date");
                Thread.Sleep(5000);
                

                var displayBusListsFilterPage = searchBusPage.ClickSearchButton();
                Log.Information("Clicked on Search button");
                Thread.Sleep(5000);

                displayBusListsFilterPage.ClickAC();
                Log.Information("Clicked AC");
                displayBusListsFilterPage.ClickSeatType();
                Log.Information("Clicked Sleeper Seat");
                displayBusListsFilterPage.ClickSelectSeatButton();
                Log.Information("Clicked Seat Button");
                Thread.Sleep(5000);
                string? seatposition = excelData.SeatPosition;
                Console.WriteLine($"Seat position: {seatposition}");
                ScrollIntoView(driver, driver.FindElement(By.XPath("//*[@id=\"busList\"]/div[2]/div[2]/div[1]/div[3]/div/div/div[1]/div")));
                displayBusListsFilterPage.ClickParticularSeat(seatposition);
                Log.Information("Selected particular seat");
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
                Log.Information("Selected pick up point");
                Thread.Sleep(5000);
                ScrollIntoView(driver, driver.FindElement(By.XPath("//*[@id=\"busList\"]/div[2]/div[2]/div[1]/div[3]/div/div/div[2]")));
                displayBusListsFilterPage.ClickDropPoint();
                Log.Information("Selected drop point");
                Thread.Sleep(5000);

                ScrollIntoView(driver, driver.FindElement(By.XPath("//*[@id=\"busList\"]/div[2]/div[2]/div[1]/div[3]/div/div/div[2]/div[3]")));
                Thread.Sleep(5000);
                var passengerDetailsPage = displayBusListsFilterPage.ClickContinueButton();
                Log.Information("Clicked on Continue button");
                Thread.Sleep(5000);
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
                    Thread.Sleep(5000);
                    passengerDetailsPage.ClickParticularState();
                    Log.Information("Selected state from the dropdown");
                    Thread.Sleep(5000);
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
                    Thread.Sleep(7000);
                    paymentPage.ClickUpiOption();
                    Log.Information("Clicked UPI option");
                    Thread.Sleep(5000);

                    string? upiId = excelData1?.UpiId;
                    Console.WriteLine($"Upi Id: {upiId}");
                    paymentPage.ClickUpiIdInput(upiId);
                    Log.Information("Entered UPI id");
                    Thread.Sleep(5000);

                    paymentPage.ClickVerifyAndPayButton();
                    Log.Information("Clicked Verify and Pay Button");
                    Thread.Sleep(5000);
                    paymentPage.ClickCancelButton();
                    Log.Information("Clicked Cancel Button");
                }
                try
                {
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
