using System;
using System.Threading;
using NewTest.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace NewTest.MusicChallenge
{
    public class MusicWeb
    {

        private static readonly IWebDriver Driver = SeleniumHelpers.Driver;

        //private static readonly By Result = By.Id("result_div");
        //private static readonly By ChordFrame = By.Id("result");
        //private static readonly By GTuning = By.XPath("div[1]/div[8]/label/span[1]");
        //private static readonly By EmTuning = By.XPath("//div[1]/div[7]/label/span");
        //private static readonly By CTuning = By.XPath("//div[1]/div[10]/label/span");
        //private static readonly By DTuning = By.XPath("//div[1]/div[5]/label/span");

        private static readonly By PlayLink = By.Id("play-chord");

        private const string drumsPage = "https://codepen.io/amdsouza92/pen/xdooWa";
        private const string guitarPage = "https://codepen.io/CoolS2/pen/EdPxyz";
        private const string pianoPage = "https://codepen.io/gabrielcarol/pen/rGeEbY";


        public static void GoToDrumPage()
        {
            Driver.Url = drumsPage;
        }

        public static void GoToGuitarPage()
        {
            Driver.Url = guitarPage;
        }

        public static void GoToPianoPage()
        {
            Driver.Url = pianoPage;
        }

        //public static void PlayGuitar()
        //{
        //   Driver.SwitchTo().Frame(Driver.WaitForElement(ChordFrame));

        //    Thread.Sleep(500);

        //    var gTuning = Driver.WaitForElement(GTuning).GetAttribute("class");
        //    //var emTuning = Driver.WaitForElement(EmTuning);
        //    //var cTuning = Driver.WaitForElement(CTuning);
        //    //var dTuning = Driver.WaitForElement(DTuning);

        //    Thread.Sleep(100);

        //    //gTuning.Click();

        //    Actions Builder = new Actions(Driver);

        //    for (var i = 0; i < 10; i++)
        //    {
        //        Builder.SendKeys(Keys.Up).Build().Perform();
        //        Builder.SendKeys(Keys.Down).Build().Perform();
        //    }


        //}

        public static void PlayPiano()
        {
            Actions Builder = new Actions(Driver);

            for (var i = 0; i < 10; i++)
            {
                Builder.SendKeys("F").Build().Perform();
                Builder.SendKeys("D").Build().Perform();
            }

        }
    }
}
