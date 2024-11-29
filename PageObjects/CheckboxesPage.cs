using TestUtilities.UITesting.AbstractionLayer.Elements;
using TestUtilities.UITesting.Helpers;

namespace AutomationPractice.PageObjects
{
    public class CheckboxesPage
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly CheckboxElement _checkbox;
        public CheckboxesPage(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _checkbox = new(_scenarioContext, Locator.GetCheckboxLocator());
        }

        public void CheckAllCheckboxes() => _checkbox.CheckAll();

        public void UnCheckAllCheckboxes() => _checkbox.UnCheckAll();

        private void AssertCheckboxes(bool expectedResult) => _checkbox.AssertIfChecked(expectedResult);

        public void AssertIfAllCheckboxesAreChecked() => AssertCheckboxes(expectedResult : true);

        public void AssertIfAllCheckboxesAreUnChecked() => AssertCheckboxes(expectedResult : false);
    }
}
