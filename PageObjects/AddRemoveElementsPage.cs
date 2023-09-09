using AutomationPractice.AbstractionLayer.Elements;
using AutomationPractice.Helpers;
using OpenQA.Selenium;

namespace AutomationPractice.PageObjects
{
    public class AddRemoveElementsPage
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly StateChecker _stateChecker;
        private ButtonElement AddElementButton() => new(_scenarioContext, Locator.GetButtonLocator("addElement"));

        public AddRemoveElementsPage(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _stateChecker = new(_scenarioContext);
        }
        public void ClickAddElementButton()=> AddElementButton().Click();

        public void RemoveAllTheElements()
        {
            int numberOfRemoveButtons = _stateChecker.GetNumberOfElements(By.CssSelector(Locator.GetButtonLocator("deleteElement")));
            for(int i = 0; i < numberOfRemoveButtons; i++)
            {
                ButtonElement deleteButton = new(_scenarioContext, Locator.GetButtonLocator("deleteElement"));
                deleteButton.Click();
            }
        }
    }
}
