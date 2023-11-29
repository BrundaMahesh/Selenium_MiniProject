using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeMyTripBus.PageObjects
{
    internal class DisplayBusListsFilterPage
    {
        IWebDriver? driver;
        public DisplayBusListsFilterPage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//div[@class='makeFlex']//child::span[text()='AC']")]
        public IWebElement? AC { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='makeFlex']//child::span[text()='Sleeper']")]
        public IWebElement? SeatType { get; set; }
        public void ClickAC()
        {
            AC?.Click();
        }
        public void ClickSeatType()
        {
            SeatType?.Click();
        }
    }
}
