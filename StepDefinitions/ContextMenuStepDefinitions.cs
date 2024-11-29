using AutomationPractice.PageObjects;

namespace AutomationPractice.StepDefinitions
{
    [Binding]
    public class ContextMenuStepDefinitions
    {
        private readonly ContextMenuPage _contextMenuPage;
        public ContextMenuStepDefinitions(ScenarioContext scenarioContext)
        {
            _contextMenuPage = new(scenarioContext);
        }

        [When(@"User right click on the context menu")]
        public void WhenUserRightClickOnTheContextMenu() => _contextMenuPage.RightClickOnContextMenu();

        [Then(@"Alert will be shown with text '([^']*)'")]
        public void ThenAlertWillBeShownWithText(string textInAlert) => _contextMenuPage.AssertTextInTheAlert(textInAlert);

        [When(@"User will click OK on the alert")]
        public void WhenUserWillClickOKOnTheAlert() => _contextMenuPage.AcceptTheAllert();

        [Then(@"Alert will disappear")]
        public void ThenAlertWillDisappear() => _contextMenuPage.AssertIfAllertDissapeared();
    }
}
