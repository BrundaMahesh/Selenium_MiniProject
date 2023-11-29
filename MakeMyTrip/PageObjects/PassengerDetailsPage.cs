using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeMyTrip.PageObjects
{
    internal class PassengerDetailsPage
    {
        IWebDriver? driver;
        public PassengerDetailsPage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[contains(text(),'No,')]")]
        public IWebElement? NoRadioButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "addTravellerBtn")]
        public IWebElement? AddNewAdult { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"wrapper_ADULT\"]/div[3]/div[2]/div[2]/div/div/div/div[1]/div/input")]
        public IWebElement? FirstNameInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"wrapper_ADULT\"]/div[3]/div[2]/div[2]/div/div/div/div[2]/div/input")]
        public IWebElement? LastNameInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='MALE']")]
        public IWebElement? MaleButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"Mobile No\"]/div/input")]
        public IWebElement? MobileNumberInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"Email\"]/div/input")]
        public IWebElement? EmailInput { get; set; }

        //[FindsBy(How = How.XPath, Using = "//*[@id=\"pincode_gst_info\"]")]
        //public IWebElement? PincodeInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"Email\"]/div/input")]
        public IWebElement? StateDropDown { get; set; }

        [FindsBy(How = How.XPath, Using = "//p[@class='checkboxWithLblWpr__label' and contains(text(),'Confirm and save billing details to your profile')]")]
        public IWebElement? ConfirmAndSaveCheckBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"mainSection_0\"]/div[2]/button")]
        public IWebElement? ContinueButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"root\"]/div/div[2]/div[4]/div/div[2]/button")]
        public IWebElement? ConfirmButton { get; set; }
        public void ClickNoRadioButton()
        {
            NoRadioButton?.Click();
        }
        public void ClickAddNewAdult()
        {
            AddNewAdult?.Click();
        }
        public void ClickFirstNameInput(string firstname)
        {
            FirstNameInput?.SendKeys(firstname);
            FirstNameInput?.SendKeys(Keys.Enter);
        }
        public void ClickLastNameInput(string lastname)
        {
            LastNameInput?.SendKeys(lastname);
            LastNameInput?.SendKeys(Keys.Enter);
        }
        public void ClickMaleButton()
        {
            MaleButton?.Click();
        }
        public void ClickMobileNumberInput(string mobilenumber)
        {
            MobileNumberInput?.SendKeys(mobilenumber);
            MobileNumberInput?.SendKeys(Keys.Enter);
        }
        public void ClickEmailInput(string email)
        {
            EmailInput?.SendKeys(email);
            EmailInput?.SendKeys(Keys.Enter);
        }
        //public void ClickPincodeInput(string pincode)
        //{
        //    PincodeInput?.SendKeys(pincode);
        //    PincodeInput?.SendKeys(Keys.Enter);
        //}
        public void ClickStateDropDown()
        {
            StateDropDown?.Click();
        }
        public void ClickConfirmAndSaveCheckBox()
        {
            Thread.Sleep(3000);
            ConfirmAndSaveCheckBox?.Click();
        }
        public void ClickContinueButton()
        {
            ContinueButton?.Click();
        }
        public SeatSelectionPage ClickConfirmButton()
        {
            ConfirmButton?.Click();
            return new SeatSelectionPage(driver);
        }
    }
}
