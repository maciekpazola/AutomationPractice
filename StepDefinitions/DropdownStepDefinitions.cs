using AutomationPractice.Drivers.Driver;
using AutomationPractice.PageObjects;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace AutomationPractice.StepDefinitions
{
    [Binding]
    public class DropdownStepDefinitions
    {
        readonly DropdownPage dropdownPage = DropdownPage.GetDropdownPage();

        [When(@"I will select every option")]
        public void WhenIWillSelectEveryOption()
        {
            dropdownPage.SelectAllElementsInDropdown();
        }

        [Then(@"I will assert if number of options in dropdow are equal '([^']*)'")]
        public void ThenIWillAssertIfNumberOfOptionsInDropdowAreEqual(string numberOfOptions)
        {
            dropdownPage.AssertNumberOfElementsInDropdown(Int16.Parse(numberOfOptions));
        }
    }
}
