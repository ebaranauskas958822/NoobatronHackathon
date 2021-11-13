using NewTest.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;

namespace Maze.staticMaze.Tests

{
    public class ChessTest
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
            if (SeleniumHelpers.Driver != null)
            {
            //    SeleniumHelpers.Driver.Quit();
            }
        }

        [Test]
        public void runStaticMaze()
        {
            Driver.Url = "http://hackathon-maze.herokuapp.com/static/";

            Thread.Sleep(200);

            Actions action = new Actions(Driver);

            while (true)
            {
                Random rnd = new Random();
                int direction = rnd.Next(1, 5);

                action.SendKeys(Keys.Up).Build().Perform();
                action.SendKeys(Keys.Up).Build().Perform();
                action.SendKeys(Keys.Up).Build().Perform();


            }
        }

        public static void go(string direction, int qty)
        {
            Actions action = new Actions(Driver);

            for (int i = 0; i < qty; i++)
            {
                action.SendKeys(Keys.Up).Build().Perform();
            }
        }

    }
}
