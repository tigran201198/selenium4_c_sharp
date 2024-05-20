using OpenQA.Selenium;

namespace _07WebComponentHomeTask.Components.Impl
{
    public class SearchResultItemComponent(IWebElement rootElement) : WebComponent(rootElement)
    {
        private static readonly By TitleSelector = By.CssSelector("h2 .a-link-normal");

        public string RetrieveTitleText() =>
            FindElement(TitleSelector).Text;

        public string RetrieveTitleHref() =>
            FindElement(TitleSelector).GetAttribute("href");
    }
}
