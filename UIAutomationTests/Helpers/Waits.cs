using TestUtilities.UITesting.Drivers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestUtilities.UITesting.Helpers
{
    public class Waits
    {
        private readonly ScenarioContext _scenarioContext;
        public Waits(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;
        public DefaultWait<IWebDriver> GetWebDriverWait(int timeoutInSeconds = 5)
        {
            DefaultWait<IWebDriver> wait = new(Driver.GetDriver(_scenarioContext.Get<string>("BrowserName")));
            wait.Timeout = TimeSpan.FromSeconds(timeoutInSeconds);

            return wait;
        }
        public DefaultWait<IWebDriver> GetFluentWait(int timeoutInSeconds = 3, int pollingIntervalInMilliseconds = 100)
        {
            DefaultWait<IWebDriver> fluentWait = new(Driver.GetDriver(_scenarioContext.Get<string>("BrowserName")));
            fluentWait.Timeout = TimeSpan.FromSeconds(timeoutInSeconds);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(pollingIntervalInMilliseconds);

            return fluentWait;
        }
    }
}
