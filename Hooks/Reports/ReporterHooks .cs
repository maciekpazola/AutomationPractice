using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using System.Reflection;


namespace AutomationPractice.Drivers.Hooks.Reports.Properties
{
     [Binding]
    class Reporter : Steps
    {
        private static ExtentTest _featureName;
        private static ExtentTest _scenario;
        private static ExtentReports _extent;
        private readonly static string reportFileLocation = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

        [BeforeTestRun]
        public static void InitializeReport()
        {
            var htmlReporter = new ExtentHtmlReporter(reportFileLocation);
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            _extent = new ExtentReports();
            _extent.AttachReporter(htmlReporter);
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            _featureName = _extent.CreateTest(new GherkinKeyword("Feature"), featureContext.FeatureInfo.Title);
            _scenario = _featureName.CreateNode(new GherkinKeyword("Scenario"), featureContext.FeatureInfo.Title);
        }

        [AfterTestRun]
        public static void TearDownReport() => _extent.Flush();

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
                    _scenario.CreateNode(new GherkinKeyword("Given"), ScenarioStepContext.Current.StepInfo.Text).Pass("Pass");
                else if (stepType == "When")
                    _scenario.CreateNode(new GherkinKeyword("When"), ScenarioStepContext.Current.StepInfo.Text).Pass("Pass");
                else if (stepType == "Then")
                    _scenario.CreateNode(new GherkinKeyword("Then"), ScenarioStepContext.Current.StepInfo.Text).Pass("Pass");
                else if (stepType == "And")
                    _scenario.CreateNode(new GherkinKeyword("And"), ScenarioStepContext.Current.StepInfo.Text).Pass("Pass");
            }
            if (sc.TestError != null)
            {
                if (stepType == "Given")
                    _scenario.CreateNode(new GherkinKeyword("Given"), ScenarioStepContext.Current.StepInfo.Text).Fail(sc.TestError.Message);
                if (stepType == "When")
                    _scenario.CreateNode(new GherkinKeyword("When"), ScenarioStepContext.Current.StepInfo.Text).Fail(sc.TestError.Message);
                if (stepType == "Then")
                    _scenario.CreateNode(new GherkinKeyword("Then"), ScenarioStepContext.Current.StepInfo.Text).Fail(sc.TestError.Message);
                if (stepType == "And")
                    _scenario.CreateNode(new GherkinKeyword("And"), ScenarioStepContext.Current.StepInfo.Text).Fail(sc.TestError.Message);
            }
        }
    }
}
