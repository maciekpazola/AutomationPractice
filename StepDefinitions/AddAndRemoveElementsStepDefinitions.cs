using AutomationPractice.Drivers;
using AutomationPractice.PageObjects;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace AutomationPractice.StepDefinitions
{
    [Binding]
    public class AddAndRemoveElementsStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        public AddAndRemoveElementsStepDefinitions(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;


        [Given(@"Website is opened with following browsers")]
        public void GivenWebsiteIsOpenedWithFollowingBrowsers(Table table)
        {
            HomePage home = new HomePage(_scenarioContext);
            dynamic data = table.CreateDynamicInstance();
            _scenarioContext.Add("BrowserName", (string)data.Browsers);

            home.GoToHomePage();
        }

        [When(@"'([^']*)' section is opened")]
        public void WhenSectionIsOpened(string sectionName)
        {
            HomePage home = new HomePage(_scenarioContext);
            home.OpenPage(sectionName);
        }

        [When(@"Element is added")]
        public void WhenElementIsAdded() => Page.AddRemoveElements.ClickAddElementButton();

        [When(@"All elements are removed")]
        public void WhenAllElementsAreRemoved() => Page.AddRemoveElements.RemoveAllTheElements();
    }
}
