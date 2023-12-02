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
        
        [Test,Order(1),Category("Smoke Testing")]
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
                test = extent.CreateTest("Make My Trip Logo check");
                test.Pass("Make My Trip Page Loaded Successfully");
            }
            catch (AssertionException ex)
            {
                Log.Error($"Test failed for Make my trip logo Clicking. \n Exception: {ex.Message}");
                test = extent.CreateTest("Make My Trip Logo Check");
                test.Fail("Make My Trip Page Loading failed");
            }

            CoreCodes.ScrollIntoView(driver, driver.FindElement(By.XPath("//*[@id=\"root\"]/div/footer/div[1]/div/ul[2]/li[1]/a")));

            string? aboutUsOption = driver.FindElement(By.XPath("//*[@id=\"root\"]/div/footer/div[1]/div/ul[2]/li[1]/a")).Text;
            TakeScreenShot();
            Assert.AreEqual(aboutUsOption, "About Us");
            Log.Information("AboutUs Option visible");

            string? investorRelationOption = driver.FindElement(By.XPath("//*[@id=\"root\"]/div/footer/div[1]/div/ul[2]/li[2]/a")).Text;
            TakeScreenShot();
            Assert.AreEqual(investorRelationOption, "Investor Relations");
            Log.Information("Investor Option visible");
            Log.Information("Careers Page test started");
            Thread.Sleep(3000);
            //I tried all waits here, it's not working
            
            IWebElement? CareersOption = driver.FindElement(By.XPath("//*[@id=\"root\"]/div/footer/div[1]/div/ul[2]/li[3]/a"));
            executor?.ExecuteScript("arguments[0].click();", CareersOption);
            Log.Information("Clicked Careers option");
            Log.Information("Careers page loaded");

            try
            {
                TakeScreenShot();
                Assert.That(driver.Url.Contains("careers"));
                Log.Information("Test passed for careers page");
                test = extent.CreateTest("Make My Trip Careers Page");
                test.Pass("Careers page Loaded Successfully");
            }
            catch (AssertionException ex)
            {
                Log.Error($"Test failed for Careers Page. \n Exception: {ex.Message}");
                test = extent.CreateTest("Make My Trip Careers Page");
                test.Fail("Careers page Loaded Successfully");
            }

        }
        
    }
}
