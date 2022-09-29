using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using AutomationPractice.PageObjects;
using AutomationPractice.Drivers.Driver;
using NUnit.Framework;
using OpenQA.Selenium.Support;

namespace AutomationPractice.StepDefinitions
{
    [Binding]
    public class BasicAuthStepDefinitions
    {
        readonly BasicAuthPage basicAuthPage = BasicAuthPage.GetBasicAuthPage();

        [When(@"I will login as '([^']*)'")]
        public void WhenIWillLoginAs(string loginName)
        {
            basicAuthPage.GoToAuthPage(loginName);
        }

        [Then(@"I will assert that I am logged in")]
        public void ThenIWillAssertThatIAmLoggedIn()
        {
            bool state = basicAuthPage.CheckThatYouAreLoggedIn();
            if (state == false)
            {
                throw new Exception("Test is failed, can't find the message after authorization");
            }
        }

        [Then(@"I will assert that I am not logged in")]
        public void ThenIWillAssertThatIAmNotLoggedIn()
        {
            bool state = basicAuthPage.CheckThatYouAreLoggedIn();
            if (state == true)
            {
                throw new Exception("Test is failed, message was found");
            }
        }
    }
}
