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
        readonly HomePage homePage = HomePage.GetHomePage();
        readonly AddRemoveElementsPage addRemoveElementsPage = AddRemoveElementsPage.GetAddRemoveElementsPage();

        [When(@"I will go to '([^']*)' section")]
        public void WhenIWillGoToSection(string sectionName)
        {

            homePage.OpenPage(sectionName);
        }

        [When(@"I will add element")]
        public void WhenIWillAddElement()
        {
            addRemoveElementsPage.ClickAddElementButton();
        }

        [When(@"I will remove all the elements")]
        public void WhenIWillRemoveAllTheElements()
        {
                while (true)
            {
                bool isDeleteButtonEnabled = addRemoveElementsPage.CheckDeleteElement();
                if (isDeleteButtonEnabled == true)
                {
                    addRemoveElementsPage.DeleteElement();
                }
                if (isDeleteButtonEnabled == false)
                {
                    return;
                }
            }
        }
    }
}
