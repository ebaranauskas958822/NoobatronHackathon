using System;
using NewTest.Helpers;
using OpenQA.Selenium;

namespace NewTest
{
    public class Class1
    {
        private static readonly IWebDriver  Driver = SeleniumHelpers.Driver;

        private static readonly By GetStartedButton = By.LinkText("Get Started");
        private static readonly By NextLink = By.CssSelector(".step:not([style='display:none;']):not([style='display: none;']) .step-select");
        private static readonly By LastStepTitle = By.CssSelector(".step:not([style='display:none;']):not([style='display: none;']) h2");


        private const string dotNetPage = "https://dotnet.microsoft.com/";

        public static void GoToPage()
        {
            Driver.Url = dotNetPage;
        }

        public static string GetText()
        {
            Driver.WaitForElement(GetStartedButton).Click();

            IWebElement nextLink = null;
            var k = 0;
            do
            {
                nextLink?.Click();
                nextLink = Driver.FindElementOrDefault(NextLink);
                k++;
            } while (k < 6);

            var lastStepTitle = Driver.WaitForElement(LastStepTitle).Text;

            return lastStepTitle;
            //test1
        }
    }
}
