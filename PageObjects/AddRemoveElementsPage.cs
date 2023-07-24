using AutomationPractice.AbstractionLayer.Elements;
using AutomationPractice.Helpers;
using OpenQA.Selenium;

namespace AutomationPractice.PageObjects
{
    public class AddRemoveElementsPage
    {
        private readonly ButtonElement _addElementButton = new(Locator.GetButtonLocator("addElement"));

        public void ClickAddElementButton()=> _addElementButton.Click();

        public void RemoveAllTheElements()
        {
            int numberOfRemoveButtons = StateChecker.GetNumberOfElements(By.CssSelector(Locator.GetButtonLocator("deleteElement")));
            for(int i = 0; i < numberOfRemoveButtons; i++)
            {
                ButtonElement deleteButton = new(Locator.GetButtonLocator("deleteElement"));
                deleteButton.Click();
            }
        }
    }
}
