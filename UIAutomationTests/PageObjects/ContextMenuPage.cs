using OpenQA.Selenium;
using UIAutomationTests.AbstractionLayer.Elements;
using UIAutomationTests.Drivers;
using UIAutomationTests.Helpers;


namespace UIAutomationTests.PageObjects
{
    public class ContextMenuPage
    {
        private AlertElement Alert => new(_scenarioContext);
        private IWebElement ContextMenu => Driver.GetDriver(_scenarioContext).FindElement(By.Id("hot-spot"));

        private readonly ScenarioContext _scenarioContext;

        public ContextMenuPage(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        public void RightClickOnContextMenu()
        {
            ActionsBuilder actionsBuilder = new(_scenarioContext);
            actionsBuilder.RightClickOnContextMenu(ContextMenu).Perform();
        }

        public void AcceptTheAllert() => Alert.Accept();

        public void AssertTextInTheAlert(string textInAlert) => Alert.AssertTextInTheAlert(textInAlert);

        public void AssertIfAllertDissapeared() => Alert.CheckIfAlertDissapeared();
    }
}
