using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace OrangeHRM.Core;

public class WebOperations
{
    protected IWebDriver Driver => DriverManager.Driver;

    private WebDriverWait Wait => new(Driver, TimeSpan.FromSeconds(15));

    protected IWebElement FindElement(By locator)
    {
        return Wait.Until(d => d.FindElement(locator));
    }

    protected ReadOnlyCollection<IWebElement> FindElements(By locator)
    {
        return Wait.Until(d => d.FindElements(locator));
    }

    protected bool WaitForCondition(Func<IWebDriver, bool> condition)
    {
        return Wait.Until(condition);
    }

    protected bool WaitForVisibility(By locator)
    {
        try
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(locator));
            return true;
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }

    protected void Click(By locator)
    {
        FindElement(locator).Click();
    }

    protected void ClickJs(By locator)
    {
        var element = FindElement(locator);
        var jsExecutor = (IJavaScriptExecutor)Driver;
        jsExecutor.ExecuteScript("arguments[0].click();", element);
    }

    protected void Type(By locator, string text)
    {
        var element = FindElement(locator);
        element.Clear();
        element.SendKeys(text);
    }

    protected string GetText(By locator)
    {
        return FindElement(locator).Text;
    }

    protected void SelectByText(By selectWrapper, By options, string text)
    {
        var selectElement = FindElement(selectWrapper);
        var selectOptions = selectElement.FindElements(options);

        selectOptions.ToList().Find(option => option.Text.Equals(text))?.Click();
    }

    protected void SelectByIndex(By selectWrapper, By options, int index)
    {
        var selectElement = FindElement(selectWrapper);
        selectElement.FindElements(options)[index].Click();
    }
}