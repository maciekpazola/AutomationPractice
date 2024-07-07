using TestUtilities.UITesting.Drivers;
using System.Reflection;
using TestUtilities.Logs;

namespace AutomationPractice.Drivers.Hooks
{
    [Binding]
    public class AfterHooks(ScenarioContext scenarioContext)
    {
        private readonly ScenarioContext _scenarioContext = scenarioContext;
        private readonly Logger _logger = new(scenarioContext.ScenarioInfo.Title);

        [AfterScenario]
        public void Cleanup()
        {
            var driver = Driver.GetDriver(_scenarioContext.Get<string>("BrowserName"));
            driver.Quit();
            driver.Dispose();
        }

        [AfterStep]
        public void InsertLogs()
        {
            {
                PropertyInfo pInfo = typeof(ScenarioContext).GetProperty("ScenarioExecutionStatus", BindingFlags.Instance | BindingFlags.Public);
                MethodInfo getter = pInfo.GetGetMethod(nonPublic: true);
                object TestResult = getter.Invoke(_scenarioContext, null);

                if (_scenarioContext.TestError == null)
                {
                    _logger.WriteInfoLog(_scenarioContext.StepContext.StepInfo.Text);
                    _logger.WriteInfoLog("Step Done");
                }
                if (_scenarioContext.TestError != null)
                {
                    _logger.WriteErrorLog(_scenarioContext.TestError.ToString());
                }
            }
        }
    }
}
