using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeMyTripBus.PageObjects
{
    internal class BusPage
    {
        IWebDriver? driver;
        public BusPage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.Id, Using = "fromCity")]
        private IWebElement? FromInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@title='From']")]
        private IWebElement? FromInputText { get; set; }

        [FindsBy(How = How.XPath, Using = "(//span[starts-with(@class,'sr_city')])[1]\r\n")]
        private IWebElement? SelectFromInputText { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@title='To']")]
        private IWebElement? ToInputText { get; set; }

        [FindsBy(How = How.XPath, Using = "(//span[starts-with(@class,'sr_city')])[1]")]
        private IWebElement? SelectToInputText { get; set; }

        IWebElement? GetDate(string date)
        {
            return driver.FindElement(By.XPath("//div[@class='DayPicker-Months']//child::div[@aria-label='"+date+"']"));
        }
        public string? GetDateText(string date)
        {
            return GetDate(date)?.Text;
        }
        public void ClickGetDate(string date)
        {
            GetDate(date)?.Click(); 
        }

        [FindsBy(How = How.Id, Using = "search_button")]
        private IWebElement? SearchButton { get; set; }

        public void ClickFromInput(string fromLoc)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            FromInputText?.SendKeys(fromLoc);
            FromInputText?.SendKeys(Keys.Enter);
        }
        public void ClickOnSelectFromInput()
        {
            SelectFromInputText?.Click();
        }
        public void ClickOnFromInput()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            FromInput?.Click();
        }
        public void ClickToInputText(string toLoc)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            ToInputText?.SendKeys(toLoc);
            ToInputText?.SendKeys(Keys.Enter);
        }
        public void ClickOnSelectToInput()
        {

            SelectToInputText?.Click();
        } 
        public DisplayBusListsFilterPage ClickSearchButton()
        {
            SearchButton?.Click();
            return new DisplayBusListsFilterPage(driver);
        }
    }
}
