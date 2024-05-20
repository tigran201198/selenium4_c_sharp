using OpenQA.Selenium;

namespace _06PageObject.Pages.Impl
{
    public class HomePage(IWebDriver driver) : WebPage(driver)
    {
        private IWebElement SearchBox => FindElement(By.CssSelector(".search-input"));
        private IWebElement SearchInput => FindElement(By.CssSelector("#query-builder-test"));

        public void PerformSearch(string searchPhrase)
        {
            SearchBox.Click();
            SearchInput.SendKeys(searchPhrase);
            SearchInput.SendKeys(Keys.Enter);
        }
    }
}
