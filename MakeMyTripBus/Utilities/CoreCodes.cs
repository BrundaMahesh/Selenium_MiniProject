using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using NUnit.Framework;

namespace MakeMyTripBus.Utilities
{
    internal class CoreCodes
    {
        Dictionary<string, string>? properties;
        public IWebDriver? driver;

        public ExtentReports extent;
        ExtentSparkReporter sparkReporter;
        public ExtentTest test;
        public void ReadConfigSettings()
        {
            string currentDirectory = Directory.GetParent(@"../../../").FullName;
            properties = new Dictionary<string, string>();
            string fileName = currentDirectory + "/ConfigSettings/Config.properties";
            string[] lines = File.ReadAllLines(fileName);
            foreach (string line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line) && line.Contains("="))
                {
                    string[] parts = line.Split('=');
                    string key = parts[0].Trim();
                    string value = parts[1].Trim();
                    properties[key] = value;
                }
            }
        }
        public bool CheckLinkStatus(string url)
        {
            try
            {
                var request = (System.Net.HttpWebRequest)
                    System.Net.WebRequest.Create(url);
                request.Method = "HEAD";
                using (var response = request.GetResponse())
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        [OneTimeSetUp]
        public void InitializeBrowser()
        {
            string currdir = Directory.GetParent(@"../../../").FullName;
            extent = new ExtentReports();
            sparkReporter = new ExtentSparkReporter(currdir + "/ExtentReports/extent-report"
                + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".html");

            extent.AttachReporter(sparkReporter);

            ReadConfigSettings();
            if (properties["browser"].ToLower() == "chrome")
            {
                driver = new ChromeDriver();
            }
            else if (properties["browser"].ToLower() == "edge")
            {
                driver = new EdgeDriver();
            }
            driver.Url = properties["baseUrl"];
            driver.Manage().Window.Maximize();
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            driver.Quit();
            extent.Flush();
        }


        public void TakeScreenShot()
        {
            ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;
            Screenshot screenshot = takesScreenshot.GetScreenshot();

            string currDir = Directory.GetParent(@"../../../").FullName;
            string filename = currDir + "/Screenshots/ss_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png";

            screenshot.SaveAsFile(filename);
            Console.WriteLine("Takes screenshot");

        }

        public static void ScrollIntoView(IWebDriver driver, IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        protected void LogTestResult(string testName, string result, string errorMessage = null)
        {
            Log.Information(result);

            test = extent.CreateTest(testName);

            if (errorMessage == null)
            {
                test.Pass(result);
            }
            else
            {
                Log.Error($"Test failed for {testName}. \n Exception: \n {errorMessage}");
                test.Fail(result);
            }
        }

    }
}
