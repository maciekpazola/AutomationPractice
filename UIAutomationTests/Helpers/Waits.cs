using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using UIAutomationTests.Drivers;

namespace UIAutomationTests.Helpers
{
    public class Waits
    {
        private readonly ScenarioContext _scenarioContext;

        public Waits(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        public DefaultWait<IWebDriver> GetWebDriverWait(int timeoutInSeconds = 5)
        {
            DefaultWait<IWebDriver> wait = new(Driver.GetDriver(_scenarioContext));
            wait.Timeout = TimeSpan.FromSeconds(timeoutInSeconds);

            return wait;
        }

        public bool WaitUntil(Func<bool> condition, int timeoutInSeconds = 5)
        {
            DateTime startTime = DateTime.Now;

            while ((DateTime.Now - startTime).TotalSeconds < timeoutInSeconds)
            {
                try
                {
                    if (condition())
                    {
                        return true;
                    }
                }
                catch
                {
                }

                Thread.Sleep(500);
            }

            return false;
        }
    }
}
