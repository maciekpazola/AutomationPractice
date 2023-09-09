using AutomationPractice.PageObjects;

namespace AutomationPractice.StepDefinitions
{
    [Binding]
    public class JavaScriptAlertsStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        public JavaScriptAlertsStepDefinitions(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;

        [When(@"User click on '([^']*)' button")]
        public void WhenUserClickOnButton(string onClickValue)
        {
            JavaScriptAlertsPage page = new(_scenarioContext);
            page.ClickJavaScriptButton(onClickValue);
        }

        [When(@"User type message to prompt '([^']*)'")]
        public void WhenUserTypeMessageToPrompt(string textMessage)
        {
            JavaScriptAlertsPage page = new(_scenarioContext);
            page.TypeMessageToPrompt(textMessage);
        }
    }
}
