using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace OrangeHRM.Core
{
    public abstract class BasePage
    {
        protected IWebDriver Driver { get; }

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }
        
        public void NavigateTo(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        protected IWebElement FindElement(By locator)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            return wait.Until(d => d.FindElement(locator));
        }

        protected void Click(By locator)
        {
            FindElement(locator).Click();
        }

        protected void SendKeys(By locator, string text)
        {
            var element = FindElement(locator);
            element.Clear();
            element.SendKeys(text);
        }
    }
}