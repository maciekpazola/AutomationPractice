using TestUtilities.UITesting.Drivers;
using TestUtilities.UITesting.Helpers;
using TestUtilities.Logs;
using NUnit.Framework;
using OpenQA.Selenium;

namespace TestUtilities.UITesting.AbstractionLayer.Elements
{
    public class CheckboxElement
    {
        public readonly IWebElement Checkbox;
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
                Checkbox = Driver.GetDriver(_scenarioContext.Get<string>("BrowserName")).FindElement(By.CssSelector(locator));
            }
            catch (NoSuchElementException)
            {
                _logger.WriteInfoLog("Can't find checkbox element");
                throw;
            }
        }

        public void AssertIfChecked(bool expectedResult)
        {
                bool isChecked = GetCheckedState();
                Assert.AreEqual(expectedResult, isChecked);
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

        private void Click() => Checkbox.Click();

        private bool GetCheckedState() => StateChecker.GetPropertyState(Checkbox, Properties.Checked);
    }
}
