using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeMyTripBus.PageObjects
{
    internal class CareersPage
    {
        IWebDriver? driver;
        public CareersPage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"__next\"]/div/div[1]/div[2]/div/div[2]/div[2]/div[6]/a")]
        private IWebElement? JobButton { get; set; }

        public CareersJobPage ClickJobButton()
        {
            JobButton?.Click();
            return new CareersJobPage(driver);
        }

        
    }
}
