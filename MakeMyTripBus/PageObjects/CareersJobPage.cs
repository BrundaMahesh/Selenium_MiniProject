using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeMyTripBus.PageObjects
{
    internal class CareersJobPage
    {
        IWebDriver? driver;
        public CareersJobPage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//*[@id=\"__next\"]/div/section[2]/div[2]/div[1]")]
        public IWebElement? TechnologyOption { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"jobs-list\"]/div/a[1]/div/div/div[3]/span")]
        public IWebElement? BackEndEngineerJavaCard { get; set; }
        public void ClickTechnologyOption()
        {
            TechnologyOption?.Click();
        }
        public BackEndEngineerJavaPage ClickBackEndEngineerJavaCard()
        {
            BackEndEngineerJavaCard?.Click();
            return new BackEndEngineerJavaPage(driver);
        }
    }
}
