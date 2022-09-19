using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using AutomationPractice.PageObjects;
using AutomationPractice.Drivers.Driver;
using NUnit.Framework;

namespace AutomationPractice.StepDefinitions
{
    [Binding]
    public class BasicAuthStepDefinitions
    {
        IWebDriver driver = DriverClass.GetInstanceOfDriver().GetDriver();
        [When(@"I will login as '([^']*)'")]
        public void WhenIWillLoginAs(string loginName)
        {
            BasicAuthPage page = new BasicAuthPage(driver);
            page.GoToAuthPage(loginName);
        }

        [Then(@"I will assert that I am logged in")]
        public void ThenIWillAssertThatIAmLoggedIn()
        {
            BasicAuthPage page = new BasicAuthPage(driver);
            page.CheckThatYouAreLoggedIn();
        }

        [Then(@"I will assert that I am not logged in")]
        public void ThenIWillAssertThatIAmNotLoggedIn()
        {
            BasicAuthPage page = new BasicAuthPage(driver);
        }
    }
}
