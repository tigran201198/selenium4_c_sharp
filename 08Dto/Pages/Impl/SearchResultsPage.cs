using _08Dto.Components.Impl;
using _08Dto.Entities;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace _08Dto.Pages.Impl
{
    public class SearchResultsPage(IWebDriver driver) : WebPage(driver)
    {
        private static readonly By SearchResultItemSelector = By.CssSelector("[data-testid='results-list'] > div");

        private IList<SearchResultItemComponent> SearchResultsItems => FindElements(SearchResultItemSelector)
            .Select(element => new SearchResultItemComponent(element))
            .ToList();

        public IList<SearchResultItem> SearchResultItems()
        {
            WaitForElement(SearchResultItemSelector);
            return SearchResultsItems
                .Select(item => item.ConvertToSearchResultItem())
                .ToList();
        }
    }
}
