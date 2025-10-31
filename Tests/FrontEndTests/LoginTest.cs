using OrangeHRM.Core;
using OrangeHRM.Utils;

namespace OrangeHRM.Tests.FrontEndTests;

public class LoginTests : BaseTest
{
    [Theory]
    [MemberData(nameof(DriverManager.BrowserData), MemberType = typeof(DriverManager))]
    public void VerifyValidUserLogin(DriverManager.BrowserType browser)
    {
        InitializeBrowser(browser);
        var mainPage = Workflows.LoginAnGoToMainPage();

        Assert.True(mainPage.IsSidePanelVisible(),
            "User is redirected to the main HRM page after successful login");
    }
}