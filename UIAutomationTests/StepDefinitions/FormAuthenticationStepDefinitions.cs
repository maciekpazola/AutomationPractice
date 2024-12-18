using AutomationPractice.PageObjects;
using NUnit.Framework;

namespace AutomationPractice.StepDefinitions
{
    [Binding]
    public class FormAuthenticationStepDefinitions
    {
        private readonly FormAuthenticationPage _loginPage;

        public FormAuthenticationStepDefinitions(ScenarioContext scenarioContext)
        {
            _loginPage = new(scenarioContext);
        }

        [When(@"Correct credentials are filled in")]
        public void WhenCorrectCredentialsAreFilledIn() => _loginPage.Login(username: "tomsmith", password: "SuperSecretPassword!");

        [When(@"Login button is clicked")]
        public void WhenLoginButtonIsClicked() => _loginPage.ClickLoginButton();

        [Then(@"User is successfully logged in")]
        public void ThenUserIsSuccessfullyLoggedIn() => Assert.That(_loginPage.IsUserLoggedIn(), Is.True);

        [When(@"Wrong credentials are filled in")]
        public void WhenWrongCredentialsAreFilledIn() => _loginPage.Login(username: "WrongUser", password: "WrongPassword!");

        [Then(@"User is not successfully logged in")]
        public void ThenUserIsNotSuccessfullyLoggedIn() => Assert.That(_loginPage.IsUserLoggedIn(), Is.False);
    }
}
