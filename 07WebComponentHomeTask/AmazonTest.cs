using _07WebComponentHomeTask.Pages.Impl;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Linq;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace _07WebComponentHomeTask
{
    public class AmazonTest
    {
        private const string SearchPhrase = "selenium";

        private static IWebDriver driver;

        [OneTimeSetUp]
        public static void SetUpWebDriver()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [Test]
        public void CheckAmazonSearch()
        {
            driver.Navigate().GoToUrl("https://amazon.co.uk");

            var homePage = new HomePage(driver);
            var searchResultsPage = new SearchResultsPage(driver);

            homePage.SearchComponent.PerformSearch(SearchPhrase);

            var actualItems = searchResultsPage.SearchResultsItemsText();
            var expectedItems = actualItems
                .Where(item => item.ToLower().Contains(SearchPhrase))
                .ToList(); ;

            Assert.That(expectedItems, Is.EqualTo(actualItems));
        }

        [OneTimeTearDown]
        public static void TearDownDriver() => driver.Quit();
    }
}
