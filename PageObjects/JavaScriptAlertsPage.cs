using AutomationPractice.AbstractionLayer.Elements;
using AutomationPractice.Helpers;

namespace AutomationPractice.PageObjects
{
    public class JavaScriptAlertsPage
    {
        private ButtonElement JavaScriptButton(string onClickValue) => new ButtonElement(Locator.GetButtonLocator(onClickValue));
        private readonly AlertElement _alert = new AlertElement();


        public void ClickJavaScriptButton(string onClickValue) => JavaScriptButton(onClickValue).Click();

        public void TypeMessageToPrompt(string textMessage) => _alert.Alert.SendKeys(textMessage);

    }
}
