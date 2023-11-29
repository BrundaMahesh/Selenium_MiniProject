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
        [FindsBy(How = How.XPath, Using = "//div[@class='payment__options__tab']//following::li[2]")]
        public IWebElement? UpiOption { get; set; }

        [FindsBy(How = How.Id, Using = "inputVpa")]
        public IWebElement? UpiIdInput { get; set; }

        public void ClickUpiOption()
        {
            UpiOption?.Click();
        }
        public void ClickUpiIdInput(string upiInput)
        {
            UpiIdInput?.SendKeys(upiInput);
            UpiIdInput?.SendKeys(Keys.Enter);
        }
    }
}
