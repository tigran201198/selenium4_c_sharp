using OpenQA.Selenium;

namespace _06PageObjectHomeTask.Pages.Impl
{
    public class HomePage(IWebDriver driver) : WebPage(driver)
    {
        private IWebElement SearchInput => FindElement(By.CssSelector("#twotabsearchtextbox"));

        public void PerformSearch(string searchPhrase)
        {
            SearchInput.SendKeys(searchPhrase);
            SearchInput.SendKeys(Keys.Enter);
        }
    }
}
