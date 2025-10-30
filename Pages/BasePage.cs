using OpenQA.Selenium;
using OrangeHRM.Core;

namespace OrangeHRM.Pages;

public abstract class BasePage(IWebDriver driver) : WebOperations(driver)
{
    private readonly By _selectDropdownWrapper =
        By.ClassName("oxd-select-dropdown");

    private readonly By _selectDropdownOptions =
        By.ClassName("oxd-select-option");

    private readonly By _autocompleteDropdownWrapper = By.ClassName("oxd-autocomplete-dropdown");

    private readonly By _autocompleteDropdownOptions = By.ClassName("oxd-autocomplete-option");

    private readonly By _successToast = By.ClassName("oxd-toast--success");


    protected By GetSelectDropdownWrapper()
    {
        return _selectDropdownWrapper;
    }

    protected By GetSelectDropdownOptions()
    {
        return _selectDropdownOptions;
    }

    protected By GetAutocompleteDropdownWrapper()
    {
        return _autocompleteDropdownWrapper;
    }

    protected By GetAutocompleteDropdownOptions()
    {
        return _autocompleteDropdownOptions;
    }

    public bool IsSuccessToastVisible()
    {
        return WaitForCondition(d => d.FindElement(_successToast).Displayed);
    }
}