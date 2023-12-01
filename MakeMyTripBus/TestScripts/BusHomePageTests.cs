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
    internal class BusHomePageTests:CoreCodes
    {
        
        [Test,Order(1),Category("Smoke Testing")]
        public void MakeMyTripLogoCheck()
        {
            string? currdir = Directory.GetParent(@"../../../")?.FullName;
            string? logfilepath = currdir + "/Logs/Logochecklog_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";

            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day)
            .CreateLogger();

            Log.Information("Make my trip logo check test started");
            MakeMyTripHomePage makeMyTripHomePage = new MakeMyTripHomePage(driver);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement? element = driver.FindElement(By.XPath("//*[@id=\"SW\"]/div[1]/div[2]/div[2]/div"));
            IJavaScriptExecutor? executor = (IJavaScriptExecutor)driver;
            executor?.ExecuteScript("arguments[0].click();", element);
            Log.Information("Closed Sign in popup");
            makeMyTripHomePage.ClickLogoCheck();
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
        }

        [Test, Order(2), Category("Smoke Testing")]
        public void TripMoneyOrderButtonCheck()
        {
            string? currdir = Directory.GetParent(@"../../../")?.FullName;
            string? logfilepath = currdir + "/Logs/OrderButtonchecklog_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";

            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day)
            .CreateLogger();

            Log.Information("Trip Money order button check test started");
            ScrollIntoView(driver, driver.FindElement(By.XPath("//*[@id=\"root\"]/div/div[2]/div/main/main/div[8]/div/a")));
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"root\"]/div/div[2]/div/main/main/div[8]/div/a")));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].click();", element);
            Log.Information("Order Now button clicked");
            try
            {
                TakeScreenShot();
                Assert.That(driver.Url.Contains("tripmoney"));
                Log.Information("Test passed for Trip Money Order button option Clicking");
                test = extent.CreateTest("Trip Money Page Loading");
                test.Pass("Trip Money Page Loaded Successfully");
            }
            catch (AssertionException ex)
            {
                Log.Error($"Test failed for Trip Money Order button option Clicking. \n Exception: {ex.Message}");
                test = extent.CreateTest("Trip Money Page Loading");
                test.Fail("Trip Money Page Loading failed");
            }
        }
        [Test, Order(3), Category("Smoke Testing")]
        public void CareersOptionCheck()
        {
            driver.Navigate().GoToUrl("https://www.makemytrip.com/");
            string? currdir = Directory.GetParent(@"../../../")?.FullName;
            string? logfilepath = currdir + "/Logs/Careeroptionchecklog_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";

            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day)
            .CreateLogger();

            Log.Information("Careers option check test started");
            ScrollIntoView(driver, driver.FindElement(By.XPath("//a[text()='Careers']")));
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[text()='Careers']")));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].click();", element);
            Log.Information("Careers option clicked");

            try
            {
                TakeScreenShot();
                Assert.That(driver.Url.Contains("careers"));
                Log.Information("Test passed for Careers option Clicking");
                test = extent.CreateTest("Careers Option Page Loading");
                test.Pass("Careers Option Page Loaded Successfully");
            }
            catch (AssertionException ex)
            {
                Log.Error($"Test failed for Careers option Clicking. \n Exception: {ex.Message}");
                test = extent.CreateTest("Careers Option Page Loading");
                test.Fail("Careers Option Page Loading failed");
            }
        }
        [Ignore("All link tests")]
        [Test, Order(4), Category("Smoke Testing")]
        public void AllLinksStatusTest()
        {
            List<IWebElement> allLinks = driver.FindElements(By.TagName("a")).ToList();
            foreach (var link in allLinks)
            {
                string url = link.GetAttribute("href");
                if (url == null)
                {
                    Console.WriteLine("URL is null");
                    continue;
                }
                else
                {
                    bool isWorking = CheckLinkStatus(url);
                    if (isWorking)
                    {
                        Console.WriteLine(url + " is working");
                    }
                    else
                    {
                        Console.WriteLine(url + " is not working");
                    }
                }
            }
        }


        

        

        
    }
}
