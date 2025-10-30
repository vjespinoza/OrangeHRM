using System.Diagnostics;
using OrangeHRM.Pages.Components;
using OrangeHRM.Utils;

namespace OrangeHRM.Tests;

public class UserManagementTests : BaseTest
{
    [Fact]
    public void AddNewUserTest()
    {
        var userData = TestData.NewUser;
        var mainPage = Workflows.CreateNewUser(Driver, userData);

        Assert.True(mainPage.IsSuccessToastVisible(),
            "Successful toast is visible after adding a new user");

        var usersList = mainPage.SystemUserCardComponents();
        var user = usersList.Find(user =>
            user.GetUserName().Equals(userData.Username));

        Assert.True(user.IsVisible(),
            "User exists in main page's System User list");
    }

    [Fact]
    public void EditUserTest()
    {
        var userData = TestData.NewUser;
        var mainPage = Workflows.CreateNewUser(Driver, userData);
        var usersList = mainPage.SystemUserCardComponents();
        var user = usersList.Find(user =>
            user.GetUserName().Equals(userData.Username));

        Assert.True(user.GetUserName() == userData.Username,
            "User was created successfully");

        var userAdminPage = user.Edit();
        var modifiedUserData = TestData.ModifiedUser;
        Workflows.EditUser(Driver, modifiedUserData, userAdminPage);

        Assert.True(mainPage.IsSuccessToastVisible(),
            "Successful toast is visible after editing a user");

        var newUsersList = mainPage.SystemUserCardComponents();
        var modifiedUser = newUsersList.Find(modifiedUser =>
            modifiedUser.GetUserName().Equals(modifiedUserData.Username));

        Assert.True(modifiedUser.GetUserName() == modifiedUserData.Username,
            "User was updated successfully");
    }

    [Fact]
    public void DeleteUserTest()
    {
        var userData = TestData.NewUser;
        var mainPage = Workflows.CreateNewUser(Driver, userData);

        Assert.True(mainPage.IsSuccessToastVisible(),
            "Successful toast is visible after adding a new user");

        var usersList = mainPage.SystemUserCardComponents();
        var user = usersList.Find(user =>
            user.GetUserName().Equals(userData.Username));
        user.Delete();
        var deleteUserModal = mainPage.PopUpModal(Driver);
        deleteUserModal.Confirm();
        var newUsersList = mainPage.SystemUserCardComponents();

        Assert.Null(
            newUsersList.Find(deletedUser => deletedUser.GetUserName().Equals(userData.Username))
        );
    }
}