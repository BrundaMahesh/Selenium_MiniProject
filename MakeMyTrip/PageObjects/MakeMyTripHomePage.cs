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
        [FindsBy(How = How.XPath, Using = ("//div[@class='headerOuter']"))]
        private IWebElement? SignInPopup { get; }

       [FindsBy(How = How.XPath, Using = ("//a[@class='mmtLogo makeFlex']"))]
        private IWebElement? LogoCheck { get; }

        [FindsBy(How = How.ClassName, Using = ("menu_Flights"))]
        private IWebElement? FlightOption { get; }

        [FindsBy(How = How.XPath, Using = ("//*[@id=\"fromCity\"]"))]
        private IWebElement? FromInput { get; set; }

        [FindsBy(How = How.XPath, Using = ("//*[@id=\"toCity\"]"))]
        private IWebElement? ToInput { get; set; }

        [FindsBy(How = How.XPath, Using = ("/html/body/div[1]/div/div[2]/div/div/div/div[2]/div[1]/div[5]/label"))]
        private IWebElement? Travellers { get; set; }

        [FindsBy(How = How.XPath, Using = ("//*[@id=\"root\"]/div/div[2]/div/div/div/div[2]/div[1]/div[5]/div[2]/div[2]/button"))]
        private IWebElement? ApplyButton { get; set; }

        [FindsBy(How = How.XPath, Using = ("//a[text()='Search']"))]
        private IWebElement? SearchButton { get; set; }

        //Act
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

        public void ClickFromInput(string fromLoc)
        { 
            FromInput?.SendKeys(fromLoc);
            FromInput?.SendKeys(Keys.Enter);   
        }

        public void ClickToInput(string toLoc)
        {
            ToInput?.SendKeys(toLoc);
            ToInput?.SendKeys(Keys.Enter);
        }
        public void ClickTravellers()
        {
            Travellers?.Click();
        }
        public void ClickApplyButton()
        {
            ApplyButton?.Click();
        }

        public void ClickSearchButton()
        {
            SearchButton?.Click();
        }
    }
}
