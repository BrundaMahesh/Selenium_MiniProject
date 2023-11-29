using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeMyTrip.PageObjects
{
    internal class DisplayFlightListsFilterPage
    {
        IWebDriver? driver;
        public DisplayFlightListsFilterPage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }

        //Arrange
        [FindsBy(How = How.XPath, Using = "//*[@id=\"root\"]/div/div[2]/div[2]/div[2]/div/div/div[3]/button")]
        public IWebElement? OkayGotItPopUp { get; set; }

        [FindsBy(How = How.XPath, Using = "(//p[@class='checkboxTitle' and contains(text(),'Non Stop')])[1]")]
        public IWebElement? NonStopCheckBox { get; set; }

        [FindsBy(How = How.XPath, Using = "(//p[@class='checkboxTitle' and contains(text(),'IndiGo')])[1]")]
        public IWebElement? IndigoCheckBox { get; set; }

        [FindsBy(How = How.XPath, Using = "(//div[@class='clusterContent']//following::button)[1]")]
        public IWebElement? ViewPricesButton { get; set; }

        [FindsBy(How = How.XPath, Using = "(//div[@class='viewFareRowWrap']//following::button)[2]")]
        public IWebElement? BookNowButton { get; set; }
        //Act
        public void ClickOkayGotItPopUp()
        {
            OkayGotItPopUp?.Click();
        }
        public DisplayFlightListsFilterPage ClickNonStopCheckBox()
        {
            NonStopCheckBox?.Click();
            return new DisplayFlightListsFilterPage(driver);
        }
        public DisplayFlightListsFilterPage ClickIndigoCheckBox()
        {
            IndigoCheckBox?.Click();
            return new DisplayFlightListsFilterPage(driver);
        }
        public DisplayFlightListsFilterPage ClickViewPricesButton()
        {
            ViewPricesButton?.Click();
            return new DisplayFlightListsFilterPage(driver);
        }
        public PassengerDetailsPage ClickBookNowButton()
        {
            BookNowButton?.Click();
            return new PassengerDetailsPage(driver);
       
        }
    }
}
