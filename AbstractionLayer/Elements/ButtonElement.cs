using OpenQA.Selenium;
using TestUtilities.UITesting.Drivers;


namespace TestUtilities.UITesting.AbstractionLayer.Elements
{
    public class ButtonElement
    {
        public readonly IWebElement Button;
        private readonly ScenarioContext _scenarioContext;
        public ButtonElement(ScenarioContext scenarioContext, string locator)
        {
            _scenarioContext = scenarioContext;
            Button = Driver.GetDriver(_scenarioContext.Get<string>("BrowserName")).FindElement(By.CssSelector(locator));
        }

        public void Click() => Button.Click();
    }
}
