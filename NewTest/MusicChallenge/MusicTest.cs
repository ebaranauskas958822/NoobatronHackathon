using NewTest.GuessTheFlag;
using NewTest.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NewTest.MusicChallenge
{
   public  class MusicTest
    {
        private static readonly IWebDriver Driver = SeleniumHelpers.Driver;

        [OneTimeSetUp]

        public void SetupTests()
        {
            if (SeleniumHelpers.Driver == null)
            {
                SeleniumHelpers.Driver = new ChromeDriver();
            }
        }

        [OneTimeTearDown]

        public void TearDown()
        {
            //if (SeleniumHelpers.Driver != null)
            //{
            //    SeleniumHelpers.Driver.Quit();
            //}
        }

        [Test]
        public void SelectCountry()
        {
            MusicWeb.GoToPianoPage();
            MusicWeb.PlayPiano();
        }
    }
}
