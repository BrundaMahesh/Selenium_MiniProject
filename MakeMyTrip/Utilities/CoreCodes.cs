using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeMyTrip
{
    public class CoreCodes
    {
        Dictionary<string, string>? properties;
        public IWebDriver? driver;
        public void ReadConfigSettings()
        {
            string currentDirectory = Directory.GetParent(@"../../../").FullName;
            properties = new Dictionary<string, string>();
            string fileName = currentDirectory + "/ConfigSettings/Config.properties";
            string[] lines = File.ReadAllLines(fileName);
            foreach (string line in lines)
            {
                if(!string.IsNullOrWhiteSpace(line) && line.Contains("="))
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
                using(var response=request.GetResponse())
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
            ReadConfigSettings();
            if (properties["browser"].ToLower() == "chrome") 
            {
                driver= new ChromeDriver();
            }
            else if (properties["browser"].ToLower() == "edge")
            {
                driver = new ChromeDriver();
            }
            driver.Url = properties["baseUrl"];
            driver.Manage().Window.Maximize();
        }

        [OneTimeTearDown] 
        public void Cleanup()
        {
            driver.Quit();
        }


        public void TakeScreenShot()
        {
            ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;
            Screenshot screenshot = takesScreenshot.GetScreenshot();

            string currDir = Directory.GetParent(@"../../../").FullName;
            string filename = currDir + "/Screenshots/ss_" + DateTime.Now.ToString("yyyy/MM/dd_HHmmss") + ".png";

            screenshot.SaveAsFile(filename);
            Console.WriteLine("Takes screenshot");

        }

        public static void ScrollIntoView(IWebDriver driver, IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }
    }
}
