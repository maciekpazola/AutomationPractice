using AutomationPractice.PageObjects;

namespace AutomationPractice.StepDefinitions
{
    [Binding]
    public class DropdownStepDefinitions
    {

        [When(@"I will select every option")]
        public void WhenIWillSelectEveryOption() => Page.Dropdown.SelectAllElementsInDropdown();

        [Then(@"I will assert if number of options in dropdow are equal '([^']*)'")]
        public void ThenIWillAssertIfNumberOfOptionsInDropdowAreEqual(string numberOfOptions) => Page.Dropdown.AssertNumberOfElementsInDropdown(Int16.Parse(numberOfOptions));
    }
}
