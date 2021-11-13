using System;
using System.Threading;
using NewTest.Helpers;
using OpenQA.Selenium;

namespace NewTest.GuessTheFlag
{
    public class FlagWeb
    {
        private static readonly IWebDriver Driver = SeleniumHelpers.Driver;

        private static readonly By ContinueButton = By.Id("continueButton");
        private static readonly By Flag = By.XPath("//div[1]/div[2]/div[1]/p/*[1]");
        private static By RadioButton(string countryName) => By.XPath($"//div[1]/div[2]/div[1]/form/div/div/div/input[contains(@value, '{countryName}')]");     



        private const string flagPage = "https://www.gamesforthebrain.com/game/flag/";

        public static void GoToPage()
        {
            Driver.Url = flagPage;
        }

        public static void SelectValue()
        {
            for (var i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);

                var image = Driver.WaitForElement(Flag);
                var imageSource = image.GetAttribute("src");

                var countryId = imageSource.Split("https://www.gamesforthebrain.com/game/flag/image/");
                var country = countryId[1].Substring(0, countryId[1].IndexOf("-"));

                Thread.Sleep(500);

                Driver.WaitForElement(RadioButton(country)).Click();

                Driver.WaitForElement(ContinueButton).Click();

                if (i < 9)
                {
                    Driver.WaitForElement(ContinueButton).Click();
                }
            }
        }
    }
}
