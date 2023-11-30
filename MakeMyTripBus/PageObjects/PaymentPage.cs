using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeMyTripBus.PageObjects
{
    internal class PaymentPage
    {

        IWebDriver? driver;
        public PaymentPage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//div[starts-with(@class,'payment__option__title font12')]/span[text()='UPI Options']")]
        public IWebElement? UpiOption { get; set; }

        [FindsBy(How = How.Id, Using = "inputVpa")]
        public IWebElement? UpiIdInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"root\"]/div/div[1]/main/div[1]/div[3]/div[2]/div[1]/div[1]/div/div/button")]
        public IWebElement? VerifyAndPayButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"root\"]/div/div[2]/div/div[2]/button")]
        public IWebElement? CancelButton { get; set; }

        public void ClickUpiOption()
        {
            UpiOption?.Click();
        }
        public void ClickUpiIdInput(string upiInput)
        {
            UpiIdInput?.SendKeys(upiInput);
            UpiIdInput?.SendKeys(Keys.Enter);
        }
        public void ClickVerifyAndPayButton()
        {
            VerifyAndPayButton?.Click();
        }
        public void ClickCancelButton()
        {
            CancelButton?.Click();
        }
    }
}
