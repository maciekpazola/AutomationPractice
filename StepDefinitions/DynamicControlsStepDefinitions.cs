using AutomationPractice.PageObjects;

namespace AutomationPractice.StepDefinitions
{
    [Binding]
    public class DynamicControlsStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        public DynamicControlsStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [When(@"I will remove checkbox")]
        public void WhenIWillRemoveCheckbox()
        {
            DynamicControlsPage page = new(_scenarioContext);
            page.RemoveCheckbox();
        }

        [Then(@"Checkbox will gone")]
        public void ThenCheckboxWillGone()
        {
            DynamicControlsPage page = new(_scenarioContext);
            page.AssertIfCheckboxIsPresent(false);
        }

        [When(@"I will add checkbox")]
        public void WhenIWillAddCheckbox()
        {
            DynamicControlsPage page = new(_scenarioContext);
            page.AddCheckbox();
        }

        [Then(@"Checkbox will appear")]
        public void ThenCheckboxWillAppear()
        {
            DynamicControlsPage page = new(_scenarioContext);
            page.AssertIfCheckboxIsPresent(true);
        }


        [When(@"I will click enable")]
        public void WhenIWillClickEnable()
        {
            DynamicControlsPage page = new(_scenarioContext);
            page.ClickEnable();
        }

        [Then(@"form will be enable")]
        public void ThenFormWillBeEnable()
        {
            DynamicControlsPage page = new(_scenarioContext);
            page.AssertIfFormIsEnable(true);
        }

        [When(@"I will fill in form")]
        public void WhenIWillFillInForm()
        {
            DynamicControlsPage page = new(_scenarioContext);
            page.FillInFormField("Text123");
        }

        [When(@"I will click disable")]
        public void WhenIWillClickDisable()
        {
            DynamicControlsPage page = new(_scenarioContext);
            page.ClickDisable();
        }

        [Then(@"form will be disable")]
        public void ThenFormWillBeDisable()
        {
            DynamicControlsPage page = new(_scenarioContext);
            page.AssertIfFormIsEnable(false);
        }
    }
}
