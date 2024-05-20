using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace _01SimpleApplication
{
    public class SimpleApplicationRunner
    {
        public static void Main(string[] args)
        {
            new DriverManager().SetUpDriver(new ChromeConfig());

            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://github.com/");
        }
    }
}
