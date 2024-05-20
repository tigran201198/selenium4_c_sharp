using _07WebComponentHomeTask.Components.Impl;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace _07WebComponentHomeTask.Pages.Impl
{
    public class SearchResultsPage(IWebDriver driver) : WebPage(driver)
    {
        private static readonly By SearchResultsItemsCss =
            By.CssSelector("[data-component-type='s-search-result'] h2 .a-link-normal");

        private IList<SearchResultItemComponent> SearchResultsItems()
        {
            WaitForElement(SearchResultsItemsCss);
            return FindElements(SearchResultsItemsCss)
                .Select(element => new SearchResultItemComponent(element))
                .ToList();
        }

        public IList<string> SearchResultsItemsText() => SearchResultsItems()
            .Select(item => item.Text)
            .ToList();
    }
}
