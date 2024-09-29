using Autofac;
using Autofac.Extensions.DependencyInjection;
using Core.Autofac;
using Core.Web.Settings;
using Microsoft.Extensions.Configuration;
using System.Runtime.CompilerServices;
using WebInteractions;
using WebInteractions.Navigation;

namespace Tests
{
    public class StartUp
    {
        private static DriverSettings _driverSettings = new();
        private static WebEnvironment _webEnvironment = new();

        [ModuleInitializer]
        public static void SetUp()
        {
            string solutionDirectory = AppDomain.CurrentDomain.BaseDirectory;

            var builder = new ConfigurationBuilder()
                .SetBasePath(solutionDirectory)
                .AddJsonFile(_driverSettings.SettingsPath, optional: false, reloadOnChange: true)
                .AddJsonFile(_webEnvironment.WebEnvironmentPath, optional: false, reloadOnChange: true);

            var configuration = builder.Build();

            ConfigureServices(configuration);
        }

        private static IServiceProvider ConfigureServices(IConfiguration configuration)
        {
            configuration.Bind("Driver", _driverSettings);
            configuration.Bind(_webEnvironment);

            var builder = new ContainerBuilder();

            builder.RegisterInstance(_driverSettings).SingleInstance();
            builder.RegisterInstance(_webEnvironment).SingleInstance();

            builder.RegisterModule<WebInteractionsModule>();

            var container = builder.Build();
            DependencyResolver.SetResolver(container);

            return new AutofacServiceProvider(container);
        }
    }
}
