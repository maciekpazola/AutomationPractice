using OpenQA.Selenium;
using UIAutomationTests.Drivers;


namespace UIAutomationTests.AbstractionLayer.Elements
{
    public class ButtonElement
    {
        public readonly IWebElement Button;
        private readonly ScenarioContext _scenarioContext;
        public ButtonElement(ScenarioContext scenarioContext, string locator)
        {
            _scenarioContext = scenarioContext;
            Button = Driver.GetDriver(_scenarioContext).FindElement(By.CssSelector(locator));
        }

        public void Click() => Button.Click();
    }
}
