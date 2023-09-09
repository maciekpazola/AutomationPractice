using AutomationPractice.PageObjects;
using NUnit.Framework;

namespace AutomationPractice.StepDefinitions
{
    [Binding]
    public class FormAuthenticationStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        public FormAuthenticationStepDefinitions(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;

        [When(@"Correct credentials are filled in")]
        public void WhenCorrectCredentialsAreFilledIn()
        {
            FormAuthenticationPage page = new(_scenarioContext);
            page.Login(username: "tomsmith", password: "SuperSecretPassword!");
        }

        [When(@"Login button is clicked")]
        public void WhenLoginButtonIsClicked()
        {
            FormAuthenticationPage page = new(_scenarioContext);
            page.ClickLoginButton();
        }

        [Then(@"User is successfully logged in")]
        public void ThenUserIsSuccessfullyLoggedIn()
        {
            FormAuthenticationPage page = new(_scenarioContext);
            Assert.IsTrue(page.CheckIfUserIsLoggedIn());
        }

        [When(@"Wrong credentials are filled in")]
        public void WhenWrongCredentialsAreFilledIn()
        {
            FormAuthenticationPage page = new(_scenarioContext);
            page.Login(username: "WrongUser", password: "WrongPassword!");
        }

        [Then(@"User is not successfully logged in")]
        public void ThenUserIsNotSuccessfullyLoggedIn()
        {
            FormAuthenticationPage page = new(_scenarioContext);
            Assert.IsFalse(page.CheckIfUserIsLoggedIn());
        }
    }
}
