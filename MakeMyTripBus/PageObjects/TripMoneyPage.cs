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
    internal class TripMoneyPage
    {
        IWebDriver? driver;
        public TripMoneyPage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"listingPage_header_aboutUs\"]/a")]
        public IWebElement? AboutUsLink { get; set; }

        
        public TripMoneyAboutUsPage ClickAboutUsLink()
        {
            AboutUsLink?.Click();
            return new TripMoneyAboutUsPage(driver);
        }
        
    }
}
