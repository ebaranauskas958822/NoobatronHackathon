using NewTest.GuessTheFlag;
using NewTest.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NewTest.Guess_the_flag
{
   public  class FlagTest
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
            FlagWeb.GoToPage();
            FlagWeb.SelectValue();
        }
    }
}
