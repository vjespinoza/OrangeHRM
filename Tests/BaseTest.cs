using OrangeHRM.Core;
using OpenQA.Selenium;

namespace OrangeHRM.Tests
{
    public abstract class BaseTest : IDisposable
    {
        protected IWebDriver Driver { get; }

        public BaseTest()
        {
            Driver = WebDriverFactory.CreateWebDriver();
            Driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
        }

        public void Dispose()
        {
            if (Driver != null)
            {
                Driver.Quit();
            }
        }
    }
}