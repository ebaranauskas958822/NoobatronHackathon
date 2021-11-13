using System;
using System.Threading;
using NewTest.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace NewTest.MusicChallenge
{
    public class MusicDrumKit
    {

        private static readonly IWebDriver Driver = SeleniumHelpers.Driver;

        private const string drumsPage = "https://codepen.io/amdsouza92/pen/xdooWa";


        public static void GoToDrumPage()
        {
            Driver.Url = drumsPage;
        }

        public static void PlayDrumKit()
        {
            Driver.FindElement(By.CssSelector(".output-container")).Click();
            var Timestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();

            int i = 0;
            while (Timestamp + 30 > new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds())
            {
                if (i % 4 == 0)
                {
                    pressKeys("B");
                    Thread.Sleep(300);
                }
                if ((i % 3 == 0) || (i > 10 && i < 20) || (i > 40 && i < 50) || (i > 70 && i < 80))
                {
                    pressKeys("H");
                    Thread.Sleep(300);
                }
                else if ((i <= 10) || (i >= 20))
                {
                    pressKeys("I");
                    Thread.Sleep(300);
                }

                i++;
            }
        }

        private static void pressKeys(string key)
        {
            Actions Builder = new Actions(Driver);
            Builder.SendKeys(key).Build().Perform();
        }
    }
}
