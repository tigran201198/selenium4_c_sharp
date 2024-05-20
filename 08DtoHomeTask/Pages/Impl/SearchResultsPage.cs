using OpenQA.Selenium;
using _08DtoHomeTask.Components.Impl;
using _08DtoHomeTask.Entities;
using System.Collections.Generic;
using System.Linq;

namespace _08DtoHomeTask.Pages.Impl
{
    public class SearchResultsPage(IWebDriver driver) : WebPage(driver)
    {
        private static readonly By SearchResultsItemsCss = By.CssSelector("[data-component-type='s-search-result']");

        public IList<SearchResultItem> SearchResultsItems => SearchResultItemComponents()
            .Select(component => component.ConvertToSearchResultItem())
            .ToList();

        private IList<SearchResultItemComponent> SearchResultItemComponents()
        {
            WaitForElement(SearchResultsItemsCss);
            return FindElements(SearchResultsItemsCss)
                .Select(element => new SearchResultItemComponent(element))
                .ToList();
        }
    }
}
