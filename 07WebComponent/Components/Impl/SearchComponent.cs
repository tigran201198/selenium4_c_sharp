using OpenQA.Selenium;

namespace _07WebComponent.Components.Impl
{
    public class SearchComponent(IWebElement rootElement) : WebComponent(rootElement)
    {
        private static readonly By SearchInputCss = By.CssSelector("#query-builder-test");

        public void PerformSearch(string searchPhrase)
        {
            Click();
            FindElement(SearchInputCss).SendKeys(searchPhrase);
            FindElement(SearchInputCss).SendKeys(Keys.Enter);
        }
    }
}
