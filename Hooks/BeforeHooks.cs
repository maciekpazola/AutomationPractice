using AutomationPractice.Drivers;
using AutomationPractice.PageObjects;
using AutomationPractice.Helpers;
using OpenQA.Selenium;
using NUnit.Framework;
[assembly: Parallelizable(ParallelScope.Fixtures)]
[assembly: LevelOfParallelism(3)]

namespace AutomationPractice.Drivers.Hooks
{
    [Binding]
    public class BeforeHooks
    {
        private readonly ScenarioContext _scenarioContext;
        //TO DO DEPENDENCY INJECTION FOR DRIVER TO SHARE IT BETWEEN CLASSES
        public BeforeHooks(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;
        private IWebDriver _driver;

        [BeforeScenario]
        public void Initialize()
        {
            TestScenarioContext.ScenarioContext = _scenarioContext;
            //Logger.ClearLogFile();
        }

        //[BeforeScenario]
        public void BeforeScenario()
        {
            Logger.WriteToLog(string.Empty);
            Logger.WriteToLog($"{_scenarioContext.ScenarioInfo.Title}:");
        }
    }
    public static class TestScenarioContext
    {
        public static ScenarioContext ScenarioContext { get; set; }
    }
}
