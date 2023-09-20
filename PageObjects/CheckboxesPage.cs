using AutomationPractice.AbstractionLayer.Elements;
using AutomationPractice.Helpers;

namespace AutomationPractice.PageObjects
{
    public class CheckboxesPage
    {
        private readonly FeatureContext _featureContext;
        private readonly ScenarioContext _scenarioContext;
        private readonly CheckboxElement _checkbox;
        public CheckboxesPage(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;
            _checkbox = new(_featureContext, _scenarioContext, Locator.GetCheckboxLocator());
        }

        public void CheckAllCheckboxes() => _checkbox.CheckAll();

        public void UnCheckAllCheckboxes() => _checkbox.UnCheckAll();

        private void AssertCheckboxes(bool expectedResult) => _checkbox.AssertIfChecked(expectedResult);

        public void AssertIfAllCheckboxesAreChecked() => AssertCheckboxes(expectedResult : true);

        public void AssertIfAllCheckboxesAreUnChecked() => AssertCheckboxes(expectedResult : false);
    }
}
