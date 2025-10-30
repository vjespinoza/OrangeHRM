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

    public static MainPage CreateNewUser(IWebDriver driver)
    {
        var mainPage = new MainPage(driver);
        var userAdminPage = mainPage.AddUser();

        userAdminPage.SelectUserRole(TestData.AdminUser.UserRole);
        userAdminPage.EnterEmployeeName(TestData.AdminUser.EmployeeNameInitial);
        userAdminPage.SelectStatus(TestData.AdminUser.Status);
        userAdminPage.EnterUsername(TestData.AdminUser.Username);
        userAdminPage.EnterPassword(TestData.AdminUser.Password);
        userAdminPage.EnterPasswordConfirmation(TestData.AdminUser.Password);
        userAdminPage.SaveNewUser();

        return mainPage;
    }
}