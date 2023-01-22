using AutomationPractice.DriverFolder;
using System;
using TechTalk.SpecFlow;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using System.Reflection;
using OpenQA.Selenium;

namespace AutomationPractice.Drivers.Hooks.Reports
{
     [Binding]
    class Reporter : Steps
    {
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extent;
        private readonly static string reportFileLocation = @"C:\Users\MAPA\source\repos\AutomationPractice\Hooks\Reports\ReporterHooks";

        [BeforeTestRun]
        public static void InitializeReport()
        {
            var htmlReporter = new ExtentHtmlReporter(reportFileLocation);
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            featureName = extent.CreateTest(new GherkinKeyword("Feature") + featureContext.FeatureInfo.Title);
            scenario = featureName.CreateNode(new GherkinKeyword("Scenario") + featureContext.FeatureInfo.Title);
        }

        [AfterTestRun]
        public static void TearDownReport() => extent.Flush();

        [AfterStep]
        public void InsertReportingSteps(ScenarioContext sc)
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            PropertyInfo pInfo = typeof(ScenarioContext).GetProperty("ScenarioExecutionStatus", BindingFlags.Instance | BindingFlags.Public);
            MethodInfo getter = pInfo.GetGetMethod(nonPublic: true);
            object TestResult = getter.Invoke(sc, null);
            if (sc.TestError == null)
            {
                if (stepType == "Given")
                    scenario.CreateNode(new GherkinKeyword("Given"), ScenarioStepContext.Current.StepInfo.Text).Pass("Pass");
                else if (stepType == "When")
                    scenario.CreateNode(new GherkinKeyword("When"), ScenarioStepContext.Current.StepInfo.Text).Pass("Pass");
                else if (stepType == "Then")
                    scenario.CreateNode(new GherkinKeyword("Then"), ScenarioStepContext.Current.StepInfo.Text).Pass("Pass");
                else if (stepType == "And")
                    scenario.CreateNode(new GherkinKeyword("And"), ScenarioStepContext.Current.StepInfo.Text).Pass("Pass");
            }
            if (sc.TestError != null)
            {
                if (stepType == "Given")
                    scenario.CreateNode(new GherkinKeyword("Given"), ScenarioStepContext.Current.StepInfo.Text).Fail(sc.TestError.Message);
                if (stepType == "When")
                    scenario.CreateNode(new GherkinKeyword("When"), ScenarioStepContext.Current.StepInfo.Text).Fail(sc.TestError.Message);
                if (stepType == "Then")
                    scenario.CreateNode(new GherkinKeyword("Then"), ScenarioStepContext.Current.StepInfo.Text).Fail(sc.TestError.Message);
                if (stepType == "And")
                    scenario.CreateNode(new GherkinKeyword("And"), ScenarioStepContext.Current.StepInfo.Text).Fail(sc.TestError.Message);
            }
        }
    }
}
