using AutomationPractice.PageObjects;

namespace AutomationPractice.StepDefinitions
{
    [Binding]
    public class DropdownStepDefinitions
    {
        private readonly DropdownPage _dropdownPage;
        public DropdownStepDefinitions(ScenarioContext scenarioContext)
        {
            _dropdownPage = new(scenarioContext);
        }

        [When(@"User select every option")]
        public void WhenUserSelectEveryOption() => _dropdownPage.SelectAllElementsInDropdown();

        [Then(@"'([^']*)' options should be visible in the dropdown")]
        public void ThenOptionsShouldBeVisibleInTheDropdown(string numberOfOptions) => 
            _dropdownPage.AssertNumberOfElementsInDropdown(Int16.Parse(numberOfOptions));
    }
}
