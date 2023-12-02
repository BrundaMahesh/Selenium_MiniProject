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
    internal class MakeMyTripCareersHomePageTests:CoreCodes
    {
        
        [Test,Order(1),Category("End to End Testing")]
        public void MakeMyTripCareersHomePageCheck()
        {
            string? currdir = Directory.GetParent(@"../../../")?.FullName;
            string? logfilepath = currdir + "/Logs/Careerslog_" +
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
        

            Log.Information("Careers Page test started");
            Thread.Sleep(3000);
            CoreCodes.ScrollIntoView(driver, driver.FindElement(By.XPath("//*[@id=\"root\"]/div/footer/div[1]/div/ul[2]/li[3]/a")));
            IWebElement? CareersOption = driver.FindElement(By.XPath("//*[@id=\"root\"]/div/footer/div[1]/div/ul[2]/li[3]/a"));
            executor?.ExecuteScript("arguments[0].click();", CareersOption);
            Log.Information("Clicked Careers option");
            Log.Information("Careers page loaded");

            //CareersPage careersPage = new CareersPage(driver);
            Thread.Sleep(1000);
            IWebElement? JobButton = driver.FindElement(By.XPath("//*[@id=\"__next\"]/div/div[1]/div[2]/div/div[2]/div[2]/div[6]/a"));
            executor?.ExecuteScript("arguments[0].click();", JobButton);
            //var careersJobPage = careersPage.ClickJobButton();
            Log.Information("Clicked Job Button");
            //Thread.Sleep(2000);
            Log.Information("Careers Jobpage loaded");


            IWebElement? TechnologyOption = driver.FindElement(By.XPath("//*[@id=\"__next\"]/div/section[2]/div[2]/div[1]"));
            executor?.ExecuteScript("arguments[0].click();", TechnologyOption);
            Log.Information("Clicked Technology Option");

            IWebElement? BackEnd = driver.FindElement(By.XPath("//*[@id=\"jobs-list\"]/div/a[1]/div/div/div[3]/span"));
            executor?.ExecuteScript("arguments[0].click();", BackEnd);
            Log.Information("Clicked BackEndEngineerJavaCard");

            try
            {
                TakeScreenShot();
                Assert.That(driver.Url.Contains("backend"));
                Log.Information("Test passed for careers page");
                test = extent.CreateTest("Trip Careers Loading");
                test.Pass("Careers page Loaded Successfully");
            }
            catch (AssertionException ex)
            {
                Log.Error($"Test failed for Careers Page. \n Exception: {ex.Message}");
                test = extent.CreateTest("Trip Careers Loading");
                test.Fail("Careers page Loaded Successfully");
            }

        }
        
    }
}
