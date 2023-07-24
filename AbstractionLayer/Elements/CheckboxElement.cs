using AutomationPractice.Drivers;
using AutomationPractice.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomationPractice.AbstractionLayer.Elements
{
    public class CheckboxElement
    {
        public readonly IWebElement Checkbox;

        private readonly string _locator;
        public CheckboxElement(string locator)
        {
            _locator = locator;
            try
            {
                Checkbox = Driver.GetInstanceOfDriver().GetDriver().FindElement(By.CssSelector(locator));
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
            int numberOfCheckboxes = StateChecker.GetNumberOfElements(By.CssSelector(_locator));
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
            int numberOfCheckboxes = StateChecker.GetNumberOfElements(By.CssSelector(_locator));
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
