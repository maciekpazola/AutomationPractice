using AutomationPractice.PageObjects;
using System;
using TechTalk.SpecFlow;

namespace AutomationPractice.StepDefinitions
{
    [Binding]
    public class JavaScriptAlertsStepDefinitions
    {
        [When(@"User click on '([^']*)' button")]
        public void WhenUserClickOnButton(string onClickValue) => Page.JavaScriptAlerts.ClickJavaScriptButton(onClickValue);

        [When(@"User type message to prompt '([^']*)'")]
        public void WhenUserTypeMessageToPrompt(string textMessage) => Page.JavaScriptAlerts.TypeMessageToPrompt(textMessage);
    }
}
