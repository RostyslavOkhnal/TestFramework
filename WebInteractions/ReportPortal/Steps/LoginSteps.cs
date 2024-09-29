using Core.Web.BaseObjects;
using WebInteractions.ReportPortal.Pages;

namespace WebInteractions.ReportPortal.Steps
{
    public class LoginSteps : BaseStepsObject
    {
        private HomePage _homePage;

        public LoginSteps(HomePage homePage)
        {
            _homePage = homePage;
        }

        public void Login()
        {
            _homePage.ClickLoginButton();
        }
    }
}
