using AutomationPractice.AbstractionLayer.Elements;
using AutomationPractice.Drivers;
using AutomationPractice.Drivers.Hooks;
using AutomationPractice.Helpers;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace AutomationPractice.PageObjects
{
    public class ContextMenuPage
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;
        public ContextMenuPage(ScenarioContext scenarioContext, IWebDriver driver)
        {
            _scenarioContext = scenarioContext;
            _driver = driver;
        }
        private readonly AlertElement _alert = new();

        public void RightClickOnContextMenu()
        {
            ActionsBuilder actionsBuilder = new(_scenarioContext);
            actionsBuilder.RightClickOnContextMenu(Driver.GetDriver(_scenarioContext.Get<string>("BrowserName")).FindElement(By.Id("hot-spot"))).Perform();
        }

        public void AcceptTheAllert() => _alert.Alert.Accept();

        public void AssertTextInTheAlert(string textInAlert) => _alert.AssertTextInTheAlert(textInAlert);

        public void AssertIfAllertDissapeared() => _alert.CheckIfAlertDissapeared();
    }
}
