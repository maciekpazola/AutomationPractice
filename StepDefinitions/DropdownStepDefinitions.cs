using AutomationPractice.PageObjects;

namespace AutomationPractice.StepDefinitions
{
    [Binding]
    public class DropdownStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        public DropdownStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"User select every option")]
        public void WhenUserSelectEveryOption()
        {
            DropdownPage page = new(_scenarioContext);
            page.SelectAllElementsInDropdown();
        }

        [Then(@"'([^']*)' options should be visible in the dropdown")]
        public void ThenOptionsShouldBeVisibleInTheDropdown(string numberOfOptions)
        {
            DropdownPage page = new(_scenarioContext);
            page.AssertNumberOfElementsInDropdown(Int16.Parse(numberOfOptions));
        }
    }
}
