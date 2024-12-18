using UIAutomationTests.AbstractionLayer.Elements;

namespace UIAutomationTests.PageObjects
{
    public class DropdownPage
    {
        private DropdownElement Dropdown => new(_scenarioContext, "#dropdown");

        private readonly ScenarioContext _scenarioContext;

        public DropdownPage(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        public void SelectAllElementsInDropdown() => Dropdown.SelectAllElementsInDropdown();

        public int GetNumberOfElementsInDropdown() => Dropdown.GetNumberOfElementsInDropdown();
    }
}
