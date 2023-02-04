using System;
using TechTalk.SpecFlow;

namespace AutomationPractice.StepDefinitions
{
    [Binding]
    public class FormAuthenticationStepDefinitions
    {
        [When(@"Correct credentials are filled in")]
        public void WhenCorrectCredentialsAreFilledIn()
        {
            throw new PendingStepException();
        }

        [When(@"Login button is clicked")]
        public void WhenLoginButtonIsClicked()
        {
            throw new PendingStepException();
        }

        [Then(@"User is successfully logged in")]
        public void ThenUserIsSuccessfullyLoggedIn()
        {
            throw new PendingStepException();
        }

        [When(@"Wrong credentials are filled in")]
        public void WhenWrongCredentialsAreFilledIn()
        {
            throw new PendingStepException();
        }

        [Then(@"User is not successfully logged in")]
        public void ThenUserIsNotSuccessfullyLoggedIn()
        {
            throw new PendingStepException();
        }
    }
}
