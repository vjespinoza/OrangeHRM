using OpenQA.Selenium;
using OrangeHRM.Core;

namespace OrangeHRM.Pages;

public class MainPage(IWebDriver driver) : BasePage(driver)
{
    private readonly By _addUserButton = By.CssSelector(".orangehrm-header-container button");
    private readonly By _sidePanelMenuItems = By.CssSelector(".oxd-main-menu-item-wrapper a");
    private readonly By _sidePanelSearchInput = By.CssSelector(".oxd-navbar-nav .oxd-input");
    private readonly By _sidePanelToggleButton = By.ClassName("oxd-main-menu-button");
    private readonly By _userProfileDropdown = By.Id("oxd-userdropdown");

    public void SelectSidePanelMenuItem(string itemName = "Admin")
    {
        FindElements(_sidePanelMenuItems).ToList().Find(item => item.Text.Equals(itemName))?.Click();
    }

    public UserAdminPage AddUser()
    {
        Click(_addUserButton);

        return new UserAdminPage(Driver);
    }

    public bool IsSidePanelVisible()
    {
        return Driver.FindElement(_sidePanelSearchInput).Displayed &&
               Driver.FindElement(_sidePanelToggleButton).Displayed;
    }
}