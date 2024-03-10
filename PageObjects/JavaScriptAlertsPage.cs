using TestUtilities.UITesting.AbstractionLayer.Elements;
using TestUtilities.UITesting.Helpers;

namespace AutomationPractice.PageObjects
{
    public class JavaScriptAlertsPage
    {
        private readonly FeatureContext _featureContext;
        private readonly ScenarioContext _scenarioContext;
        public JavaScriptAlertsPage(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;
        }
        private ButtonElement JavaScriptButton(string onClickValue) => new(_scenarioContext, Locator.GetButtonLocator(onClickValue));
        private AlertElement Alert() => new(_featureContext, _scenarioContext);

        public void ClickJavaScriptButton(string onClickValue) => JavaScriptButton(onClickValue).Click();

        public void TypeMessageToPrompt(string textMessage) => Alert().Alert.SendKeys(textMessage);

    }
}
