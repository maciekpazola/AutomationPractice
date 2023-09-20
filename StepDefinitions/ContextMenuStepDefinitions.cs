using AutomationPractice.PageObjects;
using AutomationPractice.Helpers;
using OpenQA.Selenium;
using AutomationPractice.Drivers;
using AutomationPractice.Drivers.Hooks;
using TechTalk.SpecFlow;

namespace AutomationPractice.StepDefinitions
{
    [Binding]
    public class ContextMenuStepDefinitions
    {
        private readonly FeatureContext _featureContext;
        private readonly ScenarioContext _scenarioContext;
        public ContextMenuStepDefinitions(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;
        }


        [When(@"User right click on the context menu")]
        public void WhenUserRightClickOnTheContextMenu()
        {
            ContextMenuPage page = new(_featureContext, _scenarioContext);
            page.RightClickOnContextMenu();
        }

        [Then(@"Alert will be shown with text '([^']*)'")]
        public void ThenAlertWillBeShownWithText(string textInAlert)
        {
            ContextMenuPage page = new(_featureContext, _scenarioContext);
            page.AssertTextInTheAlert(textInAlert);
        }

        [When(@"User will click OK on the alert")]
        public void WhenUserWillClickOKOnTheAlert()
        {
            ContextMenuPage page = new(_featureContext, _scenarioContext);
            page.AcceptTheAllert();
        }

        [Then(@"Alert will disappear")]
        public void ThenAlertWillDisappear()
        {
            ContextMenuPage page = new(_featureContext, _scenarioContext);
            page.AssertIfAllertDissapeared();
        }
    }
}
