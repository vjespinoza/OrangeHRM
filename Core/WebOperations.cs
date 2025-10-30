using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;

namespace OrangeHRM.Core;

public class WebOperations(IWebDriver driver)
{
    protected IWebDriver Driver { get; } = driver;

    protected IWebElement FindElement(By locator)
    {
        var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
        return wait.Until(d => d.FindElement(locator));
    }

    protected ReadOnlyCollection<IWebElement> FindElements(By locator)
    {
        var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
        return wait.Until(d => d.FindElements(locator));
    }

    protected bool WaitForCondition(Func<IWebDriver, bool> condition)
    {
        var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
        return wait.Until(condition);
    }

    protected void Click(By locator)
    {
        FindElement(locator).Click();
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