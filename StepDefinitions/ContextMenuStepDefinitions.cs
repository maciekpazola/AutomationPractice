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
        readonly ContextMenuPage contextMenuPage = ContextMenuPage.GetContextMenuPage();

        [When(@"I will right-click on the context menu")]
        public void WhenIWillRight_ClickOnTheContextMenu()
        {
            contextMenuPage.RightClickOnContextMenu();
        }

        [Then(@"Alert will be shown")]
        public void ThenAlertWillBeShown()
        {
            contextMenuPage.AssertTextInTheAlert();
        }

        [When(@"I will click OK on the alert")]
        public void WhenIWillClickOKOnTheAlert()
        {
            contextMenuPage.AcceptTheAllert();
        }
    }
}
