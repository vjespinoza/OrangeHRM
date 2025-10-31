using OrangeHRM.Core;
using OrangeHRM.Pages;

namespace OrangeHRM.Tests.FrontEndTests;

public abstract class BaseTest : IDisposable
{
    private const string Url = "https://opensource-demo.orangehrmlive.com/web/index.php/auth/login";
    protected readonly LoginPage LoginPage = new();

    public void Dispose()
    {
        DriverManager.QuitDriver();
    }

    protected void InitializeBrowser(DriverManager.BrowserType browserType)
    {
        DriverManager.InitializeDriver(browserType);
        LoginPage.NavigateTo(Url);
    }
}