using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using AutomationPractice.PageObjects;

namespace AutomationPractice.StepDefinitions
{
    [Binding]
    public class AddAndRemoveElementsStepDefinitions
    {
        [When(@"'([^']*)' section is opened")]
        public void WhenSectionIsOpened(string sectionName) => Page.Home.OpenPage(sectionName);

        [When(@"Element is added")]
        public void WhenElementIsAdded() => Page.AddRemoveElements.ClickAddElementButton();

        [When(@"All elements are removed")]
        public void WhenAllElementsAreRemoved() => Page.AddRemoveElements.RemoveAllTheElements();

    }
}
