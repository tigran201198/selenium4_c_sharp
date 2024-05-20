using _07WebComponent.Components.Impl;
using OpenQA.Selenium;

namespace _07WebComponent.Pages.Impl
{
    public class HomePage(IWebDriver driver) : WebPage(driver)
    {
        private static readonly By SearchInputCss = By.CssSelector(".search-input");

        public SearchComponent SearchComponent => new SearchComponent(FindElement(SearchInputCss));
    }
}
