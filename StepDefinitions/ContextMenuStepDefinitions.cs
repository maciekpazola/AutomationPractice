using AutomationPractice.PageObjects;

namespace AutomationPractice.StepDefinitions
{
    [Binding]
    public class ContextMenuStepDefinitions
    {
        [When(@"User right click on the context menu")]
        public void WhenUserRightClickOnTheContextMenu() => Page.ContextMenu.RightClickOnContextMenu();

        [Then(@"Alert will be shown")]
        public void ThenAlertWillBeShown() => Page.ContextMenu.AssertTextInTheAlert();

        [When(@"User will click OK on the alert")]
        public void WhenUserWillClickOKOnTheAlert() => Page.ContextMenu.AcceptTheAllert();

        [Then(@"Alert will disappear")]
        public void ThenAlertWillDisappear() => Page.ContextMenu.AssertIfAllertDissapeared();
    }
}
