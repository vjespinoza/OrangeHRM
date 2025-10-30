using OpenQA.Selenium;
using OrangeHRM.Core;
using OrangeHRM.Pages.Components;

namespace OrangeHRM.Pages;

public abstract class BasePage(IWebDriver driver) : WebOperations(driver)
{
    private readonly By _autocompleteDropdownContainer = By.ClassName("oxd-autocomplete-dropdown");

    private readonly By _autocompleteDropdownOptions = By.ClassName("oxd-autocomplete-option");

    private readonly By _popUpModalContainer = By.ClassName("oxd-sheet");

    private readonly By _selectDropdownContainer =
        By.ClassName("oxd-select-dropdown");

    private readonly By _selectDropdownOptions =
        By.ClassName("oxd-select-option");

    private readonly By _successToast = By.ClassName("oxd-toast--success");

    protected By GetSelectDropdownWrapper()
    {
        return _selectDropdownContainer;
    }

    protected By GetSelectDropdownOptions()
    {
        return _selectDropdownOptions;
    }

    protected By GetAutocompleteDropdownWrapper()
    {
        return _autocompleteDropdownContainer;
    }

    protected By GetAutocompleteDropdownOptions()
    {
        return _autocompleteDropdownOptions;
    }

    public bool IsSuccessToastVisible()
    {
        return WaitForCondition(d => d.FindElement(_successToast).Displayed);
    }

    public PopUpModal PopUpModal(IWebDriver driver)
    {
        return new PopUpModal(driver, FindElement(_popUpModalContainer));
    }
}