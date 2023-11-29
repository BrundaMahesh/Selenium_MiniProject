﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeMyTripBus.PageObjects
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
        [FindsBy(How = How.XPath, Using = "//*[@id=\"SW\"]/div[1]/div[2]/div[2]/div")]
        private IWebElement? SignInPopup { get;  }

       [FindsBy(How = How.XPath, Using = "//a[@class='mmtLogo makeFlex']")]
        public IWebElement? LogoCheck { get; set; }

        [FindsBy(How = How.XPath, Using = "//li[@class='menu_Buses']")]
        public IWebElement? BusesOption { get; set; }

        //Act
        public void ClickSignInPopup()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(10);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Until(d => LogoCheck.Displayed);
            SignInPopup?.Click();
        }

        public void ClickLogoCheck()
        {
            LogoCheck?.Click();
        }
        public BusPage ClickBusesOption()
        {
           BusesOption?.Click();
           return new BusPage(driver);
        }
    }
}