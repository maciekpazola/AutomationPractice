using AutomationPractice.PageObjects;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace AutomationPractice.StepDefinitions
{
    [Binding]
    public class FormAuthenticationStepDefinitions
    {
        [When(@"Correct credentials are filled in")]
        public void WhenCorrectCredentialsAreFilledIn() => Page.FormAuthentication.Login(username: "tomsmith", password: "SuperSecretPassword!");

        [When(@"Login button is clicked")]
        public void WhenLoginButtonIsClicked() => Page.FormAuthentication.ClickLoginButton();

        [Then(@"User is successfully logged in")]
        public void ThenUserIsSuccessfullyLoggedIn() => Assert.IsTrue(Page.FormAuthentication.CheckIfUserIsLoggedIn());

        [When(@"Wrong credentials are filled in")]
        public void WhenWrongCredentialsAreFilledIn() => Page.FormAuthentication.Login(username: "WrongUser", password: "WrongPassword!");

        [Then(@"User is not successfully logged in")]
        public void ThenUserIsNotSuccessfullyLoggedIn() => Assert.IsFalse(Page.FormAuthentication.CheckIfUserIsLoggedIn());
    }
}
