using AutomationPractice.PageObjects;

namespace AutomationPractice.StepDefinitions
{
    [Binding]
    public class ContextMenuStepDefinitions
    {
        [When(@"I will right-click on the context menu")]
        public void WhenIWillRight_ClickOnTheContextMenu() => Page.ContextMenu.RightClickOnContextMenu();

        [Then(@"Alert will be shown")]
        public void ThenAlertWillBeShown() => Page.ContextMenu.AssertTextInTheAlert();

        [When(@"I will click OK on the alert")]
        public void WhenIWillClickOKOnTheAlert() => Page.ContextMenu.AcceptTheAllert();
    }
}
