using AutomationPractice.PageObjects;

namespace AutomationPractice.StepDefinitions
{
    [Binding]
    public class JavaScriptAlertsStepDefinitions
    {
        private readonly JavaScriptAlertsPage _javaScriptAlertsPage;
        public JavaScriptAlertsStepDefinitions(ScenarioContext scenarioContext)
        {
            _javaScriptAlertsPage = new(scenarioContext);
        }

        [When(@"User click on '([^']*)' button")]
        public void WhenUserClickOnButton(string onClickValue) => _javaScriptAlertsPage.ClickJavaScriptButton(onClickValue);

        [When(@"User type message to prompt '([^']*)'")]
        public void WhenUserTypeMessageToPrompt(string textMessage) => _javaScriptAlertsPage.TypeMessageToPrompt(textMessage);
    }
}
