using AutomationPractice.DriverFolder;
using AutomationPractice.Helper;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomationPractice.AbstractionLayer.Elements
{
    public class CheckboxElement
    {
        public readonly IWebElement Checkbox;
        private readonly string locator;
        public CheckboxElement(string locator)
        {
            this.locator = locator;
            try
            {
                Checkbox = Driver.GetInstanceOfDriver().GetDriver().FindElement(By.CssSelector(locator));
            }
            catch (NoSuchElementException ex)
            {
                logger.Logger.WriteInfoLog("Can't find checkbox element");
            }
        }

        public bool GetCheckedState()=> StateCheck.GetPropertyState(Checkbox, Properties.Checked);

        public void AssertIfChecked(bool expectedResult)
        {
                bool isChecked = GetCheckedState();
                Assert.AreEqual(expectedResult, isChecked);
        }

        public void CheckAll()
        {
            int numberOfCheckboxes = StateCheck.GetNumberOfElements(By.CssSelector(locator));
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
            int numberOfCheckboxes = StateCheck.GetNumberOfElements(By.CssSelector(locator));
            for (int i = 0; i < numberOfCheckboxes; i++)
            {
                bool isChecked = GetCheckedState();
                if (isChecked)
                    Click();
                else if (!isChecked)
                    break;
            }
        }

        public void Click() => Checkbox.Click();
    }
}
