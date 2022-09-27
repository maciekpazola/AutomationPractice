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
        public DropdownStepDefinitions(DropdownPage dropdownPage)
        {
            _dropdownPage = dropdownPage;
        }
        private DropdownPage _dropdownPage;

        [When(@"I will select every option")]
        public void WhenIWillSelectEveryOption()
        {
            _dropdownPage.SelectAllElementsInDropdown();
        }

        [Then(@"I will assert if number of options in dropdow are equal '([^']*)'")]
        public void ThenIWillAssertIfNumberOfOptionsInDropdowAreEqual(string numberOfOptions)
        {
            _dropdownPage.AssertNumberOfElementsInDropdown(Int16.Parse(numberOfOptions));
        }
    }
}
