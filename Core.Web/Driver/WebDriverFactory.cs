using Domain.Web;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Chromium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace Core.Web.Driver
{
    public static class WebDriverFactory
    {
        public static IWebDriver CreateWebDriver(DriverType driverType, ChromiumOptions options)
        {
            IWebDriver driver = driverType switch
            {
                DriverType.Chrome => new ChromeDriver(options as ChromeOptions),
                DriverType.Edge => new EdgeDriver(options as EdgeOptions),
                //DriverType.Firefox => new FirefoxDriver(new FirefoxOptions()), // TO DO
                _ => throw new NotSupportedException($"There are no available driver for {driverType}"),
            };

            return driver;
        }
    }
}
