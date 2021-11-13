using NewTest.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;

namespace Chess.ChessTest.Tests

{
    public class ChessTest
    {
        private static readonly IWebDriver Driver = SeleniumHelpers.Driver;

        private const int maxHeight = 8;


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
        public void winChess()
        {
            Driver.Url = "https://hackathon-chess.herokuapp.com/";

            string[] whiteChessSelectors = {
                "img[data-piece='wQ']",
                "img[data-piece='wP']",
                "img[data-piece='wR']",
                "img[data-piece='wN']",
                "img[data-piece='wB']",
                "img[data-piece='wK']",
            };

            string[] blackChessSelectors = {
                "img[data-piece='bK']",
                "img[data-piece='bQ']",
                "img[data-piece='bP']",
                "img[data-piece='bR']",
                "img[data-piece='bN']",
                "img[data-piece='bB']",
            };

            Thread.Sleep(200);

            while (true) {
                try
                {
                    if (!crossChess(whiteChessSelectors, blackChessSelectors))
                    {
                        makeMove(whiteChessSelectors);
                    }
                }
                catch
                {
                    break;
                }

            }
        }

        public static bool crossChess(string[] whiteChessSelectors, string[] blackChessSelectors)
        {

            string blackChess = string.Join(",", blackChessSelectors);
            string whiteChess = string.Join(",", whiteChessSelectors);

            foreach (string item in whiteChessSelectors)
            {
                By selector = By.CssSelector(item);
                var elements = Driver.FindElements(selector);

                foreach (var e in elements)
                {
                    string square = GetParent(e).GetAttribute("data-square");

                    if(square == null)
                    {
                        break;
                    }

                    char width = square[0];
                    int height = int.Parse(square.Substring(1, 1));

                    if (item == "img[data-piece='wP']")
                    {
                        if (cutOneChess(e, getPreviuosLetter(width), height + 1, blackChess)) return true;
                        if (cutOneChess(e, getNextLetter(width), height + 1, blackChess)) return true;
                    }

                    if (item == "img[data-piece='bK']") {
                        if (cutOneChess(e, width, height + 1, blackChess)) return true;
                        if (cutOneChess(e, getPreviuosLetter(width), height + 1, blackChess)) return true;
                        if (cutOneChess(e, getNextLetter(width), height + 1, blackChess)) return true;

                        if (cutOneChess(e, getPreviuosLetter(width), height, blackChess)) return true;
                        if (cutOneChess(e, getNextLetter(width), height, blackChess)) return true;

                        if (cutOneChess(e, width, height - 1, blackChess)) return true;
                        if (cutOneChess(e, getPreviuosLetter(width), height - 1, blackChess)) return true;
                        if (cutOneChess(e, getNextLetter(width), height - 1, blackChess)) return true;
                    }


                    if (item == "img[data-piece='wQ']" || item == "img[data-piece='wR']")
                    {

                        for (int i = height + 1; i <= maxHeight; i++)
                        {
                            if (verify(Driver.FindElement(By.CssSelector("div.square-" + width + i)), whiteChess))
                            {
                                break;
                            }

                            if (cutOneChess(e, width, i, blackChess)) return true;
                        }

                        for (int i = height - 1; i > 0; i--)
                        {
                            if (verify(Driver.FindElement(By.CssSelector("div.square-" + width + i)), whiteChess))
                            {
                                break;
                            }

                            if (cutOneChess(e, width, i, blackChess)) return true;
                        }

                        char? currenWidth = getNextLetter(width);
                        while (currenWidth != null)
                        {
                            if (verify(Driver.FindElement(By.CssSelector("div.square-" + currenWidth + height)), whiteChess))
                            {
                                break;
                            }

                            if (cutOneChess(e, currenWidth, height, blackChess)) return true;

                            currenWidth = getNextLetter(currenWidth);
                        }

                        char? currenWidth2 = getPreviuosLetter(width);
                        while (currenWidth2 != null)
                        {
                            if (verify(Driver.FindElement(By.CssSelector("div.square-" + currenWidth2 + height)), whiteChess))
                            {
                                break;
                            }

                            if (cutOneChess(e, currenWidth2, height, blackChess)) return true;

                            currenWidth2 = getPreviuosLetter(currenWidth2);
                        }
                    }

                }
            }

            return false;
        }

        public static bool cutOneChess(IWebElement e, char? width, int? height, string blackChess)
        {
            try
            {
                if (verify(Driver.FindElement(By.CssSelector("div.square-" + width + height)), blackChess))
                {
                    DragAndDrop(GetParent(e), Driver.FindElement(By.CssSelector("div.square-" + width + height)));
                    return true;
                }
            }
            catch
            {
                return false;
            }

            return false;
        }

        public static void makeMove(string[] whiteChessSelectors)
        {
            foreach (string item in whiteChessSelectors)
            {
                By selector = By.CssSelector(item);
                var elements = Driver.FindElements(selector);

                foreach (var e in elements)
                {
                    string square = GetParent(e).GetAttribute("data-square");
                    if (square == null)
                    {
                        break;
                    }
                    char width = square[0];
                    int height = int.Parse(square.Substring(1, 1));

                    if (item == "img[data-piece='wP']")
                    {
                        string newHeigh = (height + 1).ToString();
                        By newPosition = By.CssSelector("div.square-" + width + newHeigh);
                        if (!verify(Driver.FindElement(newPosition), "img"))
                        {
                            DragAndDrop(GetParent(e), Driver.FindElement(newPosition));
                            return;
                        }
                    }

                }
            }
        }

        public static void DragAndDrop(IWebElement element1, IWebElement element2)
        {
            Actions action = new Actions(Driver);
            action.DragAndDrop(element1, element2).Build().Perform();
            Thread.Sleep(700);
        }

        public static IWebElement GetParent(IWebElement node)
        {
            return node.FindElement(By.XPath(".."));
        }

        static public bool verify(IWebElement container, string elementName)
        {
            try
            {
                return container.FindElement(By.CssSelector(elementName)).Displayed;
            }
            catch
            {
                return false;
            }
            return false;
        }

        static public char? getPreviuosLetter(char? letter)
        {
            if (letter == 'a') { return 'b'; }
            if (letter == 'b') { return 'c'; }
            if (letter == 'c') { return 'd'; }
            if (letter == 'd') { return 'e'; }
            if (letter == 'e') { return 'f'; }
            if (letter == 'f') { return 'g'; }
            if (letter == 'g') { return 'h'; }
            return null;
        }

        static public char? getNextLetter(char? letter)
        {
            if (letter == 'b') { return 'a'; }
            if (letter == 'c') { return 'b'; }
            if (letter == 'd') { return 'c'; }
            if (letter == 'e') { return 'd'; }
            if (letter == 'f') { return 'e'; }
            if (letter == 'g') { return 'f'; }
            if (letter == 'h') { return 'g'; }

            return null;
        }
    }
}
