using AutomationPractice.AbstractionLayer.Elements;
using AutomationPractice.DriverFolder;
using AutomationPractice.Helper;
using log4net;
using logger;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AutomationPractice.PageObjects
{
    public class AddRemoveElementsPage
    {
        private readonly string DeleteButtonLocator = Locator.GetButtonLocator("deleteElement");

        private ButtonElement AddElementButton() => new ButtonElement(Locator.GetButtonLocator("addElement"));
        private ButtonElement DeleteButton() => new ButtonElement(DeleteButtonLocator);


        public void ClickAddElementButton()=> AddElementButton().Click();

        public void RemoveAllTheElements()
        {
            int numberOfRemoveButtons = StateCheck.GetNumberOfElements(By.CssSelector(DeleteButtonLocator));
            for(int i = 0; i < numberOfRemoveButtons; i++)
                DeleteButton().Click();
        }
    }
}
