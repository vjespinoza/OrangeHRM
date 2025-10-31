using OpenQA.Selenium;
using OrangeHRM.Core;
using OrangeHRM.Pages;

namespace OrangeHRM.Utils;

public abstract class Workflows
{
    public static MainPage LoginAnGoToMainPage()
    {
        var loginData = new TestData().ValidLogin;
        var loginPage = new LoginPage();
        loginPage.EnterUsername(loginData.Username);
        loginPage.EnterPassword(loginData.Password);
        loginPage.ClickLoginButton();

        return new MainPage();
    }

    public static MainPage CreateNewUser(Records.UserData userData)
    {
        var mainPage = LoginAnGoToMainPage();
        mainPage.SelectSidePanelMenuItem();

        var userAdminPage = mainPage.AddUser();

        userAdminPage.SelectUserRole(userData.UserRole);
        userAdminPage.EnterEmployeeName(userData.EmployeeNameInitial);
        userAdminPage.SelectStatus(userData.Status);
        userAdminPage.EnterUsername(userData.Username);
        userAdminPage.EnterPassword(userData.Password);
        userAdminPage.EnterPasswordConfirmation(userData.Password);
        userAdminPage.Save();

        return mainPage;
    }

    public static void EditUser(Records.UserData userData, UserAdminPage userAdminPage)
    {
        userAdminPage.SelectUserRole(userData.UserRole);
        userAdminPage.SelectStatus(userData.Status);
        userAdminPage.EnablePasswordChange();
        userAdminPage.EnterPassword(userData.Password);
        userAdminPage.EnterPasswordConfirmation(userData.Password);
        userAdminPage.Save();
    }
}