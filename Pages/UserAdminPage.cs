using OpenQA.Selenium;

namespace OrangeHRM.Pages;

public class UserAdminPage(IWebDriver driver) : BasePage(driver)
{
    private readonly By _changePasswordCheckbox =
        By.CssSelector(".oxd-form-row:not(.user-password-row) .oxd-grid-item:nth-of-type(5) input");

    private readonly By _confirmPasswordInput =
        By.CssSelector(".user-password-row .oxd-grid-item:nth-of-type(2) input");

    private readonly By _employeeNameInput =
        By.CssSelector(".oxd-form-row:not(.user-password-row) .oxd-grid-item:nth-of-type(2) input");

    private readonly By _passwordInput =
        By.CssSelector(".user-password-row .oxd-grid-item:nth-of-type(1) input");

    private readonly By _saveButton = By.CssSelector(".oxd-form-actions button[type='submit']");

    private readonly By _statusSelectButton =
        By.CssSelector(".oxd-form-row:not(.user-password-row) .oxd-grid-item:nth-of-type(3) .oxd-select-wrapper");

    private readonly By _usernameInput =
        By.CssSelector(".oxd-form-row:not(.user-password-row) .oxd-grid-item:nth-of-type(4) input");

    private readonly By _userRoleSelectButton =
        By.CssSelector(".oxd-form-row:not(.user-password-row) .oxd-grid-item:nth-of-type(1) .oxd-select-wrapper");


    public void SelectUserRole(string roleName)
    {
        Click(_userRoleSelectButton);
        SelectByText(GetSelectDropdownWrapper(), GetSelectDropdownOptions(), roleName);
    }

    public void EnterEmployeeName(string employeeNameInitial)
    {
        Type(_employeeNameInput, employeeNameInitial);
        WaitForCondition(d => d.FindElements(GetAutocompleteDropdownOptions()).Count > 1);
        SelectByIndex(GetAutocompleteDropdownWrapper(), GetAutocompleteDropdownOptions(), 0);
    }

    public void SelectStatus(string status)
    {
        Click(_statusSelectButton);
        SelectByText(GetSelectDropdownWrapper(), GetSelectDropdownOptions(), status);
    }

    public void EnterUsername(string username)
    {
        Type(_usernameInput, username);
    }

    public void EnablePasswordChange()
    {
        WaitForCondition(d => d.FindElement(_changePasswordCheckbox).Enabled);
        ClickJs(_changePasswordCheckbox);
    }

    public void EnterPassword(string password)
    {
        Type(_passwordInput, password);
    }

    public void EnterPasswordConfirmation(string password)
    {
        Type(_confirmPasswordInput, password);
    }

    public void Save()
    {
        Click(_saveButton);
    }
}