using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Linq;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace _02Assertions
{
    public class AssertionsRunner
    {
        public static void Main(string[] args)
        {
            new DriverManager().SetUpDriver(new ChromeConfig());

            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://github.com/");

            string searchPhrase = "selenium";

            IWebElement searchBox = driver.FindElement(By.CssSelector(".search-input"));
            searchBox.Click();

            IWebElement searchInput = driver.FindElement(By.CssSelector("#query-builder-test"));
            searchInput.SendKeys(searchPhrase);
            searchInput.SendKeys(Keys.Enter);

            IList<string> actualItems = driver.FindElements(By.CssSelector(("[data-testid='results-list'] > div")))
                .Select(item => item.Text.ToLower())
                .ToList();
            IList<string> expectedItems = actualItems
                .Where(item => item.Contains(searchPhrase))
                .ToList();

            Assert.That(expectedItems, Is.EqualTo(actualItems));

            driver.Quit();
        }
    }
}
