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
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"SW\"]/div[1]/div[2]/div[2]/div")));
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

        [Test, Order(3), Category("Smoke Testing")]
        public void CareersJobPageCheck()
        {

            //ScrollIntoView(driver, driver.FindElement(By.XPath("//a[text()='Careers']")));
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[text()='Careers']")));
            //IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            //executor.ExecuteScript("arguments[0].click();", element);
            //try
            //{
            //    Assert.That(driver.Url.Contains("job"));
            //    Log.Information("Test passed for Job button Clicking");
            //    test = extent.CreateTest("Careers Option Page Loading");
            //    test.Pass("Careers Option Page Loaded Successfully");
            //}
            //catch (AssertionException ex)
            //{
            //    Log.Error($"Test failed for Careers option Clicking. \n Exception: {ex.Message}");
            //    test = extent.CreateTest("Careers Option Page Loading");
            //    test.Fail("Careers Option Page Loading failed");
            //}
        }
    }
}
