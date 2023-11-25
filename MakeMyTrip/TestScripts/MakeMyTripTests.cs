using MakeMyTrip.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeMyTrip.TestScripts
{
    [TestFixture]
    internal class MakeMyTripTests:CoreCodes
    {
        [Test]
        public void HomePageTest()
        {
            MakeMyTripHomePage makeMyTripHomePage = new MakeMyTripHomePage(driver);
            // Thread.Sleep(5000);
            makeMyTripHomePage.ClickSignInPopup();
            Thread.Sleep(2000);
          
            makeMyTripHomePage.ClickLogoCheck();
            Assert.That(driver.Url.Contains("makemytrip"));

           // Thread.Sleep(5000);
           makeMyTripHomePage.ClickFlightOption();
           
        }
    }
}
