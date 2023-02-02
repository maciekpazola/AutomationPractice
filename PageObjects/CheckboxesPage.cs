using AutomationPractice.AbstractionLayer.Elements;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace AutomationPractice.PageObjects
{
    public class CheckboxesPage
    {
        [FindsBy(How = How.CssSelector, Using = "input[type='checkbox']")]
        private IList<IWebElement> checkboxes;

        public void CheckAllCheckboxes()
        {
            foreach (IWebElement checkbox in checkboxes)
            {
                CheckboxElement checkboxElement = new CheckboxElement(checkbox);
                bool isChecked = checkboxElement.GetCheckedState(checkbox);
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
                CheckboxElement checkboxElement = new CheckboxElement(checkbox);
                bool isChecked = checkboxElement.GetCheckedState(checkbox);
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
                CheckboxElement checkboxElement = new CheckboxElement(checkbox);
                checkboxElement.AssertIfChecked(expectedResult);
            }
        }
        public void AssertIfAllCheckboxesAreChecked() => AssertCheckboxes(expectedResult : true);

        public void AssertIfAllCheckboxesAreUnChecked() => AssertCheckboxes(expectedResult : false);
    }
}
