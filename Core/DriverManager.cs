using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace OrangeHRM.Core;

public static class DriverManager
{
    private static readonly ThreadLocal<IWebDriver> ThreadLocalDriver = new();

    public static IWebDriver Driver
    {
        get
        {
            if (ThreadLocalDriver.Value == null)
                throw new InvalidOperationException("WebDriver has not been initialized for this thread.");
            return ThreadLocalDriver.Value;
        }
        private set => ThreadLocalDriver.Value = value;
    }

    public static void InitializeDriver(BrowserType browserType)
    {
        Driver = browserType switch
        {
            BrowserType.Chrome => CreateChromeDriver(),
            BrowserType.Firefox => CreateFirefoxDriver(),
            _ => throw new ArgumentException($"Unsupported browser type: {browserType}")
        };

        Driver.Manage().Window.Maximize();
        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
    }

    public static void QuitDriver()
    {
        if (ThreadLocalDriver.Value != null)
        {
            ThreadLocalDriver.Value.Quit();
            ThreadLocalDriver.Value.Dispose();
            ThreadLocalDriver.Value = null;
        }
    }

    private static IWebDriver CreateChromeDriver()
    {
        var options = new ChromeOptions();
        options.AddArgument("--start-maximized");
        options.AddArgument("--disable-notifications");
        options.AddArgument("--disable-popup-blocking");
        return new ChromeDriver(options);
    }

    private static IWebDriver CreateFirefoxDriver()
    {
        var options = new FirefoxOptions();
        options.AddArgument("--start-maximized");
        return new FirefoxDriver(options);
    }

    public enum BrowserType
    {
        Chrome,
        Firefox
    }

    public static IEnumerable<object[]> BrowserData
    {
        get
        {
            yield return [BrowserType.Chrome];
            yield return [BrowserType.Firefox];
        }
    }
}