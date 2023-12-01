using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeMyTripBus.PageObjects
{
    internal class TripMoneyAboutUsPage
    {
        IWebDriver? driver;
        public TripMoneyAboutUsPage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//*[@id=\"aboutUsWrapper\"]/section[7]/div/div/a")]
        public IWebElement? ExploreAllOppurtunityButton { get; set; }

        public CareersPage ClickExploreAllOppurtunityButton()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            ExploreAllOppurtunityButton?.Click();
            return new CareersPage(driver);
        }
    }
}
