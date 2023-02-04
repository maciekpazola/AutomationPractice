using AutomationPractice.PageObjects;

namespace AutomationPractice.StepDefinitions
{
    [Binding]
    public class DropdownStepDefinitions
    {
        [When(@"User select every option")]
        public void WhenUserSelectEveryOption() => Page.Dropdown.SelectAllElementsInDropdown();

        [Then(@"'([^']*)' options should be visible in the dropdown")]
        public void ThenOptionsShouldBeVisibleInTheDropdown(string numberOfOptions) => Page.Dropdown.AssertNumberOfElementsInDropdown(Int16.Parse(numberOfOptions));
    }
}
