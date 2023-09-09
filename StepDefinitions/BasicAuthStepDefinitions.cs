using AutomationPractice.PageObjects;

namespace AutomationPractice.StepDefinitions
{
    [Binding]
    public class BasicAuthStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        public BasicAuthStepDefinitions(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;

        [When(@"User login as '([^']*)'")]
        public void WhenUserLoginAs(string loginName)
        {
            Page.BasicAuth.GoToAuthPage(loginName);
        }
        [Then(@"User will be logged in")]
        public void ThenUserWillBeLoggedIn()
        {
            Page.BasicAuth.AssertThatYouAreloggedIn();
        }
        [Then(@"User will not be logged in")]
        public void ThenUserWillNotBeLoggedIn()
        {
            Page.BasicAuth.AssertThatYouAreNotloggedIn();
        }
    }
}
