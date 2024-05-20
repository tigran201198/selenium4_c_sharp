using _08Dto.Entities;
using OpenQA.Selenium;

namespace _08Dto.Components.Impl
{
    public class SearchResultItemComponent(IWebElement rootElement) : WebComponent(rootElement)
    {

        private static readonly By TitleSelector = By.CssSelector(".search-title");
        private static readonly By DescriptionSelector =
            By.XPath(".//h3/following-sibling::*/*[contains(@class, 'search-match')]");

        public SearchResultItem ConvertToSearchResultItem() =>
            new SearchResultItem(
                RetrieveTitleText(),
                RetrieveDescriptionText()
            );

        private string RetrieveTitleText() =>
            FindElement(TitleSelector).Text.ToLower();

        private string RetrieveDescriptionText() =>
            FindElement(DescriptionSelector).Text.ToLower();
    }
}
