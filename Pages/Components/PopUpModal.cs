using OpenQA.Selenium;

namespace OrangeHRM.Pages.Components;

public class PopUpModal(IWebDriver driver, IWebElement container) : BaseComponent(driver, container)
{
    private readonly By _modalTitle = By.CssSelector("p[class*='card-title']");

    private readonly By _modalText = By.CssSelector("p[class*='card-body']");

    private readonly By _closeModalButton = By.ClassName("oxd-dialog-close-button");

    private readonly By _cancelButton =
        By.CssSelector(".orangehrm-modal-footer button:first-of-type");

    private readonly By _confirmButton =
        By.CssSelector(".orangehrm-modal-footer button:last-of-type");

    public string GetModalTitle()
    {
        return GetText(_modalTitle);
    }

    public string GetModalText()
    {
        return GetText(_modalText);
    }

    public void CloseModal()
    {
        Click(_closeModalButton);
    }

    public void Cancel()
    {
        Click(_cancelButton);
    }

    public void Confirm()
    {
        Click(_confirmButton);
    }
}