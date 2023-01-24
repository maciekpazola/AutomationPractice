using AutomationPractice.PageObjects;

namespace AutomationPractice.StepDefinitions
{
    [Binding]
    public class BasicAuthStepDefinitions
    {
        [When(@"I will login as '([^']*)'")]
        public void WhenIWillLoginAs(string loginName) => Page.BasicAuth.GoToAuthPage(loginName);

        [Then(@"I will assert that I am logged in")]

        public void ThenIWillAssertThatIAmLoggedIn()=> Page.BasicAuth.AssertThatYouAreloggedIn();

        [Then(@"I will assert that I am not logged in")]
        public void ThenIWillAssertThatIAmNotLoggedIn()=> Page.BasicAuth.AssertThatYouAreNotloggedIn();
    }
}
