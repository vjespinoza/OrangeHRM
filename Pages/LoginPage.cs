using OrangeHRM.Core;
using OpenQA.Selenium;

namespace OrangeHRM.Pages
{
    public class LoginPage : BasePage
    {
        private readonly By _usernameInput = By.CssSelector("input[name='username']");
        private readonly By _passwordInput = By.CssSelector("input[name='password']");
        private readonly By _loginButton = By.ClassName("orangehrm-login-button");
        
        public LoginPage(IWebDriver driver) : base(driver) { }
        
        public void Login(string username, string password)
        {
            SendKeys(_usernameInput, username);
            SendKeys(_passwordInput, password);
            Click(_loginButton);
        }
    }
}