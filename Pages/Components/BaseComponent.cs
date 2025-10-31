using OpenQA.Selenium;
using OrangeHRM.Core;

namespace OrangeHRM.Pages.Components;

public class BaseComponent(IWebElement container) : WebOperations
{
    private readonly IWebElement _container = container;

    protected IWebElement GetContainer()
    {
        return _container;
    }

    protected new string GetText(By locator)
    {
        return _container.FindElement(locator).Text;
    }

    protected new void Click(By locator)
    {
        _container.FindElement(locator).Click();
    }

    protected new void Type(By locator, string text)
    {
        _container.FindElement(locator).SendKeys(text);
    }

    public bool IsVisible()
    {
        try
        {
            return _container.Displayed;
        }
        catch
        {
            return false;
        }
    }
}