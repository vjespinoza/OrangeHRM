using OpenQA.Selenium;
using OrangeHRM.Utils;
using OrangeHRM.Pages;
using Xunit.Internal;

namespace OrangeHRM.Utils;

public abstract class Workflows(IWebDriver driver) : BasePage(driver)
{
    public static MainPage LoginAnGoToMainPage(IWebDriver driver)
    {
        var loginPage = new LoginPage(driver);
        loginPage.EnterUsername(TestData.ValidLogin.Username);
        loginPage.EnterPassword(TestData.ValidLogin.Password);
        loginPage.ClickLoginButton();

        return new MainPage(driver);
    }

    public static MainPage CreateNewUser(IWebDriver driver, Records.UserData userData)
    {
        var mainPage = LoginAnGoToMainPage(driver);
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

    public static void EditUser(IWebDriver driver, Records.UserData userData, UserAdminPage userAdminPage)
    {
        userAdminPage.SelectUserRole(userData.UserRole);
        userAdminPage.SelectStatus(userData.Status);
        userAdminPage.EnablePasswordChange();
        userAdminPage.EnterPassword(userData.Password);
        userAdminPage.EnterPasswordConfirmation(userData.Password);
        userAdminPage.Save();
    }
}