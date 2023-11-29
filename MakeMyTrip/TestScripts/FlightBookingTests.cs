using MakeMyTrip.PageObjects;
using MakeMyTrip.Utilities;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;

namespace MakeMyTrip.TestScripts
{
    [TestFixture]
    internal class FlightBookingTests:CoreCodes
    {
        List<BookFlightData>? excelDataList;
        List<PassengerData>? passengerDataList;

        [Test,Category("End to End Testing")]
        public void UserBookingFlightTest()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(10);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element not found";

            //MakeMyTripHomePage makeMyTripHomePage = new MakeMyTripHomePage(driver);
            //makeMyTripHomePage.ClickSignInPopup();
           // Thread.Sleep(5000);

            //makeMyTripHomePage.ClickLogoCheck();
            //Assert.That(driver.Url.Contains("makemytrip"));


           var homePage = new MakeMyTripHomePage(driver);
           if (!driver.Url.Contains("https://www.makemytrip.com/"))
           {
                driver.Navigate().GoToUrl("https://www.makemytrip.com/");
           }
           var searchFlightPage=homePage.ClickFlightOption();
           Thread.Sleep(5000);
           Assert.That(driver.Url.Contains("flights"));

           searchFlightPage.ClickOneWayRadioButton();

           string? currDir = Directory.GetParent(@"../../../")?.FullName;
           string? excelFilePath = currDir + "/TestData/InputData.xlsx";
           string? sheetName = "SearchFlight";

           excelDataList = BookFlightUtils.ReadExcelData(excelFilePath, sheetName);

           foreach (var excelData in excelDataList)
           {
                string? fromInput = excelData?.FromInput;
                Console.WriteLine($"From Input: {fromInput}");
                searchFlightPage.ClickFromInput(excelData.FromInput);
                
                string? toInput = excelData?.ToInput;
                Console.WriteLine($"To Input: {toInput}");
                searchFlightPage.ClickToInput(excelData.ToInput);

                string? date = excelData?.Date;
                Console.WriteLine($"Date: {date}");
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].innerText = " + excelData.Date  + " ;", searchFlightPage.Date);

                string? month = excelData?.Month;
                Console.WriteLine($"Month: {month}");
                js.ExecuteScript("arguments[0].innerText = '" + excelData.Month + "' ;", searchFlightPage.Month);

                string? year = excelData?.Year;
                Console.WriteLine($"Year: {year}");
                js.ExecuteScript("arguments[0].innerText = " + excelData.Year + " ;", searchFlightPage.Year);
                //Console.WriteLine(driver.FindElement(By.XPath("//input[@id='departure']//following::span[1]")).Text);

                Thread.Sleep(8000);

                string? adult = excelData?.Adult;
                Console.WriteLine($"Adult: {adult}");
                string? travelclass = excelData?.TravelClass;
                Console.WriteLine($"Travel class: {travelclass}");
                searchFlightPage.ClickTravellers(excelData.Adult, excelData.TravelClass);
                Thread.Sleep(5000);
           }
            searchFlightPage.ClickApplyButton();
            Thread.Sleep(3000);

          

            var displayFlightListsFilterPage = searchFlightPage.ClickSearchButton();
            Thread.Sleep(20000);

            displayFlightListsFilterPage = displayFlightListsFilterPage.ClickNonStopCheckBox();
            Thread.Sleep(10000);
            displayFlightListsFilterPage = displayFlightListsFilterPage.ClickIndigoCheckBox();
            Thread.Sleep(10000);
            displayFlightListsFilterPage = displayFlightListsFilterPage.ClickViewPricesButton();
            Thread.Sleep(10000);
            displayFlightListsFilterPage.ClickBookNowButton();
            



            List<string> nextwindow = driver.WindowHandles.ToList();
            driver.SwitchTo().Window(nextwindow[1]);

            var passengerDetailsPage = new PassengerDetailsPage(driver);
            Thread.Sleep(10000);
            passengerDetailsPage.ClickNoRadioButton();
            Thread.Sleep(5000);
            passengerDetailsPage.ClickAddNewAdult();
            Thread.Sleep(5000);
            //string? currDir = Directory.GetParent(@"../../../")?.FullName;
            //string? excelFilePath = currDir + "/TestData/InputData.xlsx";
            string? sheetName1 = "PassengerDetails";

            passengerDataList = PassengerUtils.ReadExcelData(excelFilePath, sheetName1);

            foreach (var excelData1 in passengerDataList)
            {
                string? firstname = excelData1?.FirstName;
                Console.WriteLine($"First name: {firstname}");
                passengerDetailsPage.ClickFirstNameInput(excelData1.FirstName);

                string? lastname = excelData1?.LastName;
                Console.WriteLine($"Last name: {lastname}");
                passengerDetailsPage.ClickLastNameInput(excelData1.LastName);
                Thread.Sleep(5000);

                passengerDetailsPage.ClickMaleButton();

                string? mobilenumber = excelData1?.MobileNumber;
                Console.WriteLine($"Mobile Number: {mobilenumber}");
                passengerDetailsPage.ClickMobileNumberInput(excelData1.MobileNumber);
                Thread.Sleep(5000);

                string? email = excelData1?.Email;
                Console.WriteLine($"Email: {email}");
                passengerDetailsPage.ClickEmailInput(excelData1.Email);
                Thread.Sleep(5000);
            }
            
            //passengerDetailsPage.ClickStateDropDown();
            Thread.Sleep(5000);
            passengerDetailsPage.ClickConfirmAndSaveCheckBox();
            Thread.Sleep(5000);
            passengerDetailsPage.ClickContinueButton();
            Thread.Sleep(5000);
            passengerDetailsPage.ClickConfirmButton();
            Thread.Sleep(5000);



        }
    }
}
