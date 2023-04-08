using AutomationPractice.AbstractionLayer.Elements;
using AutomationPractice.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice.PageObjects
{
    public class JavaScriptAlertsPage
    {
        private ButtonElement JavaScriptButton(string onClickValue) => new ButtonElement(Locator.GetButtonLocator(onClickValue));
        private AlertElement Alert() => new AlertElement();


        public void ClickJavaScriptButton(string onClickValue) => JavaScriptButton(onClickValue).Click();

        public void TypeMessageToPrompt(string textMessage) => Alert().Alert.SendKeys(textMessage);

    }
}
