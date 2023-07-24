using AutomationPractice.PageObjects;

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



        [When(@"I will click enable")]
        public void WhenIWillClickEnable()=> Page.DynamicControls.ClickEnable();

        [Then(@"form will be enable")]
        public void ThenFormWillBeEnable()=> Page.DynamicControls.AssertIfFormIsEnable(true);

        [When(@"I will fill in form")]
        public void WhenIWillFillInForm() => Page.DynamicControls.FillInFormField("Text123");

        [When(@"I will click disable")]
        public void WhenIWillClickDisable()=> Page.DynamicControls.ClickDisable();

        [Then(@"form will be disable")]
        public void ThenFormWillBeDisable()=> Page.DynamicControls.AssertIfFormIsEnable(false);
    }
}
