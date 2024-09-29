using Core.Web.BaseObjects;
using Core.Web.Elements;

namespace WebInteractions.ReportPortal.Pages
{
    public class HomePage : BasePageObject
    {
        private UiElement LoginButton => GetUiElement("//div[contains(@class,'login-button-container')]/button");

        public void ClickLoginButton()
        {
            LoginButton.Click();
        }
    }
}
