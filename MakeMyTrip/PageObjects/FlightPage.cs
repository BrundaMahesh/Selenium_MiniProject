using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeMyTrip.PageObjects
{
    internal class FlightPage
    {
        IWebDriver? driver;
        public FlightPage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }

        //Arrange
        

        [FindsBy(How = How.XPath, Using = ("//*[@id=\"root\"]/div/div[2]/div/div/div/div[1]/ul/li[1]"))]
        public IWebElement? OneWayRadioButton { get; }

        [FindsBy(How = How.Id, Using = "fromCity")]
        public IWebElement? FromInput { get; set; }

        [FindsBy(How = How.Id, Using = "toCity")]
        public IWebElement? ToInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='departure']//following::span[1]")]
        public IWebElement? Date { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='departure']//following::span[2]")]
        public IWebElement? Month { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='departure']//following::span[3]")]
        public IWebElement? Year { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"travellers\"]")]
        public IWebElement? Travellers { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"root\"]/div/div[2]/div/div/div/div[2]/div[1]/div[5]/div[2]/div[1]/div")]
        public IWebElement? TravelClass { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[contains(@class,'btnApply')]")]
        public IWebElement? ApplyButton { get; set; }

        //[FindsBy(How = How.XPath, Using = ("//*[@id=\"root\"]/div/div[2]/div/div/div/div[2]/div[2]/div[1]"))]
        //private IWebElement? RegularFare { get; set; }


        [FindsBy(How = How.XPath, Using = "//a[contains(@class,'widgetSearchBtn')] ")]
        private IWebElement? SearchButton { get; set; }


        
        //public void clickflightoption()
        //{
        //    Flightoption?.click();  
        //}
        public void ClickOneWayRadioButton()
        {
            OneWayRadioButton?.Click();
        }

        public void ClickFromInput(string fromLoc)
        {
            //FromInput?.Click();
            //Thread.Sleep(3000);
            FromInput?.SendKeys(fromLoc);
            
            FromInput?.SendKeys(Keys.Enter);
        }

        public void ClickToInput(string toLoc)
        {
            ToInput?.SendKeys(toLoc);
            ToInput?.SendKeys(Keys.Enter);
        }
        public void ClickDate(string date)
        {
            Date?.SendKeys(date);
            Date?.SendKeys(Keys.Enter);
        }
        public void ClickMonth(string month)
        {
            Month?.SendKeys(month);
            Month?.SendKeys(Keys.Enter);
        }
        public void ClickYear(string year)
        {
           Year?.SendKeys(year);
           Year?.SendKeys(Keys.Enter);
        }
        public void ClickTravellers(string adult, string travelClass)
        {
            Travellers?.SendKeys(adult);
            Travellers?.SendKeys(Keys.Enter);
            Travellers?.SendKeys(travelClass);

        }
        public void ClickTravelClass(string travelClass)
        {
            TravelClass?.SendKeys(travelClass);
            TravelClass?.SendKeys(Keys.Enter);
        }
        public void ClickApplyButton()
        {
            ApplyButton?.Click();
        }
        //public void ClickRegularFare(string regularfare)
        //{
        //    RegularFare?.SendKeys(regularfare);
        //    RegularFare?.SendKeys(Keys.Enter);
        //}
        
        public DisplayFlightListsFilterPage ClickSearchButton()
        {
            SearchButton?.Click();
            return new DisplayFlightListsFilterPage(driver);
        }
    }
}
