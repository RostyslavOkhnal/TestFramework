using OpenQA.Selenium;

namespace Core.Web.Elements
{
    public class UiElement
    {
        protected IWebElement _element;

        public UiElement(IWebElement element)
        {
            _element = element;
        }

        public void Click()
        {
            _element.Click();
        }
    }
}
