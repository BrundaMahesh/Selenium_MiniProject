using MakeMyTripBus.PageObjects;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeMyTripBus
{
    internal class CareersOptionPage
    {
        IWebDriver? driver;
        public CareersOptionPage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//a[contains(@href,'/prod/jobs')]")]
        private IWebElement? JobButton { get; }

        public CareersJobsPage ClickJobButton()
        {
            JobButton?.Click();
            return new CareersJobsPage(driver);
        }
    }
}
