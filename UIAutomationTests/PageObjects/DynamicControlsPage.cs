using OpenQA.Selenium;
using UIAutomationTests.Drivers;
using UIAutomationTests.Helpers;
using UIAutomationTests.AbstractionLayer.Elements;

namespace AutomationPractice.PageObjects
{
    public class DynamicControlsPage
    {
        private ButtonElement RemoveOrAddButton => new(_scenarioContext, Locator.GetButtonLocator("swapCheckbox"));
        private ButtonElement EnableOrDisableButton => new(_scenarioContext, Locator.GetButtonLocator("swapInput"));
        private CheckboxElement Checkbox => new(_scenarioContext, Locator.GetCheckboxLocator());
        private IWebElement FormField => Driver.GetDriver(_scenarioContext).FindElement(By.CssSelector("input[type='text']"));
        private IWebElement EnableMessage => Driver.GetDriver(_scenarioContext).FindElement(By.Id("message"));

        private readonly ScenarioContext _scenarioContext;
        private readonly Waits _waits;

        public DynamicControlsPage(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _waits = new(_scenarioContext);
        }

        public void RemoveCheckbox()=> RemoveOrAddButton.Click();
        public void WaitUntilChecboxIsVisible() => _waits.WaitUntil(() => !Checkbox.Checkbox.Displayed);
        public bool IsCheckboxDisplayed()
        {
            try
            {
                return _waits.WaitUntil(() => Checkbox.Checkbox.Displayed);

            }
            catch (Exception)
            {
                return false;
            }
        }

        public void AddCheckbox() => RemoveOrAddButton.Click();

        public void ClickEnable() => EnableOrDisableButton.Click();

        public bool IsFormFieldEnabled()
        {
            try
            {
                _waits.WaitUntil(() => EnableMessage.Displayed);
                return EnableMessage.Text.Contains("enabled");

            }
            catch (Exception)
            {
                return false;
            }
        }

        public void FillInFormField(string text) => FormField.SendKeys(text);

        public void ClickDisable() => EnableOrDisableButton.Click();
    }
}