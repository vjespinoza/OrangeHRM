using OpenQA.Selenium;
using OrangeHRM.Core;
using OrangeHRM.Pages;

namespace OrangeHRM.Utils;

public abstract class Workflows(IWebDriver driver) : BasePage(driver)
{
    public static MainPage LoginAnGoToMainPage(IWebDriver driver, string username = "Admin",
        string password = "admin123")
    {
        var loginPage = new LoginPage(driver);
        loginPage.EnterUsername(username);
        loginPage.EnterPassword(password);
        loginPage.ClickLoginButton();

        return new MainPage(driver);
    }

    public static MainPage CreateNewUser(
        IWebDriver driver,
        string userRole,
        string employeeName,
        string status,
        string username,
        string password)
    {
        var mainPage = new MainPage(driver);
        var userAdminPage = mainPage.AddUser();

        userAdminPage.SelectUserRole(userRole);
        userAdminPage.EnterEmployeeName(employeeName);
        userAdminPage.SelectStatus(status);
        userAdminPage.EnterUsername(username);
        userAdminPage.EnterPassword(password);
        userAdminPage.EnterPasswordConfirmation(password);
        userAdminPage.SaveNewUser();

        return mainPage;
    }
}