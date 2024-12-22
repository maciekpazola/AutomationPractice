using System.Reflection;
using TestUtilities.Logs;
using NUnit.Framework;
using UIAutomationTests.Drivers;
[assembly: Parallelizable(ParallelScope.Fixtures)]
[assembly: LevelOfParallelism(3)]

namespace AutomationPractice.Drivers.Hooks
{
    [Binding]
    public class AfterHooks(ScenarioContext scenarioContext)
    {
        private readonly ScenarioContext _scenarioContext = scenarioContext;
        private readonly Logger _logger = new(scenarioContext.ScenarioInfo.Title);

        [AfterScenario]
        public static void Cleanup() => Driver.Quit();

        [AfterStep]
        public void InsertLogs()
        {
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
