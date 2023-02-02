using AutomationPractice.PageObjects;
using System;
using TechTalk.SpecFlow;

namespace AutomationPractice.StepDefinitions
{
    [Binding]
    public class DynamicControlsStepDefinitions
    {
        [When(@"I will remove checkbox")]
        public void WhenIWillRemoveCheckbox()=> Page.DynamicControls.RemoveCheckbox();
       

        [Then(@"Checkbox will gone")]
        public void ThenCheckboxWillGone()=> Page.DynamicControls.AssertIfCheckboxIsPresent(false);

        [When(@"I will add checkbox")]
        public void WhenIWillAddCheckbox()=> Page.DynamicControls.AddCheckbox();

        [Then(@"Checkbox will appear")]
        public void ThenCheckboxWillAppear()=> Page.DynamicControls.AssertIfCheckboxIsPresent(true);
    }
}
