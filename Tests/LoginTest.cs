using OrangeHRM.Utils;

namespace OrangeHRM.Tests;

public class LoginTests : BaseTest
{
    [Fact]
    public void VerifyValidUserLogin()
    {
        var mainPage = Workflows.LoginAnGoToMainPage(Driver);

        Assert.True(mainPage.IsSidePanelVisible(),
            "User is redirected to the main HRM page after successful login");
    }
}