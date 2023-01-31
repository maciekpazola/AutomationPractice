using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace AutomationPractice.PageObjects
{
    public class CheckboxesPage
    {
        [FindsBy(How = How.CssSelector, Using = "input[type='checkbox']")]
        private IList<IWebElement> checkboxes;

        private string GetStateOfCheckbox(IWebElement checkbox)
        {
            return checkbox.GetDomProperty(Properties.Checked);
        }

        public void CheckAllCheckboxes()
        {
            foreach (IWebElement checkbox in checkboxes)
            {
                string isChecked = GetStateOfCheckbox(checkbox);
                if (isChecked == "True")
                    break;
                else if(isChecked == "False")
                    checkbox.Click();
            }
        }
        public void UnCheckAllCheckboxes()
        {
            foreach (IWebElement checkbox in checkboxes)
            {
                string isChecked = GetStateOfCheckbox(checkbox);
                if (isChecked == "True")
                    checkbox.Click();
                else if (isChecked == "False")
                    break;
            }
        }
        private void AssertCheckboxes(string expectedResult)
        {
            foreach (IWebElement checkbox in checkboxes)
            {
                string isChecked = GetStateOfCheckbox(checkbox);
                Assert.AreEqual(expectedResult, isChecked);
            }
        }
        public void AssertIfAllCheckboxesAreChecked() => AssertCheckboxes("True");

        public void AssertIfAllCheckboxesAreUnChecked() => AssertCheckboxes("False");
    }
}
