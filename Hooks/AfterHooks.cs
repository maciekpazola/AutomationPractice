using AutomationPractice.Drivers;
using AutomationPractice.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Reflection;

namespace AutomationPractice.Drivers.Hooks
{
    [Binding]
    public class AfterHooks
    {
        private readonly ScenarioContext _scenarioContext;
        public AfterHooks(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;
        [AfterScenario]
        public void Cleanup()
        {
            var driver = Driver.GetDriver(_scenarioContext.Get<string>("BrowserName"));
            driver.Quit();
            driver.Dispose();
        }

        public void InsertLogs()
        {
            {
                PropertyInfo pInfo = typeof(ScenarioContext).GetProperty("ScenarioExecutionStatus", BindingFlags.Instance | BindingFlags.Public);
                MethodInfo getter = pInfo.GetGetMethod(nonPublic: true);
                object TestResult = getter.Invoke(_scenarioContext, null);

                if (_scenarioContext.TestError == null)
                {
                    Logger.WriteInfoLog(_scenarioContext.StepContext.StepInfo.Text);
                    Logger.WriteToLog(TestResult.ToString());
                }
                if (_scenarioContext.TestError != null)
                {
                    Logger.WriteErrorLog(_scenarioContext.TestError.ToString());
                }
            }
        }
    }
}
