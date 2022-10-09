using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using AutomationPractice.PageObjects;
using AutomationPractice.Drivers.Driver;

namespace AutomationPractice.StepDefinitions
{
    [Binding]
    public class AddAndRemoveElementsStepDefinitions
    {
        private readonly HomePage _homePage = HomePage.GetHomePage();
        readonly AddRemoveElementsPage _addRemoveElementsPage = AddRemoveElementsPage.GetAddRemoveElementsPage();

        [When(@"I will go to '([^']*)' section")]
        public void WhenIWillGoToSection(string sectionName) => _homePage.OpenPage(sectionName);

        [When(@"I will add element")]
        public void WhenIWillAddElement() => _addRemoveElementsPage.ClickAddElementButton();

        [When(@"I will remove all the elements")]
        public void WhenIWillRemoveAllTheElements()
        {
                while (true)
            {
                bool isDeleteButtonEnabled = _addRemoveElementsPage.CheckDeleteElement();
                if (isDeleteButtonEnabled == true)
                {
                    _addRemoveElementsPage.DeleteElement();
                }
                if (isDeleteButtonEnabled == false)
                {
                    return;
                }
            }
        }
    }
}
