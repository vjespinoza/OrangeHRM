using System.Diagnostics;
using OrangeHRM.Pages.Components;
using OrangeHRM.Utils;

namespace OrangeHRM.Tests;

public class UserManagementTests : BaseTest
{
    [Fact]
    public void AddNewUserTest()
    {
        var mainPage = Workflows.LoginAnGoToMainPage(Driver);
        mainPage.SelectSidePanelMenuItem();
        Workflows.CreateNewUser(Driver);

        Assert.True(mainPage.IsSuccessToastVisible(),
            "Successful toast is visible");

        var usersList = mainPage.SystemUserCardComponents();
        var user = usersList.Find(user =>
            user.GetUserName().Equals(TestData.AdminUser.Username));

        Assert.True(user.IsVisible(),
            "User exists in main page's System User list");
    }

    [Fact]
    public void EditUserTest()
    {
        var mainPage = Workflows.LoginAnGoToMainPage(Driver);
        mainPage.SelectSidePanelMenuItem();
        var usersList = mainPage.SystemUserCardComponents();
        var user = usersList.Find(user =>
            user.GetUserName().Equals(TestData.AdminUser.Username));
        user.Edit();

        Thread.Sleep(10000);
    }

    [Fact]
    public void DeleteUserTest()
    {
        //TODO: Implement Delete User test
    }
}