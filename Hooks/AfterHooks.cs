using AutomationPractice.DriverFolder;
using OpenQA.Selenium;
using System.Reflection;

namespace AutomationPractice.Drivers.Hooks
{
    [Binding]
    public static class AfterHooks
    {
        [AfterTestRun]
        public static void CloseApp()
        {
            IWebDriver driver = Driver.GetInstanceOfDriver().GetDriver();
            driver.Quit();
        }
        [AfterStep]
        public static void InsertLogs(ScenarioContext sc)
        {
            {
                PropertyInfo pInfo = typeof(ScenarioContext).GetProperty("ScenarioExecutionStatus", BindingFlags.Instance | BindingFlags.Public);
                MethodInfo getter = pInfo.GetGetMethod(nonPublic: true);
                object TestResult = getter.Invoke(sc, null);

                if (sc.TestError == null)
                {
                    logger.Logger.WriteInfoLog(ScenarioStepContext.Current.StepInfo.Text);
                    logger.Logger.WriteToLog(TestResult.ToString());
                }
                if (sc.TestError != null)
                {
                    logger.Logger.WriteErrorLog(sc.TestError.ToString());
                }
            }
        }
    }
}
