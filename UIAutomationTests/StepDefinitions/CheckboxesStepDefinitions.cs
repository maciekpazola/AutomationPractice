using AutomationPractice.PageObjects;

namespace AutomationPractice.StepDefinitions
{
    [Binding]
    public class CheckboxesStepDefinitions
    {
        private readonly CheckboxesPage _checkboxesPage;
        public CheckboxesStepDefinitions(ScenarioContext scenarioContext)
        {
            _checkboxesPage = new(scenarioContext);
        }

        [When(@"I will check all checkboxes")]
        public void WhenIWillCheckAllCheckboxes() => _checkboxesPage.CheckAllCheckboxes();

        [Then(@"All checkboxes are checked")]
        public void ThenAllCheckboxesAreChecked() => _checkboxesPage.AssertIfAllCheckboxesAreChecked();

        [When(@"I will uncheck all checkboxes")]
        public void WhenIWillUncheckAllCheckboxes() => _checkboxesPage.UnCheckAllCheckboxes();

        [Then(@"All checkboxes are unchecked")]
        public void ThenAllCheckboxesAreUnchecked() => _checkboxesPage.AssertIfAllCheckboxesAreUnChecked();
    }
}