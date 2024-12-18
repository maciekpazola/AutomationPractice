using OpenQA.Selenium;
using TestUtilities.Logs;
using UIAutomationTests.Drivers;

namespace UIAutomationTests.Helpers
{
    public class StateChecker
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly Waits _waits;
        private readonly Logger _logger;

        public StateChecker(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _waits = new(_scenarioContext);
            _logger = new(scenarioContext.ScenarioInfo.Title);
        }
        public static bool GetPropertyState(IWebElement element, string property) => Convert.ToBoolean(element.GetDomProperty(property));

        public int GetNumberOfElements(By by) => Driver.GetDriver(_scenarioContext).FindElements(by).Count;

        public bool IsElementDisplayed(Func<IWebElement> element)
        {
            try
            {
                return _waits.WaitUntil(() => element().Displayed);
            }
            catch(Exception)
            {
                _logger.WriteWarningLog("Exception was found during waiting for element");
                return false;
            }

        }
    }
}
