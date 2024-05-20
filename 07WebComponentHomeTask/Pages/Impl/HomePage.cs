using _07WebComponentHomeTask.Components.Impl;
using OpenQA.Selenium;

namespace _07WebComponentHomeTask.Pages.Impl
{
    public class HomePage(IWebDriver driver) : WebPage(driver)
    {
        private static readonly By SearchComponentSelector = By.CssSelector("#twotabsearchtextbox");

        public SearchComponent SearchComponent => new SearchComponent(FindElement(SearchComponentSelector));
    }
}
