using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using SeleniumExtras.WaitHelpers;
using System.Threading;

namespace NewTest.Helpers
{
    public static class SeleniumHelpers
    {
        public static IWebDriver Driver;

        public static IWebElement WaitForElement(this IWebDriver driver, By locator, int seconds = 150, bool throwException = true)
        {
            var attempt = 10;
            var secondsPerAttempt = seconds / attempt;
            var exception = new Exception();
            for (var i = 0; i < attempt; i++)
            {
                try
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(secondsPerAttempt));
                    return wait.Until(ExpectedConditions.ElementIsVisible(locator));
                }
                catch (Exception ex)
                {
                    exception = ex;
                }
            }

            if (throwException)
            {
                throw exception;
            }
            else
            {
                return null;
            }
        }

        public static IWebElement WaitForClickableElement(this IWebDriver driver, By locator, int seconds = 150, bool throwException = true)
        {
            var attempt = 5;
            var secondsPerAttempt = seconds / attempt;
            var exception = new Exception();
            for (var i = 0; i < attempt; i++)
            {
                try
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(secondsPerAttempt));
                    return wait.Until(ExpectedConditions.ElementToBeClickable(locator));
                }
                catch (Exception ex)
                {
                    exception = ex;
                }
            }

            if (throwException)
            {
                throw exception;
            }
            else
            {
                return null;
            }
        }

        public static void WaitTillDisappear(this By element, int seconds = 15, int waitForElementSeconds = 150, bool throwException = true)
        {
            var loader = Driver.WaitForElement(element, waitForElementSeconds, throwException);
            var retryMax = seconds * 10;
            var retry = 0;

            if (loader == null && !throwException)
                return;

            try
            {
                while (loader.Displayed && retry < retryMax)
                {
                    retry++;
                    Thread.Sleep(100);
                }
            }
            catch (StaleElementReferenceException e)
            {
                //
            }
        }

        public static IWebElement FindElementOrDefault(this IWebDriver driver, By by, int attempts = 3)
        {
            for( var i = 0; i < attempts; i++)
            {
                try
                {
                    return driver.FindElement(by);
                }
                catch (Exception ex)
                {
                    Thread.Sleep(500);
                }
            }
            return null;
        }

        public static void SelectElement(this By element, string value, int seconds = 15)
        {
            SelectElement(Driver.WaitForElement(element), value, seconds);
        }

        public static void SelectElement(this IWebElement element, string value, int seconds = 15)
        {
            var staleElement = true;
            var retryMax = seconds * 10;
            var retry = 0;

            while (staleElement && retry < retryMax)
            {
                retry++;
                try
                {
                    SelectElement select = new SelectElement(element);
                    if (select.Options.Count >= 1)
                    {
                        select.SelectByText(value);
                    }
                    staleElement = select.SelectedOption.Text != value;
                }

                catch (StaleElementReferenceException e)
                {
                    staleElement = true;
                    Thread.Sleep(50);
                }
            }

        }
    }
}
