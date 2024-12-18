using TestUtilities.Logs;
using OpenQA.Selenium;
using UIAutomationTests.Drivers;
using UIAutomationTests.Helpers;

namespace UIAutomationTests.AbstractionLayer.Elements
{
    public class CheckboxElement
    {
        public readonly IWebElement? Checkbox;
        private readonly ScenarioContext _scenarioContext;
        private readonly string _locator;
        private readonly StateChecker _stateChecker;
        private readonly Logger _logger;

        public CheckboxElement(ScenarioContext scenarioContext, string locator)
        {
            _scenarioContext = scenarioContext;
            _locator = locator;
            _stateChecker = new(_scenarioContext);
            _logger = new(scenarioContext.ScenarioInfo.Title);
            try
            {
                Checkbox = Driver.GetDriver(_scenarioContext).FindElement(By.CssSelector(locator));
            }
            catch (NoSuchElementException)
            {
                _logger.WriteInfoLog("Can't find checkbox element");
            }
        }

        public void CheckAll()
        {
            int numberOfCheckboxes = _stateChecker.GetNumberOfElements(By.CssSelector(_locator));
            for (int i = 0; i < numberOfCheckboxes; i++)
            {
                bool isChecked = GetCheckedState();
                if (isChecked)
                    break;
                else if (!isChecked)
                    Click();
            }
        }

        public void UnCheckAll()
        {
            int numberOfCheckboxes = _stateChecker.GetNumberOfElements(By.CssSelector(_locator));
            for (int i = 0; i < numberOfCheckboxes; i++)
            {
                bool isChecked = GetCheckedState();
                if (isChecked)
                    Click();
                else if (!isChecked)
                    break;
            }
        }

        public bool GetCheckedState() => StateChecker.GetPropertyState(Checkbox, Properties.Checked);

        private void Click() => Checkbox?.Click();
    }
}
