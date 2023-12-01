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
        [Test, Order(3), Category("Smoke Testing")]
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


        [Test, Order(2), Category("Smoke Testing")]
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

        
        //[Test, Order(4), Category("Smoke Testing")]
        //public void CareersPageJobButtonVisibilityCheck()
        //{
        //    Thread.Sleep(3000);
        //    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        //    IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//a[span[text()='Jobs']])[1]")));
        //    string jobButton = driver.FindElement(By.XPath("(//a[span[text()='Jobs']])[1]")).Text;
        //    try
        //    {
        //        Assert.That(jobButton.Contains("jobs"));
        //        Log.Information("Test passed for Carers Page Job button Visibility Check");
        //        test = extent.CreateTest("Carers Page Job button Visibility ");
        //        test.Pass("Carers Page Job button Visibility Passed");
        //    }
        //    catch (AssertionException ex)
        //    {
        //        Log.Error($"Test failed for Carers Page Job button Visibility. \n Exception: {ex.Message}");
        //        test = extent.CreateTest("Carers Page Job button Visibility");
        //        test.Fail("Carers Page Job button Visibility Failed");
        //    }
        //}
    }
}
