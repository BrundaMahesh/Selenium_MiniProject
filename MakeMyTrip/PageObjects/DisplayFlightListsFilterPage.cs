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
        [FindsBy(How = How.XPath, Using = "//*[@id=\"root\"]/div/div[2]/div[2]/div/div[1]/div[2]/div[2]/div/div[1]")]
        public IWebElement? NonStopCheckBox { get; set; }



        //Act
        public void ClickNonStopCheckBox()
        {
            NonStopCheckBox?.Click();
        }
    }
}
