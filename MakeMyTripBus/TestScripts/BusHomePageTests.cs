using MakeMyTripBus.PageObjects;
using MakeMyTripBus.Utilities;
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
            MakeMyTripHomePage makeMyTripHomePage = new MakeMyTripHomePage(driver);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement element = driver.FindElement(By.XPath("//*[@id=\"SW\"]/div[1]/div[2]/div[2]/div"));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].click();", element);
           
            makeMyTripHomePage.ClickLogoCheck();
            try
            {
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

       [Ignore("other")]
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


        [Test, Order(3), Category("Smoke Testing")]
        public void CareersOptionCheck()
        {
            ScrollIntoView(driver, driver.FindElement(By.XPath("//a[text()='Careers']")));
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[text()='Careers']")));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].click();", element);

            try
            {
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


        [Test, Order(2), Category("Smoke Testing")]
        public void LoginTest()
        {
            string? currDir = Directory.GetParent(@"../../../").FullName;
            string? logfilePath = currDir + "/Logs/log_" + DateTime.Now.ToString("yyyy.mm.dd_HH.mm.ss") + ".txt";
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(logfilePath, rollingInterval: RollingInterval.Day)
                .CreateLogger();
            LoginPage loginpage = new LoginPage(driver);
            //driver.Navigate().GoToUrl("https://www.abhibus.com/bus-ticket-offers");
            Thread.Sleep(4000);
            fluentwait.Until(d => loginpage);
            loginpage.ClickLogin();
            try
            {

                IWebElement error = driver.FindElement(By.XPath("//span[text()='Sorry! Referral code is incorrect']"));
                string? errortext = error.Text;
                TakeScreenShot();
                Assert.That(errortext, Does.Contain("Sorry! Referral code is incorrect"));

                LogTestResult("Login Test", "Login Test - Success");
                test = extent.CreateTest("Login Test - Passed");
                test.Pass("Login Test Success");
            }
            catch (AssertionException ex)
            {
                TakeScreenShot();
                LogTestResult("Login Test", "Login Test - Success", ex.Message);
                test.Fail("Offers Test Failed");
            }
        }
    }
}
