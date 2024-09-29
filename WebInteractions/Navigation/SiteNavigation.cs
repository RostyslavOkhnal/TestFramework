using Core.Web.BaseObjects;

namespace WebInteractions.Navigation
{
    public class SiteNavigation : BasePageObject
    {
        public WebEnvironment WebEnvironment { get; set; }

        public void OpenReportPortal()
        {
            Driver.Navigate(WebEnvironment.ReportPortal);
        }
    }
}
