using AutomationPractice.PageObjects;

namespace AutomationPractice.StepDefinitions
{
    [Binding]
    public class BasicAuthStepDefinitions
    {
        private readonly FeatureContext _featureContext;
        private readonly ScenarioContext _scenarioContext;
        public BasicAuthStepDefinitions(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;
        }

        [When(@"User login as '([^']*)'")]
        public void WhenUserLoginAs(string loginName)
        {
            BasicAuthPage page = new(_featureContext, _scenarioContext);
            page.GoToAuthPage(loginName);
        }
        [Then(@"User will be logged in")]
        public void ThenUserWillBeLoggedIn()
        {
            BasicAuthPage page = new(_featureContext, _scenarioContext);
            page.AssertThatYouAreloggedIn();
        }
        [Then(@"User will not be logged in")]
        public void ThenUserWillNotBeLoggedIn()
        {
            BasicAuthPage page = new(_featureContext, _scenarioContext);
            page.AssertThatYouAreNotloggedIn();
        }
    }
}
