using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace _06PageObjectHomeTask.Pages.Impl
{
    public class SearchResultsPage(IWebDriver driver) : WebPage(driver)
    {
        private static readonly By SearchResultsItemsCss = 
            By.CssSelector("[data-component-type='s-search-result'] h2 .a-link-normal");

        private IList<IWebElement> SearchResultsItems => FindElements(SearchResultsItemsCss);

        public IList<string> SearchResultsItemsText()
        {
            WaitForElement(SearchResultsItemsCss);
            return SearchResultsItems
                .Select(item => item.Text.ToLower() + item.GetAttribute("href").ToLower())
                .ToList();
        }
    }
}
