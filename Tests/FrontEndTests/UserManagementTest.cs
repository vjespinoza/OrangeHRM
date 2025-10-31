using OrangeHRM.Core;
using OrangeHRM.Utils;

namespace OrangeHRM.Tests.FrontEndTests;

public class UserManagementTests : BaseTest
{
    [Theory]
    [MemberData(nameof(DriverManager.BrowserData), MemberType = typeof(DriverManager))]
    public void AddNewUserTest(DriverManager.BrowserType browser)
    {
        InitializeBrowser(browser);

        var userData = new TestData().NewUser;
        var mainPage = Workflows.CreateNewUser(userData);

        Assert.True(mainPage.IsSuccessToastVisible(),
            "Successful toast is visible after adding a new user");

        var usersList = mainPage.SystemUserCardComponents();
        var user = usersList.Find(user =>
            user.GetUserName().Equals(userData.Username));

        Assert.True(user.IsVisible(),
            "User exists in main page's System User list");
    }

    [Theory]
    [MemberData(nameof(DriverManager.BrowserData), MemberType = typeof(DriverManager))]
    public void EditUserTest(DriverManager.BrowserType browser)
    {
        InitializeBrowser(browser);

        var userData = new TestData().NewUser;
        var mainPage = Workflows.CreateNewUser(userData);
        var usersList = mainPage.SystemUserCardComponents();
        var user = usersList.Find(user =>
            user.GetUserName().Equals(userData.Username));

        Assert.True(user.GetUserName() == userData.Username,
            "User was created successfully");

        var userAdminPage = user.Edit();
        var modifiedUserData = new TestData().ModifiedUser;
        Workflows.EditUser(modifiedUserData, userAdminPage);

        Assert.True(mainPage.IsSuccessToastVisible(),
            "Successful toast is visible after editing a user");

        var newUsersList = mainPage.SystemUserCardComponents();
        var modifiedUser = newUsersList.Find(modifiedUser =>
            modifiedUser.GetUserName().Equals(userData.Username));

        Assert.True(modifiedUser.GetUserRole() == modifiedUserData.UserRole,
            "User was updated successfully");
    }

    [Theory]
    [MemberData(nameof(DriverManager.BrowserData), MemberType = typeof(DriverManager))]
    public void DeleteUserTest(DriverManager.BrowserType browser)
    {
        InitializeBrowser(browser);

        var userData = new TestData().NewUser;
        var mainPage = Workflows.CreateNewUser(userData);

        Assert.True(mainPage.IsSuccessToastVisible(),
            "Successful toast is visible after adding a new user");

        var usersList = mainPage.SystemUserCardComponents();
        var user = usersList.Find(user =>
            user.GetUserName().Equals(userData.Username));
        user.Delete();
        var deleteUserModal = mainPage.PopUpModal();
        deleteUserModal.Confirm();
        var newUsersList = mainPage.SystemUserCardComponents();

        Assert.Null(
            newUsersList.Find(deletedUser => deletedUser.GetUserName().Equals(userData.Username))
        );
    }
}