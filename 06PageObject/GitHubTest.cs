using _06PageObject.Pages.Impl;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Linq;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace _06PageObject
{
    public class GitHubTest
    {
        private const string SearchPhrase = "selenium";

        private static IWebDriver driver;

        [OneTimeSetUp]
        public static void SetUpWebDriver()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void CheckGitHubSearch()
        {
            driver.Navigate().GoToUrl("https://github.com");

            var homePage = new HomePage(driver);
            var searchResultsPage = new SearchResultsPage(driver);

            homePage.PerformSearch(SearchPhrase);

            var actualItems = searchResultsPage.SearchResultsItemsText();
            IList<string> expectedItems = actualItems
                .Where(item => item.Contains(SearchPhrase))
                .ToList();

            Assert.That(expectedItems, Is.EqualTo(actualItems));
        }

        [OneTimeTearDown]
        public static void TearDownDriver() => driver.Quit();
    }
}
