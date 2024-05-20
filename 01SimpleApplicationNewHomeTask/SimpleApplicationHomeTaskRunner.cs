using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace _01SimpleApplicationHomeTask
{
    public class SimpleApplicationHomeTaskRunner
    {
        public static void Main(string[] args)
        {
            new DriverManager().SetUpDriver(new ChromeConfig());

            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://amazon.co.uk/");

            IWebElement searchInput = driver.FindElement(By.CssSelector("#twotabsearchtextbox"));

            searchInput.SendKeys("iphone");
            searchInput.SendKeys(Keys.Enter);

            driver.Quit();
        }
    }
}
