using AutomationPractice.Drivers.Driver;
using AutomationPractice.PageObjects;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace AutomationPractice.StepDefinitions
{
    [Binding]
    public class ContextMenuStepDefinitions
    {
        public ContextMenuStepDefinitions(ContextMenuPage contextMenuPage)
        {
            _contextMenuPage = contextMenuPage;
        }
        private ContextMenuPage _contextMenuPage;

        [When(@"I will right-click on the context menu")]
        public void WhenIWillRight_ClickOnTheContextMenu()
        {
            _contextMenuPage.RightClickOnContextMenu();
        }

        [Then(@"Alert will be shown")]
        public void ThenAlertWillBeShown()
        {
            _contextMenuPage.AssertTextInTheAlert();
        }

        [When(@"I will click OK on the alert")]
        public void WhenIWillClickOKOnTheAlert()
        {
            _contextMenuPage.AcceptTheAllert();
        }
    }
}
