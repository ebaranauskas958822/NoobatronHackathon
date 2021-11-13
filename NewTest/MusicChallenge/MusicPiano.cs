using System;
using System.Threading;
using NewTest.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace NewTest.MusicChallenge
{
    public class MusicPiano
    {

        private static readonly IWebDriver Driver = SeleniumHelpers.Driver;

        private const string pianoPage = "https://codepen.io/gabrielcarol/pen/rGeEbY";

        // private const string pianoKeys = "ASDFGJKL;WYETHUOP";
        private const string pianoKeys = "ASDFGJKL;";

        public static void GoToPianoPage()
        {
            Driver.Url = pianoPage;
        }

        public static void PlayPiano()
        {
            Driver.FindElement(By.CssSelector(".output-container")).Click();

            var Timestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();

            while (Timestamp + 30 > new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds())
            {
                Random rnd = new Random();
  
                for (var k = 0; k < rnd.Next(1, 4); k++)
                {
                    int keyPosition = getPianoRandomKeyPosition();
                   
                    for (var j = 0; j < rnd.Next(1, 4); j++)
                    {
                        string keys = getPianoKey(keyPosition);

                        for (var l = 0; l < rnd.Next(1, 3); l++)
                        {
                            string? secondKey = getPianoKey(keyPosition + rnd.Next(2, 4));
                            if (secondKey != null)
                            {
                                keys += secondKey;
                            }
                        }

                        pressKeys(keys);
                        Thread.Sleep(200 * rnd.Next(0, 3));
                    }
                }
            }
        }

        private static int getPianoRandomKeyPosition()
        {
            Random rnd = new Random();
            return rnd.Next(0, pianoKeys.Length);
        }

        private static string? getPianoKey(int key)
        {
            try
            {
                return pianoKeys[key].ToString();
            } catch
            {
                return null;
            }
        }

        private static void pressKeys(string key)
        {
            Actions Builder = new Actions(Driver);
            Builder.SendKeys(key).Build().Perform();
        }
    }
}
