using OrangeHRM.Core;
using OpenQA.Selenium;

namespace OrangeHRM.Pages;

public class LoginPage(IWebDriver driver) : BasePage(driver)
{
    private readonly By _usernameInput = By.CssSelector("input[name='username']");
    private readonly By _passwordInput = By.CssSelector("input[name='password']");
    private readonly By _loginButton = By.ClassName("orangehrm-login-button");

    public void EnterUsername(string username)
    {
        Type(_usernameInput, username);
    }

    public void EnterPassword(string password)
    {
        Type(_passwordInput, password);
    }

    public void ClickLoginButton()
    {
        Click(_loginButton);
    }
}