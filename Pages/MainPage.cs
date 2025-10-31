using OpenQA.Selenium;
using OrangeHRM.Pages.Components;

namespace OrangeHRM.Pages;

public class MainPage : BasePage
{
    private readonly By _addUserButton = By.CssSelector(".orangehrm-header-container button");
    private readonly By _sidePanelMenuItems = By.CssSelector(".oxd-main-menu-item-wrapper a");
    private readonly By _sidePanelSearchInput = By.CssSelector(".oxd-navbar-nav .oxd-input");
    private readonly By _sidePanelToggleButton = By.ClassName("oxd-main-menu-button");
    private readonly By _systemUserCardContainers = By.ClassName("oxd-table-card");
    private readonly By _userProfileDropdown = By.ClassName("oxd-userdropdown");

    public List<SystemUserCard> SystemUserCardComponents()
    {
        WaitForCondition(d => d.FindElements(_systemUserCardContainers).Count > 0);
        var containers = FindElements(_systemUserCardContainers);

        return
            containers.Select(container => new SystemUserCard(container)).ToList();
    }

    public void SelectSidePanelMenuItem(string itemName = "Admin")
    {
        FindElements(_sidePanelMenuItems).ToList().Find(item => item.Text.Equals(itemName))?.Click();
    }

    public UserAdminPage AddUser()
    {
        Click(_addUserButton);

        return new UserAdminPage();
    }

    public bool IsSidePanelVisible()
    {
        return WaitForVisibility(_sidePanelSearchInput) &&
               WaitForVisibility(_sidePanelToggleButton);
    }
}