using AutomationPractice.PageObjects;
using System;
using TechTalk.SpecFlow;

namespace AutomationPractice.StepDefinitions
{
    [Binding]
    public class CheckboxesStepDefinitions
    {
        [When(@"I will check all checkboxes")]
        public void WhenIWillCheckAllCheckboxes()=> Page.Checkboxes.CheckAllCheckboxes();

        [Then(@"All checkboxes are checked")]
        public void ThenAllCheckboxesAreChecked()=> Page.Checkboxes.AssertIfAllCheckboxesAreChecked();

        [When(@"I will uncheck all checkboxes")]
        public void WhenIWillUncheckAllCheckboxes() => Page.Checkboxes.UnCheckAllCheckboxes();

        [Then(@"All checkboxes are unchecked")]
        public void ThenAllCheckboxesAreUnchecked() => Page.Checkboxes.AssertIfAllCheckboxesAreUnChecked();
    }
}
