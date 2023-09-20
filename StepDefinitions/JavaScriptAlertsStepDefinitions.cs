using AutomationPractice.PageObjects;

namespace AutomationPractice.StepDefinitions
{
    [Binding]
    public class JavaScriptAlertsStepDefinitions
    {
        private readonly FeatureContext _featureContext;
        private readonly ScenarioContext _scenarioContext;
        public JavaScriptAlertsStepDefinitions(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;
        }

        [When(@"User click on '([^']*)' button")]
        public void WhenUserClickOnButton(string onClickValue)
        {
            JavaScriptAlertsPage page = new(_featureContext, _scenarioContext);
            page.ClickJavaScriptButton(onClickValue);
        }

        [When(@"User type message to prompt '([^']*)'")]
        public void WhenUserTypeMessageToPrompt(string textMessage)
        {
            JavaScriptAlertsPage page = new(_featureContext, _scenarioContext);
            page.TypeMessageToPrompt(textMessage);
        }
    }
}
