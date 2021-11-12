using NewTest.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NewTest.Examples.Tests
{
    public class Test
    {
        private static readonly IWebDriver Driver = SeleniumHelpers.Driver;

        [OneTimeSetUp]

        public void SetupTests()
        {
            if (SeleniumHelpers.Driver == null)
            {
                SeleniumHelpers.Driver = new ChromeDriver();
                //test.
            }
        }

        [OneTimeTearDown]

        public void TearDown()
        {
            if (SeleniumHelpers.Driver != null)
            {
                SeleniumHelpers.Driver.Quit();
            }
        }

        [Test]
        public void CheckTitle()
        {
            Class1.GoToPage();
            Assert.AreEqual(Class1.GetText(), "Next steps");
        }
    }
}
