using Core.Autofac;
using Core.Infrastructure;
using Core.Web.Driver;
using Core.Web.Settings;
using Domain.Web;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Chromium;
using OpenQA.Selenium.Edge;

namespace Core.Web.Infrastructure
{
    public class BaseWebTestFixture : BaseTestFixture
    {
        protected DriverType _driverType;
        protected ChromiumOptions _chromiumOptions;
        protected DriverSettings driverSettings = DependencyResolver.Resolve<DriverSettings>();

        protected void ConfigureDriver()
        {
            _driverType = driverSettings.Type;
            _chromiumOptions = driverSettings.Type switch
            {
                DriverType.Chrome => BuildOptions(new OptionsBuilder<ChromeOptions>()).Build(),
                DriverType.Edge => BuildOptions(new OptionsBuilder<EdgeOptions>()).Build(),
                _ => throw new NotSupportedException($"No available OptionsBuilder for {driverSettings.Type}")
            };
        }

        protected virtual OptionsBuilder<T> BuildOptions<T>(OptionsBuilder<T> options) where T : ChromiumOptions, new()
        {
            return options.SetHeadless(driverSettings.Headless)
                .SetWindowSize();
        }

        [SetUp]
        public void CreateDriver()
        {
            ConfigureDriver();
            var seleniumDriver = WebDriverFactory.CreateWebDriver(_driverType, _chromiumOptions);
            WebDriver.Driver = new WebDriver(seleniumDriver);
        }

        [TearDown]
        public void CloseBrowser()
        {
            WebDriver.Driver.Quit();
        }
    }
}
