using AutomationPractice.Drivers;
using AutomationPractice.Helpers;
using System.Reflection;

namespace AutomationPractice.Drivers.Hooks
{
    [Binding]
    public static class AfterHooks
    {
        [AfterTestRun]
        public static void CloseApp() => Driver.GetInstanceOfDriver().GetDriver().Quit();

        [AfterStep]
        public static void InsertLogs(ScenarioContext sc)
        {
            {
                PropertyInfo pInfo = typeof(ScenarioContext).GetProperty("ScenarioExecutionStatus", BindingFlags.Instance | BindingFlags.Public);
                MethodInfo getter = pInfo.GetGetMethod(nonPublic: true);
                object TestResult = getter.Invoke(sc, null);

                if (sc.TestError == null)
                {
                    Logger.WriteInfoLog(ScenarioStepContext.Current.StepInfo.Text);
                    Logger.WriteToLog(TestResult.ToString());
                }
                if (sc.TestError != null)
                {
                    Logger.WriteErrorLog(sc.TestError.ToString());
                }
            }
        }
    }
}
