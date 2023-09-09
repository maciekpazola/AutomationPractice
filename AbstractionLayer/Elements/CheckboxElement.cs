using AutomationPractice.Drivers;
using AutomationPractice.Drivers.Hooks;
using AutomationPractice.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace AutomationPractice.AbstractionLayer.Elements
{
    public class CheckboxElement
    {
        public readonly IWebElement Checkbox;
        private readonly ScenarioContext _scenarioContext;
        private readonly string _locator;
        private readonly StateChecker _stateChecker;

        public CheckboxElement(ScenarioContext scenarioContext, string locator)
        {
            _scenarioContext = scenarioContext;
            _locator = locator;
            _stateChecker = new(_scenarioContext);
            try
            {
                Checkbox = Driver.GetDriver(_scenarioContext.Get<string>("BrowserName")).FindElement(By.CssSelector(locator));
            }
            catch (NoSuchElementException)
            {
                Logger.WriteInfoLog("Can't find checkbox element");
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

        private bool GetCheckedState() => _stateChecker.GetPropertyState(Checkbox, Properties.Checked);
    }
}
