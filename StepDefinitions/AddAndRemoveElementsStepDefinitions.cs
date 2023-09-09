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
            HomePage page = new(_scenarioContext);
            dynamic data = table.CreateDynamicInstance();
            _scenarioContext.Add("BrowserName", (string)data.Browsers);

            page.GoToHomePage();
        }

        [When(@"'([^']*)' section is opened")]
        public void WhenSectionIsOpened(string sectionName)
        {
            HomePage page = new(_scenarioContext);
            page.OpenPage(sectionName);
        }

        [When(@"Element is added")]
        public void WhenElementIsAdded()
        {
            AddRemoveElementsPage page = new(_scenarioContext);
            page.ClickAddElementButton();
        }
        [When(@"All elements are removed")]
        public void WhenAllElementsAreRemoved()
        {
            AddRemoveElementsPage page = new(_scenarioContext);
            page.RemoveAllTheElements();
        }
    }
}
