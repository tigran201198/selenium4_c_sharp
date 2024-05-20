using OpenQA.Selenium;

namespace _07WebComponentHomeTask.Components.Impl
{
    public class SearchComponent(IWebElement rootElement) : WebComponent(rootElement)
    {
        public void PerformSearch(string searchPhrase)
        {
            SendKeys(searchPhrase);
            SendKeys(Keys.Enter);
        }
    }
}
