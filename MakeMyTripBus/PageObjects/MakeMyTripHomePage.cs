using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeMyTripBus.PageObjects
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
        [FindsBy(How = How.XPath, Using = "//*[@id=\"SW\"]/div[1]/div[2]/div[2]/div")]
        private IWebElement? SignInPopup { get; set; }

       [FindsBy(How = How.XPath, Using = "//a[@class='mmtLogo makeFlex']")]
        public IWebElement? LogoCheck { get; set; }

        [FindsBy(How = How.XPath, Using = "//li[@class='menu_Buses']")]
        public IWebElement? BusesOption { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[text()='Careers']")]
        public IWebElement? CareersOption { get; set; }

        [FindsBy(How = How.XPath, Using = "//p[@data-cy='LoginHeaderText']")]
        public IWebElement? LoginButton { get; set; }

        [FindsBy(How = How.Id, Using = "username")]
        public IWebElement? LoginInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='capText font16']")]
        public IWebElement? ContinueButton { get; set; }
        //Act
        public void ClickSignInPopup()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(10);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Until(d => SignInPopup.Displayed);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", SignInPopup);

        }

        public void ClickLogoCheck()
        {
            LogoCheck?.Click();
        }
        public BusPage ClickBusesOption()
        {
            DefaultWait<IWebDriver?> fluentWait = new DefaultWait<IWebDriver?>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(20);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Until(d => BusesOption?.Displayed);
            BusesOption?.Click();
            return new BusPage(driver);
        }
        public CareersOptionPage ClickCareersOption()
        {
            CareersOption?.Click();
            return new CareersOptionPage(driver);
        }


        public void ClickLoginButton()
        {
            LoginButton?.Click();
        }
        public void ClickLoginInput(string number)
        {
            LoginInput?.SendKeys(number);
            LoginInput?.SendKeys(Keys.Enter);
        }
        public void ClickContinueButton()
        {
            ContinueButton?.Click();
        }

    }
}
