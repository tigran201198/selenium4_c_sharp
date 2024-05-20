using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace _05ExplicitWaits
{
    public class GitHubTest
    {
        private const string SearchPhrase = "selenium";

        private static IWebDriver driver;
        private static WebDriverWait wait;

        [OneTimeSetUp]
        public static void SetUpWebDriver()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        [Test]
        public void CheckGitHubSearch()
        {
            driver.Navigate().GoToUrl("https://github.com");

            IWebElement searchBox = driver.FindElement(By.CssSelector(".search-input"));
            searchBox.Click();

            IWebElement searchInput = driver.FindElement(By.CssSelector("#query-builder-test"));
            searchInput.SendKeys(SearchPhrase);
            searchInput.SendKeys(Keys.Enter);

            WaitForElementVisibility(By.CssSelector("[data-testid='results-list'] > div"));
            IList<string> actualItems = driver.FindElements(By.CssSelector(("[data-testid='results-list'] > div")))
                .Select(item => item.Text.ToLower())
                .ToList();
            IList<string> expectedItems = actualItems
                .Where(item => item.Contains(SearchPhrase))
                .ToList();

            Assert.That(expectedItems, Is.EqualTo(actualItems));
        }

        [OneTimeTearDown]
        public static void TearDownDriver() => driver.Quit();

        private static void WaitForElementVisibility(By selector)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            wait.Until(d => driver.FindElement(selector));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
    }
}
