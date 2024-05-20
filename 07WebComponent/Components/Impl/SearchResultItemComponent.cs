using OpenQA.Selenium;

namespace _07WebComponent.Components.Impl
{
    public class SearchResultItemComponent(IWebElement rootElement) : WebComponent(rootElement)
    {

        private static readonly By TitleSelector = By.CssSelector(".search-title");
        private static readonly By DescriptionSelector =
            By.XPath(".//h3/following-sibling::*/*[contains(@class, 'search-match')]");

        private string RetrieveTitleText() => 
            FindElement(TitleSelector).Text;

        private string RetrieveDescriptionText() =>
            FindElement(DescriptionSelector).Text;
    }
}
