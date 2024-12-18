using UIAutomationTests.AbstractionLayer.Elements;
using UIAutomationTests.Helpers;

namespace UIAutomationTests.PageObjects
{
    public class CheckboxesPage
    {
        private CheckboxElement Checkbox => new (_scenarioContext, Locator.GetCheckboxLocator());

        private readonly ScenarioContext _scenarioContext;

        public CheckboxesPage(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        public void CheckAllCheckboxes() => Checkbox.CheckAll();

        public void UnCheckAllCheckboxes() => Checkbox.UnCheckAll();

        public bool IsChecked() => Checkbox.GetCheckedState();
    }
}
