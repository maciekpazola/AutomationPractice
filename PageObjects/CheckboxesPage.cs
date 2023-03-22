using AutomationPractice.AbstractionLayer.Elements;
using AutomationPractice.Helper;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AutomationPractice.PageObjects
{
    public class CheckboxesPage
    {
        private CheckboxElement Checkbox() => new CheckboxElement(Locator.GetCheckboxLocator());


        public void CheckAllCheckboxes() => Checkbox().CheckAll();

        public void UnCheckAllCheckboxes() => Checkbox().UnCheckAll();

        private void AssertCheckboxes(bool expectedResult) => Checkbox().AssertIfChecked(expectedResult);

        public void AssertIfAllCheckboxesAreChecked() => AssertCheckboxes(expectedResult : true);

        public void AssertIfAllCheckboxesAreUnChecked() => AssertCheckboxes(expectedResult : false);
    }
}
