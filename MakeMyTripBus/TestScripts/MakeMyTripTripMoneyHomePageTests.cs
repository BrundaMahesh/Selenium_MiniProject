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
    internal class MakeMyTripTripMoneyHomePageTests:CoreCodes
    {
        
        [Test,Order(1),Category("Smoke Testing")]
        public void MakeMyTriptripMoneyCheck()
        {
            string? currdir = Directory.GetParent(@"../../../")?.FullName;
            string? logfilepath = currdir + "/Logs/TripMoneylog_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";

            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day)
            .CreateLogger();

            Log.Information("Make my trip logo check test started");
            var homePage= new MakeMyTripHomePage(driver);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement? element = driver.FindElement(By.XPath("//*[@id=\"SW\"]/div[1]/div[2]/div[2]/div"));
            IJavaScriptExecutor? executor = (IJavaScriptExecutor)driver;
            executor?.ExecuteScript("arguments[0].click();", element);
            Log.Information("Closed Sign in popup");
            homePage.ClickLogoCheck();
            Log.Information("Make my trip logo clicked");
            try
            {
                TakeScreenShot();
                Assert.That(driver.Url.Contains("makemytrip"));
                Log.Information("Test passed for Make my trip logo Clicking");
                test = extent.CreateTest("Make My Trip Page Loading");
                test.Pass("Make My Trip Page Loaded Successfully");
            }
            catch (AssertionException ex)
            {
                Log.Error($"Test failed for Make my trip logo Clicking. \n Exception: {ex.Message}");
                test = extent.CreateTest("Make My Trip Page Loading");
                test.Fail("Make My Trip Page Loading failed");
            }
        

            Log.Information("Trip Money Page test started");
            Thread.Sleep(3000);
            CoreCodes.ScrollIntoView(driver, driver.FindElement(By.XPath("//*[@id=\"root\"]/div/div[2]/div/main/main/div[8]/div/a/span")));
            var tripMoneyPage=homePage.ClickOrderNowButton();
            Log.Information("Clicked OrderNow Button");
            Log.Information("Trip Money page loaded");

            var tripMoneyAboutUsPage=tripMoneyPage.ClickAboutUsLink();
            Log.Information("Clicked About Us Link");
            Thread.Sleep(3000);
            IWebElement? ExploreAll = driver.FindElement(By.XPath("//*[@id=\"aboutUsWrapper\"]/section[7]/div/div/a"));
            executor?.ExecuteScript("arguments[0].click();", ExploreAll);
            Log.Information("Clicked Explore All Oppurtunity Button");

            List<string> nextwindow = driver.WindowHandles.ToList();
            driver.SwitchTo().Window(nextwindow[1]);
            Thread.Sleep(5000);
            Log.Information("Careers page loaded");
            CareersPage careersPage = new CareersPage(driver);
            var careersJobPage=careersPage.ClickJobButton();
            Log.Information("Clicked Job Button");
            Log.Information("Careers Job page loaded");

            careersJobPage.ClickTechnologyOption();
            Log.Information("Clicked Technology Option");
            var backEndEngineerJavaPage=careersJobPage.ClickBackEndEngineerJavaCard();
            Log.Information("Clicked BackEndEngineerJavaCard");

            List<string> nextwindow1 = driver.WindowHandles.ToList();
            driver.SwitchTo().Window(nextwindow[1]);

            try
            {
                TakeScreenShot();
                Assert.That(driver.Url.Contains("backend"));
                Log.Information("Test passed for Trip Money page");
                test = extent.CreateTest("Trip Money Page Loading");
                test.Pass("Trip Money Page Loaded Successfully");
            }
            catch (AssertionException ex)
            {
                Log.Error($"Test failed for Trip Money Page. \n Exception: {ex.Message}");
                test = extent.CreateTest("Trip Money Page Loading");
                test.Fail("Trip Money Page Loading failed");
            }

        }
        
    }
}
