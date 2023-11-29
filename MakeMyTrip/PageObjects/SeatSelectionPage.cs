using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeMyTrip.PageObjects
{
    internal class SeatSelectionPage
    {
        IWebDriver? driver;
        public SeatSelectionPage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }

        //Arrange
        [FindsBy(How = How.XPath, Using = "//*[@id=\"BOM$BLR$2023-12-20 02:25$6E-6284\"]/div[2]/div[2]/div/div[4]/div[3]")]
        public IWebElement? SeatNumber { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='mainSection_1']/div[2]/button")]
        public IWebElement? ContinueButton { get; set; }

        //Act                              
        public void ClickSeatNumber()
        {
            SeatNumber?.Click();
        }
        public FlightSummaryPayPage ClickContinueButton()
        {
            ContinueButton?.Click();
            ContinueButton?.Click();
            return new FlightSummaryPayPage(driver);
        }
    }
}
