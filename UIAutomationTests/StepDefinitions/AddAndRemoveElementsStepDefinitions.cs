using AutomationPractice.PageObjects;
using TechTalk.SpecFlow.Assist;
using UIAutomationTests.PageObjects;

namespace UIAutomationTests.StepDefinitions
{
    [Binding]
    public class AddAndRemoveElementsStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly HomePage _homePage;
        private readonly AddRemoveElementsPage _addRemoveElementsPage;

        public AddAndRemoveElementsStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _homePage = new(scenarioContext);
            _addRemoveElementsPage = new(scenarioContext);
        }

        [Given(@"Website is opened with following browsers")]
        public void GivenWebsiteIsOpenedWithFollowingBrowsers(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            _scenarioContext.Add("BrowserName", (string)data.Browsers);

            _homePage.GoToHomePage();
        }

        [When(@"'([^']*)' section is opened")]
        public void WhenSectionIsOpened(string sectionName) => _homePage.OpenPage(sectionName);

        [When(@"Element is added")]
        public void WhenElementIsAdded() => _addRemoveElementsPage.ClickAddElementButton();

        [When(@"All elements are removed")]
        public void WhenAllElementsAreRemoved() => _addRemoveElementsPage.RemoveAllTheElements();
    }
}
