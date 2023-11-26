using MakeMyTrip.PageObjects;
using MakeMyTrip.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeMyTrip.TestScripts
{
    [TestFixture]
    internal class SearchFlightTests:CoreCodes
    {
       [Test]
        public void SearchFlightTest()
        {
            var homePage = new MakeMyTripHomePage(driver);
            if (!driver.Url.Contains("https://www.makemytrip.com/"))
            {
                driver.Navigate().GoToUrl("https://www.makemytrip.com/");
            }
            var searchFlightPage = homePage.ClickFlightOption();
        }
    }
}
