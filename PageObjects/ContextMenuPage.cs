using OpenQA.Selenium;
using TestUtilities.UITesting.AbstractionLayer.Elements;
using TestUtilities.UITesting.Drivers;
using TestUtilities.UITesting.Helpers;


namespace AutomationPractice.PageObjects
{
    public class ContextMenuPage
    {
        private readonly ScenarioContext _scenarioContext;
        public ContextMenuPage(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        AlertElement Alert => new(_scenarioContext);

        public void RightClickOnContextMenu()
        {
            ActionsBuilder actionsBuilder = new(_scenarioContext);
            actionsBuilder.RightClickOnContextMenu(Driver.GetDriver(_scenarioContext.Get<string>("BrowserName")).FindElement(By.Id("hot-spot"))).Perform();
        }

        public void AcceptTheAllert() => Alert.Accept();

        public void AssertTextInTheAlert(string textInAlert) => Alert.AssertTextInTheAlert(textInAlert);

        public void AssertIfAllertDissapeared() => Alert.CheckIfAlertDissapeared();
    }
}
