using NUnit.Framework;
using UIAutomationTests.PageObjects;

namespace UIAutomationTests.StepDefinitions
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
        public void ThenUserWillBeLoggedIn() => Assert.That(_basicAuthPage.IsUserLoggedIn(), Is.True, "User is not logged in");

        [Then(@"User will not be logged in")]
        public void ThenUserWillNotBeLoggedIn() => Assert.That(_basicAuthPage.IsUserLoggedIn(), Is.False, "User is logged in");
    }
}
