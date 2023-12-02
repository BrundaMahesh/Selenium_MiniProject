using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeMyTripBus.PageObjects
{
    internal class PassengerDetailsPage
    {
        IWebDriver? driver;
        public PassengerDetailsPage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.Id, Using = "fname")]
        private IWebElement? NameInput { get; set; }

        [FindsBy(How = How.Id, Using = "age")]
        private IWebElement? AgeInput { get; set; }

        [FindsBy(How = How.XPath, Using = "(//div[@class='genderTab makeFlex']//child::span)[1]")]
        private IWebElement? Gender { get; set; }

        [FindsBy(How = How.ClassName, Using = "dropdownFieldWpr__inputWpr")]
        private IWebElement? StateDropDown { get; set; }

        [FindsBy(How = How.XPath, Using = "(//*[@class='dropdownListWpr'])/li[1]")]
        private IWebElement? ParticularState { get; set; }

        [FindsBy(How = How.ClassName, Using = "checkboxWithLblWpr__label")]
        private IWebElement? ConfirmAndSaveCheckBox{ get; set; }

        [FindsBy(How = How.Id, Using = "contactEmail")]
        private IWebElement? EmailInput { get; set; }

        [FindsBy(How = How.Id, Using = "mobileNumber")]
        private IWebElement? MobileNumberInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"root\"]/div[4]/div/section[1]/div[5]/div/div[1]/label/span")]
        private IWebElement? SecureTripCheckbox { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"root\"]/div[4]/div/section[2]/div[3]/div[2]/div")]
        private IWebElement? ContinueButton { get; set; }
        public void ClickNameInput(string name)
        {
            NameInput?.SendKeys(name);
            NameInput?.SendKeys(Keys.Enter);
        }
        public void ClickAgeInput(string age)
        {
            AgeInput?.SendKeys(age);
            AgeInput?.SendKeys(Keys.Enter);
        }
        public void ClickGender()
        {
            Gender?.Click();
        }
        public void ClickStateDropDown()
        {
            StateDropDown?.Click();
        }
        public void ClickParticularState()
        {
            ParticularState?.Click();
        }
        public void ClickConfirmAndSaveCheckBox()
        {
            ConfirmAndSaveCheckBox?.Click();
        }
        public void ClickEmailInput(string email)
        {
            EmailInput?.SendKeys(email);
            EmailInput?.SendKeys(Keys.Enter);
        }
        public void ClickMobileNumberInput(string mobileNumber)
        {
            MobileNumberInput?.SendKeys(mobileNumber);
            MobileNumberInput?.SendKeys(Keys.Enter);
        }
        public void ClickSecureTripCheckbox()
        {
            SecureTripCheckbox?.Click();
        }
        public PaymentPage ClickContinueButton()
        {
            ContinueButton?.Click();
            return new PaymentPage(driver);
        }
    }
}
