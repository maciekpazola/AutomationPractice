using TestUtilities.UITesting.Helpers;
using TestUtilities.UITesting.Drivers;
using OpenQA.Selenium;
using TestUtilities.Logs;

namespace AutomationPractice.Hooks
{
    [Binding]
    public class ScreenshotHook
    {
        private IWebDriver DriverInstance() => Driver.GetDriver(_scenarioContext.Get<string>("BrowserName"));
        private readonly FeatureContext _featureContext;
        private readonly ScenarioContext _scenarioContext;
        private readonly Logger _logger;
        private readonly FileManager _fileManager;

        public ScreenshotHook(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;
            _logger = new(_featureContext, _scenarioContext);
            _fileManager = new(_featureContext, _scenarioContext);
        }

        [AfterScenario]
        public void AfterWebTest()
        {
            if (_scenarioContext.TestError != null)
            {
                _logger.WriteWarningLog("Screenshot is taken, because test is failed");
                TakeScreenshot(DriverInstance());
            }
        }

        private void TakeScreenshot(IWebDriver driver)
        {
            try
            {
                string fileNameBase = _fileManager.GetFileNameBaseForScreenshot();
                string artifactDirectory = _fileManager.GetArtifactDirectory();

                ITakesScreenshot takesScreenshot = driver as ITakesScreenshot;

                if (takesScreenshot != null)
                {
                    var screenshot = takesScreenshot.GetScreenshot();

                    _fileManager.CreateSourceFile(DriverInstance(), artifactDirectory, fileNameBase);
                    _fileManager.CreateErrorFile(screenshot, artifactDirectory, fileNameBase);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while taking screenshot: {ex}");
            }
        }
    }
}
