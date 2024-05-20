using _07WebComponent.Components.Impl;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace _07WebComponent.Pages.Impl
{
    public class SearchResultsPage(IWebDriver driver) : WebPage(driver)
    {
        private static readonly By SearchResultItemSelector = By.CssSelector("[data-testid='results-list'] > div");

        private IList<SearchResultItemComponent> SearchResultsItems => FindElements(SearchResultItemSelector)
            .Select(element => new SearchResultItemComponent(element))
            .ToList();

        public IList<string> SearchResultsItemsText()
        {
            WaitForElement(SearchResultItemSelector);
            return SearchResultsItems
                .Select(item => item.Text.ToLower())
                .ToList();
        }
    }
}
