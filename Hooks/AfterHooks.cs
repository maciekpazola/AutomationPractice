using TestUtilities.UITesting.Drivers;
using System.Reflection;
using TestUtilities.Logs;

namespace AutomationPractice.Drivers.Hooks
{
    [Binding]
    public class AfterHooks
    {
        private readonly FeatureContext _featureContext;
        private readonly ScenarioContext _scenarioContext;
        private readonly Logger _logger;

        public AfterHooks(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;
            _logger = new(_featureContext, _scenarioContext);
        }

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
