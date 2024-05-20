using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace _06PageObject.Pages.Impl
{
    public class SearchResultsPage(IWebDriver driver) : WebPage(driver)
    {
        private static readonly By SearchResultsItemsCss = 
            By.CssSelector("[data-testid='results-list'] > div");

        private IList<IWebElement> SearchResultsItems => FindElements(SearchResultsItemsCss);

        public IList<string> SearchResultsItemsText()
        {
            WaitForElement(SearchResultsItemsCss);
            return SearchResultsItems
                .Select(item => item.Text.ToLower())
                .ToList();
        }
    }
}
