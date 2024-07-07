using AutomationPractice.PageObjects;

namespace AutomationPractice.StepDefinitions
{
    [Binding]
    public class BasicAuthStepDefinitions
    {
        private readonly BasicAuthPage _basicAuthPage;
        public BasicAuthStepDefinitions(ScenarioContext scenarioContext)
        {
            _basicAuthPage = new(scenarioContext);
        }

        [When(@"User login as '([^']*)'")]
        public void WhenUserLoginAs(string loginName) => _basicAuthPage.GoToAuthPage(loginName);

        [Then(@"User will be logged in")]
        public void ThenUserWillBeLoggedIn() => _basicAuthPage.AssertThatYouAreloggedIn();

        [Then(@"User will not be logged in")]
        public void ThenUserWillNotBeLoggedIn() => _basicAuthPage.AssertThatYouAreNotloggedIn();
    }
}
