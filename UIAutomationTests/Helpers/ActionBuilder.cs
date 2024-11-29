using TestUtilities.UITesting.Drivers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace TestUtilities.UITesting.Helpers
{
    public class ActionsBuilder
    {
        private readonly ScenarioContext _scenarioContext;
        public ActionsBuilder(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;

        public IAction RightClickOnContextMenu(IWebElement contextMenu)
        {
            Actions actions = new(Driver.GetDriver(_scenarioContext.Get<string>("BrowserName")));
            return actions.MoveToElement(contextMenu).ContextClick().Build();
        }
    }
}
