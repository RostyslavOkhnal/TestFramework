using Autofac;
using Core.Autofac;
using Core.Web.Infrastructure;
using NUnit.Framework;
using WebInteractions.Navigation;
using WebInteractions.ReportPortal.Steps;

namespace Tests.Tests
{
    [Parallelizable(ParallelScope.All)]
    public class DefaultTestFixture : BaseWebTestFixture // This test fixture is a test for framework and will be deleted once actual automation starts
    {
        public SiteNavigation SiteNavigation { get; set; }
        public LoginSteps LoginSteps { get; set; }

        protected override OptionsBuilder<T> BuildOptions<T>(OptionsBuilder<T> options)
        {
            return base.BuildOptions(options).EnableIncognitoMode();
        }

        public DefaultTestFixture()
        {
            DependencyResolver.GetContainer().InjectProperties(this);
        }

        [Test]
        public void FirstTest()
        {
            SiteNavigation.OpenReportPortal();
            LoginSteps.Login();
        }

        [Test]
        public void SecondTest()
        {
            SiteNavigation.OpenReportPortal();
            LoginSteps.Login();
        }

        [Test]
        public void ThirdTest()
        {
            SiteNavigation.OpenReportPortal();
            LoginSteps.Login();
        }
    }
}
