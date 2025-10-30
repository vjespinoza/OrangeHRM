using OpenQA.Selenium;
using OrangeHRM.Core;

namespace OrangeHRM.Tests;

public abstract class BaseTest : IDisposable
{
    public BaseTest()
    {
        Driver = WebDriverFactory.CreateWebDriver();
        Driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
    }

    protected IWebDriver Driver { get; }

    public void Dispose()
    {
        if (Driver != null) Driver.Quit();
    }
}