using AutomationPractice.PageObjects;

namespace AutomationPractice.StepDefinitions
{
    [Binding]
    public class DynamicControlsStepDefinitions
    {
        private readonly DynamicControlsPage _dynamicControlsPage;
        public DynamicControlsStepDefinitions(ScenarioContext scenarioContext)
        {
            _dynamicControlsPage = new DynamicControlsPage(scenarioContext);
        }

        [When(@"I will remove checkbox")]
        public void WhenIWillRemoveCheckbox() => _dynamicControlsPage.RemoveCheckbox();

        [Then(@"Checkbox will gone")]
        public void ThenCheckboxWillGone() => _dynamicControlsPage.AssertIfCheckboxIsPresent(false);

        [When(@"I will add checkbox")]
        public void WhenIWillAddCheckbox() => _dynamicControlsPage.AddCheckbox();

        [Then(@"Checkbox will appear")]
        public void ThenCheckboxWillAppear() => _dynamicControlsPage.AssertIfCheckboxIsPresent(true);

        [When(@"I will click enable")]
        public void WhenIWillClickEnable() => _dynamicControlsPage.ClickEnable();

        [Then(@"form will be enable")]
        public void ThenFormWillBeEnable() => _dynamicControlsPage.AssertIfFormIsEnable(true);

        [When(@"I will fill in form")]
        public void WhenIWillFillInForm() => _dynamicControlsPage.FillInFormField("Text123");

        [When(@"I will click disable")]
        public void WhenIWillClickDisable() => _dynamicControlsPage.ClickDisable();

        [Then(@"form will be disable")]
        public void ThenFormWillBeDisable() => _dynamicControlsPage.AssertIfFormIsEnable(false);
    }
}
