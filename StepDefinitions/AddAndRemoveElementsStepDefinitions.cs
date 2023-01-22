using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using AutomationPractice.PageObjects;

namespace AutomationPractice.StepDefinitions
{
    [Binding]
    public class AddAndRemoveElementsStepDefinitions
    {
        [When(@"I will go to '([^']*)' section")]
        public void WhenIWillGoToSection(string sectionName) => Page.Home.OpenPage(sectionName);

        [When(@"I will add element")]
        public void WhenIWillAddElement() => Page.AddRemoveElements.ClickAddElementButton();

        [When(@"I will remove all the elements")]
        public void WhenIWillRemoveAllTheElements() => Page.AddRemoveElements.RemoveAllTheElements();
    }
}
