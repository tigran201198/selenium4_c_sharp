using OpenQA.Selenium;
using _08DtoHomeTask.Components.Impl;

namespace _08DtoHomeTask.Pages.Impl
{
    public class HomePage(IWebDriver driver) : WebPage(driver)
    {
        private static readonly By SearchComponentSelector = By.CssSelector("#twotabsearchtextbox");

        public SearchComponent SearchComponent => new SearchComponent(FindElement(SearchComponentSelector));
    }
}
