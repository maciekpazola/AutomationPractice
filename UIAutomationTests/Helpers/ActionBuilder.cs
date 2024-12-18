using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using UIAutomationTests.Drivers;

namespace UIAutomationTests.Helpers
{
    public class ActionsBuilder
    {
        private readonly ScenarioContext _scenarioContext;
        public ActionsBuilder(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;

        public IAction RightClickOnContextMenu(IWebElement contextMenu)
        {
            Actions actions = new(Driver.GetDriver(_scenarioContext));
            return actions.MoveToElement(contextMenu).ContextClick().Build();
        }
    }
}
