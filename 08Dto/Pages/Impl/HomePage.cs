using _08Dto.Components.Impl;
using OpenQA.Selenium;

namespace _08Dto.Pages.Impl
{
    public class HomePage(IWebDriver driver) : WebPage(driver)
    {
        private static readonly By SearchInputCss = By.CssSelector(".search-input");

        public SearchComponent SearchComponent => new SearchComponent(FindElement(SearchInputCss));
    }
}
