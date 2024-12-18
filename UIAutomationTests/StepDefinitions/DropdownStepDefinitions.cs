using UIAutomationTests.PageObjects;
using NUnit.Framework;

namespace UIAutomationTests.StepDefinitions
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
        public void ThenOptionsShouldBeVisibleInTheDropdown(int numberOfOptions) =>
            Assert.That(_dropdownPage.GetNumberOfElementsInDropdown(), Is.EqualTo(numberOfOptions));
    }
}
