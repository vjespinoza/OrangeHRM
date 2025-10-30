using OpenQA.Selenium;

namespace OrangeHRM.Pages.Components;

public class SystemUserCard(IWebDriver driver, IWebElement container) : BaseComponent(driver, container)
{
    private readonly By _checkBox = By.ClassName("oxd-table-card-cell-checkbox");

    private readonly By _deleteButton =
        By.CssSelector(".oxd-table-cell:nth-child(6) button:first-of-type");

    private readonly By _editButton =
        By.CssSelector(".oxd-table-cell:nth-child(6) button:last-of-type");

    private readonly By _employeeName = By.CssSelector(".oxd-table-cell:nth-child(4)");

    private readonly By _status = By.CssSelector(".oxd-table-cell:nth-child(5)");

    private readonly By _username = By.CssSelector(".oxd-table-cell:nth-child(2)");

    private readonly By _userRole = By.CssSelector(".oxd-table-cell:nth-child(3)");

    public void SelectCard()
    {
        Click(_checkBox);
    }

    public string GetUserName()
    {
        return GetText(_username);
    }

    public string GetUserRole()
    {
        return GetText(_userRole);
    }

    public string GetEmployeeName()
    {
        return GetText(_employeeName);
    }

    public string GetStatus()
    {
        return GetText(_status);
    }

    public void Delete()
    {
        Click(_deleteButton);
    }

    public UserAdminPage Edit()
    {
        Click(_editButton);

        return new UserAdminPage(Driver);
    }
}