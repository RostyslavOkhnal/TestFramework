using Core.Helpers;
using OpenQA.Selenium;

namespace Core.Web.Driver
{
    public class WebDriver
    {
        [ThreadStatic]
        internal static WebDriver Driver;

        [ThreadStatic]
        internal static IWebDriver NativeDriver;

        public WebDriver(IWebDriver webDriver)
        {
            NativeDriver = webDriver;
        }

        public IWebElement FindElement(string locator, int timeoutInSec)
        {
            IWebElement webElement = default;

            WaitHelper.WaitNoError(() =>
            {
                if (locator.Contains("//") || locator.Contains("/")) //XPath
                {
                    webElement = NativeDriver.FindElement(By.XPath(locator));
                }
                else if (!locator.Contains(' ') || !locator.Contains('[')) // Id
                {
                    webElement = NativeDriver.FindElement(By.Id(locator));
                }
                else // CSS
                {
                    webElement = NativeDriver.FindElement(By.CssSelector(locator));
                }

            }, timeoutInSec);


            return webElement;
        }

        public void Navigate(string url)
        {
            NativeDriver.Navigate().GoToUrl(url);
        }

        public void Quit()
        {
            NativeDriver.Quit();
        }
    }
}
