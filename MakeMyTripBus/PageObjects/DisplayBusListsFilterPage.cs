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
        private IWebElement? AC { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='makeFlex']//child::span[text()='Sleeper']")]
        private IWebElement? SeatType { get; set; }

        [FindsBy(How = How.XPath, Using = "(//div[@class='busListingContainer']//following::div[@class='busCardContainer '])[1]")]
        private IWebElement? SelectSeatButton { get; set; }

        [FindsBy(How = How.XPath, Using = "(//div[@class='makeAbsolute']/div/li)[1]")]
        private IWebElement? ParticularSeat { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"busList\"]/div[2]/div[2]/div[1]/div[3]/div/div/div[2]/div[2]/div[1]/ul/li[1]")]
        private IWebElement? PickUpPoint { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"busList\"]/div[2]/div[2]/div[1]/div[3]/div/div/div[2]/div[2]/div[2]/ul/li[1]")]
        private IWebElement? DropPoint { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"busList\"]/div[2]/div[2]/div[1]/div[3]/div/div/div[2]/div[3]/div/div[2]")]
        private IWebElement? ContinueButton { get; set; }
        public DisplayBusListsFilterPage ClickAC()
        {
            AC?.Click();
            return new DisplayBusListsFilterPage(driver);
        }
        public DisplayBusListsFilterPage ClickSeatType()
        {
            SeatType?.Click();
            return new DisplayBusListsFilterPage(driver);
        }
        public DisplayBusListsFilterPage ClickSelectSeatButton()
        {
            SelectSeatButton?.Click();
            return new DisplayBusListsFilterPage(driver);
        }

        public void ClickParticularSeat(string seatposition)
        {
           IWebElement particularSeat= driver.FindElement(By.XPath("(//div[@class='makeAbsolute']/div/li)" + "[" + seatposition + "]"));
           particularSeat?.Click();
        }

        public void ClickPickUpPoint()
        {
            PickUpPoint?.Click();
        }
        public void ClickDropPoint()
        {
            DropPoint?.Click();
        }
        public PassengerDetailsPage ClickContinueButton()
        {
            ContinueButton?.Click();
            return new PassengerDetailsPage(driver);
        }
    }
}
