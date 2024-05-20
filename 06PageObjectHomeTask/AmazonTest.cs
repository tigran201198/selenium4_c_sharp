using _06PageObjectHomeTask.Pages.Impl;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Linq;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace _06PageObjectHomeTask
{
    public class AmazonTest
    {
        private const string SearchPhrase = "iphone";

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
            driver.Navigate().GoToUrl("https://www.amazon.co.uk/");

            var homePage = new HomePage(driver);
            var searchResultsPage = new SearchResultsPage(driver);

            homePage.PerformSearch(SearchPhrase);

            var actualItems = searchResultsPage.SearchResultsItemsText();
            var expectedItems = actualItems
                .Where(item => item.Contains(SearchPhrase))
                .ToList(); ;

            Assert.That(expectedItems, Is.EqualTo(actualItems));
        }

        [OneTimeTearDown]
        public static void TearDownDriver() => driver.Quit();
    }
}
