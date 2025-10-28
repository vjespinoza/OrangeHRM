using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OrangeHRM.Core
{
    public class WebDriverFactory
    {
        public static IWebDriver CreateWebDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            IWebDriver driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            return driver;
        }
    }
}