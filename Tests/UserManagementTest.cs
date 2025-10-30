using System.Diagnostics;
using OrangeHRM.Pages.Components;
using OrangeHRM.Utils;

namespace OrangeHRM.Tests;

public class UserManagementTests : BaseTest
{
    [Fact]
    public void AddNewUserTest()
    {
        const string userRole = "Admin";
        const string employeeNameInitial = "a";
        const string status = "Enabled";
        const string username = "vic_superuser";
        const string password = "qwerty.123";

        var mainPage = Workflows.LoginAnGoToMainPage(Driver);
        mainPage.SelectSidePanelMenuItem();
        Workflows.CreateNewUser(Driver, userRole, employeeNameInitial, status, username, password);

        Assert.True(mainPage.IsSuccessToastVisible(),
            "Successful toast is visible");

        var usersList = mainPage.SystemUserCardComponents();
        var user = usersList.Find(user => user.GetUserName().Equals(username));

        Assert.True(user.IsVisible(),
            "User exists in main page's System User list");
    }

    [Fact]
    public void EditUserTest()
    {
        //TODO: Implement Edit User test
    }

    [Fact]
    public void DeleteUserTest()
    {
        //TODO: Implement Delete User test
    }
}