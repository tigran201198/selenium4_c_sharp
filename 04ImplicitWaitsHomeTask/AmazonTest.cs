using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Linq;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace _04ImplicitWaitsHomeTask
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
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [Test]
        public void CheckAmazonSearch()
        {
            driver.Navigate().GoToUrl("https://www.amazon.co.uk/");

            var searchInput = driver.FindElement(By.CssSelector("#twotabsearchtextbox"));
            searchInput.SendKeys(SearchPhrase);
            searchInput.SendKeys(Keys.Enter);

            Console.WriteLine(driver.FindElement(By.CssSelector("[data-component-type='s-search-result'] h2 .a-link-normal")).Displayed);
            var actualItems = driver.FindElements(By.CssSelector("[data-component-type='s-search-result'] h2 .a-link-normal"))
               .Select(item => item.Text.ToLower() + item.GetAttribute("href").ToLower())
               .ToList();
            var expectedItems = actualItems
                .Where(item => item.Contains(SearchPhrase))
                .ToList();

            Assert.That(expectedItems, Is.EqualTo(actualItems));
        }

        [OneTimeTearDown]
        public static void TearDownDriver() => driver.Quit();
    }
}
