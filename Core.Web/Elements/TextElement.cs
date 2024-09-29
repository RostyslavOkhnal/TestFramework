using OpenQA.Selenium;

namespace Core.Web.Elements
{
    public class TextElement : UiElement
    {
        public TextElement(IWebElement element) : base(element) { }

        public void EnterText(string text)
        {
            _element.SendKeys(text);
        }
    }
}
