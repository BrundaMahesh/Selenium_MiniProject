﻿using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
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
        public IWebElement? FromInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@title='From']")]
        public IWebElement? FromInputText { get; set; }

        [FindsBy(How = How.XPath, Using = "(//span[starts-with(@class,'sr_city')])[1]\r\n")]
        public IWebElement? SelectFromInputText { get; set; }

        


        [FindsBy(How = How.Id, Using = "toCity")]
        public IWebElement? ToInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@aria-controls='react-autowhatever-1']")]
        public IWebElement? ToInputText { get; set; }

        [FindsBy(How = How.XPath, Using = "(//ul[@role='listbox']//child::span[contains(@class,'sr_city')])[position()=1]")]
        public IWebElement? SelectToInputText { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='travelDate']//following::span[1]")]
        public IWebElement? Date { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='travelDate']//following::span[2]")]
        public IWebElement? Month { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='travelDate']//following::span[3]")]
        public IWebElement? Year { get; set; }

        [FindsBy(How = How.Id, Using = "search_button")]
        private IWebElement? SearchButton { get; set; }

        public void ClickFromInput(string fromLoc)
        {
            FromInputText?.SendKeys(fromLoc);
            FromInputText?.SendKeys(Keys.Enter);
        }

        public void ClickOnSelectFromInput()
        {
            SelectFromInputText?.Click();
        }
        public void ClickOnFromInput()
        {
            FromInput?.Click();
        }




        public void ClickToInput(string toLoc)
        {
            ToInputText?.SendKeys(toLoc);
            ToInputText?.SendKeys(Keys.Enter);
        }

        public void ClickOnSelectToInput()
        {
            SelectToInputText?.Click();
        }
        //public void ClickOnToInput()
        //{
        //    ToInput?.Click();
        //}
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
        public DisplayBusListsFilterPage ClickSearchButton()
        {
            SearchButton?.Click();
            return new DisplayBusListsFilterPage(driver);
        }
    }
}