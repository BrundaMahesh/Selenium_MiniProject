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

        [FindsBy(How = How.XPath, Using = "//*[@id=\"root\"]/div/div[2]/div[2]/div/div[1]/div[2]/div[1]/div/div[1]/label/div")]
        public IWebElement? NonStopCheckBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"root\"]/div/div[2]/div[2]/div/div[1]/div[2]/div[1]/div/div[3]")]
        public IWebElement? IndigoCheckBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"bookbutton-RKEY:8a84f288-69d0-4e74-b8f2-b742b36ba9a3:33_0\"]")]
        public IWebElement? ViewPricesButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"bookbutton-RKEY:8a84f288-69d0-4e74-b8f2-b742b36ba9a3:33_0\"]")]
        public IWebElement? BookNowButton { get; set; }
        //Act
        public void ClickNonStopCheckBox()
        {
            NonStopCheckBox?.Click();
        }
        public void ClickIndigoCheckBox()
        {
            IndigoCheckBox?.Click();
        }
        public void ClickViewPricesButton()
        {
            ViewPricesButton?.Click();
        }
    }
}
