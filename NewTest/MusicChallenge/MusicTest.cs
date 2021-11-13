using NewTest.GuessTheFlag;
using NewTest.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NewTest.MusicChallenge
{
    [TestFixture]
    public  class MusicTest
    {
        private static readonly IWebDriver Driver = SeleniumHelpers.Driver;

        [SetUp]

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
            if (SeleniumHelpers.Driver != null)
            {
                SeleniumHelpers.Driver.Quit();
            }
        }

        [Parallelizable]
        [Test]
        public void PlayPiano()
        {
            MusicPiano.GoToPianoPage();
            MusicPiano.PlayPiano();
        }

        [Parallelizable]
        [Test]
        public void PlayDrumKit()
        {
            MusicDrumKit.GoToDrumPage();
            MusicDrumKit.PlayDrumKit();
        }
    }
}
