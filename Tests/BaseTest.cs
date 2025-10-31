using OpenQA.Selenium;
using OrangeHRM.Core;
using OrangeHRM.Pages;

namespace OrangeHRM.Tests;

public abstract class BaseTest : IDisposable
{
    private const string Url = "https://opensource-demo.orangehrmlive.com/web/index.php/auth/login";
    protected readonly LoginPage LoginPage = new();

    protected void InitializeBrowser(DriverManager.BrowserType browserType)
    {
        DriverManager.InitializeDriver(browserType);
        LoginPage.NavigateTo(Url);
    }

    public void Dispose()
    {
        DriverManager.QuitDriver();
    }
}