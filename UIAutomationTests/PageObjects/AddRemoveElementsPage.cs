using OpenQA.Selenium;
using UIAutomationTests.AbstractionLayer.Elements;
using UIAutomationTests.Helpers;

namespace UIAutomationTests.PageObjects
{
    public class AddRemoveElementsPage
    {
        private ButtonElement AddElementButton => new(_scenarioContext, Locator.GetButtonLocator("addElement"));

        private readonly ScenarioContext _scenarioContext;
        private readonly StateChecker _stateChecker;

        public AddRemoveElementsPage(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _stateChecker = new(_scenarioContext);
        }

        public void ClickAddElementButton() => AddElementButton.Click();

        public void RemoveAllTheElements()
        {
            int numberOfRemoveButtons = _stateChecker.GetNumberOfElements(By.CssSelector(Locator.GetButtonLocator("deleteElement")));
            for (int i = 0; i < numberOfRemoveButtons; i++)
            {
                ButtonElement deleteButton = new(_scenarioContext, Locator.GetButtonLocator("deleteElement"));
                deleteButton.Click();
            }
        }
    }
}
