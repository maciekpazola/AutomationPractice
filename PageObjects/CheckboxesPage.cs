using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace AutomationPractice.PageObjects
{
    public class CheckboxesPage
    {
        [FindsBy(How = How.CssSelector, Using = "input[type='checkbox']")]
        private IList<IWebElement> checkboxes;

        private bool GetStateOfCheckbox(IWebElement checkbox)
        {
            return Convert.ToBoolean(checkbox.GetDomProperty(Properties.Checked));
        }

        public void CheckAllCheckboxes()
        {
            foreach (IWebElement checkbox in checkboxes)
            {
                bool isChecked = GetStateOfCheckbox(checkbox);
                if (isChecked)
                    break;
                else if(!isChecked)
                    checkbox.Click();
            }
        }
        public void UnCheckAllCheckboxes()
        {
            foreach (IWebElement checkbox in checkboxes)
            {
                bool isChecked = GetStateOfCheckbox(checkbox);
                if (isChecked)
                    checkbox.Click();
                else if (!isChecked)
                    break;
            }
        }
        private void AssertCheckboxes(bool expectedResult)
        {
            foreach (IWebElement checkbox in checkboxes)
            {
                bool isChecked = GetStateOfCheckbox(checkbox);
                Assert.AreEqual(expectedResult, isChecked);
            }
        }
        public void AssertIfAllCheckboxesAreChecked() => AssertCheckboxes(expectedResult : true);

        public void AssertIfAllCheckboxesAreUnChecked() => AssertCheckboxes(expectedResult : false);
    }
}
