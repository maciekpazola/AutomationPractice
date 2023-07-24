using AutomationPractice.AbstractionLayer.Elements;
using AutomationPractice.Helpers;

namespace AutomationPractice.PageObjects
{
    public class CheckboxesPage
    {
        private readonly CheckboxElement _checkbox = new(Locator.GetCheckboxLocator());


        public void CheckAllCheckboxes() => _checkbox.CheckAll();

        public void UnCheckAllCheckboxes() => _checkbox.UnCheckAll();

        private void AssertCheckboxes(bool expectedResult) => _checkbox.AssertIfChecked(expectedResult);

        public void AssertIfAllCheckboxesAreChecked() => AssertCheckboxes(expectedResult : true);

        public void AssertIfAllCheckboxesAreUnChecked() => AssertCheckboxes(expectedResult : false);
    }
}
