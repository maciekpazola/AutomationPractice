using AutomationPractice.PageObjects;

namespace AutomationPractice.StepDefinitions
{
    [Binding]
    public class CheckboxesStepDefinitions
    {
        private readonly FeatureContext _featureContext;
        private readonly ScenarioContext _scenarioContext;
        public CheckboxesStepDefinitions(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;
        }

        [When(@"I will check all checkboxes")]
        public void WhenIWillCheckAllCheckboxes()
        {
            CheckboxesPage page = new(_featureContext, _scenarioContext);
            page.CheckAllCheckboxes();
        }

        [Then(@"All checkboxes are checked")]
        public void ThenAllCheckboxesAreChecked()
        {
            CheckboxesPage page = new(_featureContext, _scenarioContext);
            page.AssertIfAllCheckboxesAreChecked();
        }

        [When(@"I will uncheck all checkboxes")]
        public void WhenIWillUncheckAllCheckboxes()
        {
            CheckboxesPage page = new(_featureContext, _scenarioContext);
            page.UnCheckAllCheckboxes();
        }
        [Then(@"All checkboxes are unchecked")]
        public void ThenAllCheckboxesAreUnchecked()
        {
            CheckboxesPage page = new(_featureContext, _scenarioContext);
            page.AssertIfAllCheckboxesAreUnChecked();
        }
    }
}
