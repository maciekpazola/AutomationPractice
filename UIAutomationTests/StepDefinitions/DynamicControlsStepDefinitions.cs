using AutomationPractice.PageObjects;
using NUnit.Framework;

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
        public void ThenCheckboxWillGone()
        {
            _dynamicControlsPage.WaitUntilChecboxIsVisible();
            Assert.That(_dynamicControlsPage.IsCheckboxDisplayed(), Is.False);
        }

        [When(@"I will add checkbox")]
        public void WhenIWillAddCheckbox() => _dynamicControlsPage.AddCheckbox();

        [Then(@"Checkbox will appear")]
        public void ThenCheckboxWillAppear() => Assert.That(_dynamicControlsPage.IsCheckboxDisplayed(), Is.True);

        [When(@"I will click enable")]
        public void WhenIWillClickEnable() => _dynamicControlsPage.ClickEnable();

        [Then(@"form will be enable")]
        public void ThenFormWillBeEnable() => Assert.That(_dynamicControlsPage.IsFormFieldEnabled(), Is.EqualTo(true));

        [When(@"I will fill in form")]
        public void WhenIWillFillInForm() => _dynamicControlsPage.FillInFormField("Text123");

        [When(@"I will click disable")]
        public void WhenIWillClickDisable() => _dynamicControlsPage.ClickDisable();

        [Then(@"form will be disable")]
        public void ThenFormWillBeDisable() => Assert.That(_dynamicControlsPage.IsFormFieldEnabled(), Is.EqualTo(false));

    }
}
