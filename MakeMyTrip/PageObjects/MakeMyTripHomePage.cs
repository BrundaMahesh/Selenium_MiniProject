using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeMyTrip.PageObjects
{
    internal class MakeMyTripHomePage
    {
        IWebDriver? driver;
        public MakeMyTripHomePage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }

        //Arrange
        [FindsBy(How =How.XPath,Using =("//*[@id=\"webklipper-publisher-widget-container-notification-close-div\"]/i"))]
        private IWebElement? AdsPopup { get; set; }

        [FindsBy(How = How.ClassName, Using = ("commonModal__close"))]
        private IWebElement? SignInPopup { get; }

        [FindsBy(How = How.XPath, Using = ("//a[@class='mmtLogo makeFlex']"))]
        private IWebElement? LogoCheck { get; }

        [FindsBy(How = How.ClassName, Using = ("menu_Flights"))]
        private IWebElement? FlightOption { get; }

        //Act
        public void ClickAdsPopup()
        {
            AdsPopup?.Click();
        }
        public void ClickSignInPopup()
        {
            SignInPopup?.Click();
        }

        public void ClickLogoCheck()
        {
            LogoCheck?.Click();
        }

        public void ClickFlightOption()
        {
            FlightOption?.Click();
        }
    }
}
