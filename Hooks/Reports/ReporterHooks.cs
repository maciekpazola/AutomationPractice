using System.Reflection;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Config;
using TestUtilities.UITesting.Helpers;
namespace AutomationPractice.Drivers.Hooks.Reports.Properties
{
    [Binding]
    class Reporter : Steps
    {
        private static ExtentTest _featureName;
        private static ExtentTest _scenario;
        private static ExtentReports _extent;
        private readonly FeatureContext _featureContext;
        private readonly ScenarioContext _scenarioContext;
        private readonly FileManager _fileManager;
        public Reporter(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;
            _fileManager = new(_featureContext, _scenarioContext);
            var htmlReporter = new ExtentSparkReporter(_fileManager.GetReportFilePath());
            htmlReporter.Config.Theme = Theme.Dark;
            _extent = new ExtentReports();
            _extent.AttachReporter(htmlReporter);
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            _extent = new ExtentReports();
            _featureName = _extent.CreateTest(new GherkinKeyword("Feature"), featureContext.FeatureInfo.Title);
            _scenario = _featureName.CreateNode(new GherkinKeyword("Scenario"), featureContext.FeatureInfo.Title);
        }

        [AfterTestRun]
        public static void TearDownReport() => _extent.Flush();

        [AfterStep]
        public void InsertReportingSteps(ScenarioContext sc)
        {
            var stepType = _scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            PropertyInfo pInfo = typeof(ScenarioContext).GetProperty("ScenarioExecutionStatus", BindingFlags.Instance | BindingFlags.Public);
            MethodInfo getter = pInfo.GetGetMethod(nonPublic: true);
            object TestResult = getter.Invoke(sc, null);
            if (sc.TestError == null)
            {
                if (stepType == "Given")
                    _scenario.CreateNode(new GherkinKeyword("Given"), _scenarioContext.StepContext.StepInfo.Text).Pass("Pass");
                else if (stepType == "When")
                    _scenario.CreateNode(new GherkinKeyword("When"), _scenarioContext.StepContext.StepInfo.Text).Pass("Pass");
                else if (stepType == "Then")
                    _scenario.CreateNode(new GherkinKeyword("Then"), _scenarioContext.StepContext.StepInfo.Text).Pass("Pass");
                else if (stepType == "And")
                    _scenario.CreateNode(new GherkinKeyword("And"), _scenarioContext.StepContext.StepInfo.Text).Pass("Pass");
            }
            if (sc.TestError != null)
            {
                if (stepType == "Given")
                    _scenario.CreateNode(new GherkinKeyword("Given"), _scenarioContext.StepContext.StepInfo.Text).Fail(sc.TestError.Message);
                if (stepType == "When")
                    _scenario.CreateNode(new GherkinKeyword("When"), _scenarioContext.StepContext.StepInfo.Text).Fail(sc.TestError.Message);
                if (stepType == "Then")
                    _scenario.CreateNode(new GherkinKeyword("Then"), _scenarioContext.StepContext.StepInfo.Text).Fail(sc.TestError.Message);
                if (stepType == "And")
                    _scenario.CreateNode(new GherkinKeyword("And"), _scenarioContext.StepContext.StepInfo.Text).Fail(sc.TestError.Message);
            }
        }
    }
}
