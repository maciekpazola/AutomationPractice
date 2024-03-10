using TestUtilities.UITesting.AbstractionLayer.Elements;

namespace AutomationPractice.PageObjects
{
    public class DropdownPage
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly DropdownElement _dropdown;
        public DropdownPage(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _dropdown = new(_scenarioContext, "#dropdown");
        }

        public void SelectAllElementsInDropdown() => _dropdown.SelectAllElementsInDropdown();

        public void AssertNumberOfElementsInDropdown(int numberOfOptions) =>
            _dropdown.GetNumberOfElementsInDropdown().Should().Be(numberOfOptions);
    }
}
