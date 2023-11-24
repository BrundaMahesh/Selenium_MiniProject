﻿using OpenQA.Selenium;
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
        //[FindsBy(How =How.XPath,Using =("//i[@class='wewidgeticon we_close']"))]
        //private IWebElement? AdsPopup { get; set; }

        [FindsBy(How = How.XPath, Using = ("//span[@class='commonModal__close']"))]
        private IWebElement? SignInPopup { get; }

       [FindsBy(How = How.XPath, Using = ("//a[@class='mmtLogo makeFlex']"))]
        private IWebElement? LogoCheck { get; }

        [FindsBy(How = How.ClassName, Using = ("menu_Flights"))]
        private IWebElement? FlightOption { get; }

        //Act
       //public void ClickAdsPopup()
       // {
       //     AdsPopup?.Click();
       // }
        public void ClickSignInPopup()
        {
            SignInPopup?.Click();
        }

        public void ClickLogoCheck()
        {
            LogoCheck?.Click();
        }

        public MakeMyTripHomePage ClickFlightOption()
        {
            FlightOption?.Click();
            return new MakeMyTripHomePage(driver);
        }
    }
}
