using Core.Web.Elements;
using OpenQA.Selenium;
using WebDriver = Core.Web.Driver.WebDriver;

namespace Core.Web.BaseObjects
{
    public class BasePageObject
    {
        protected WebDriver Driver { get => WebDriver.Driver; }
        private IWebDriver NativeDriver { get => WebDriver.NativeDriver; }

        protected UiElement GetUiElement(string locator, int timeoutInSec = 5)
        {
            var webElement = Driver.FindElement(locator, timeoutInSec);
            return new UiElement(webElement);
        }

        protected TextElement GetTextElement(string locator, int timeoutInSec = 5)
        {
            var webElement = Driver.FindElement(locator, timeoutInSec);
            return new TextElement(webElement);
        }
    }
}
