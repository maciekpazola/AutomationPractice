using System.Text;
using OpenQA.Selenium;
using TechTalk.SpecFlow.Tracing;

namespace TestUtilities.UITesting.Helpers
{
    public class FileManager(FeatureContext featureContext, ScenarioContext scenarioContext)
    {
        private readonly ScenarioContext _scenarioContext = scenarioContext;
        private readonly FeatureContext _featureContext = featureContext;

        public string GetFileNameBaseForScreenshot() => string.Format(
            "Error_{0}_{1}_{2}",
            _featureContext.FeatureInfo.Title.ToIdentifier(),
            _scenarioContext.ScenarioInfo.Title.ToIdentifier(),
            DateTime.Now.ToString("yyyyMMdd_HHmmss"));

        private string GetFileNameBaseForReport() =>
            string.Format("Report_{0}", DateTime.Now.ToString("yyyyMMdd_HHmmss"));

        public string GetArtifactDirectory()
        {
            var artifactDirectory = Path.Combine(Directory.GetCurrentDirectory(), "testresults");
            if (!Directory.Exists(artifactDirectory))
                Directory.CreateDirectory(artifactDirectory);

            return artifactDirectory;
        }

        public string GetReportFilePath()
        {
            string artifactDirectory = GetArtifactDirectory();
            string fileNameBase = GetFileNameBaseForReport();

            return Path.Combine(artifactDirectory, fileNameBase);
        }

        public void CreateSourceFile(IWebDriver driver, string artifactDirectory, string fileNameBase)
        {
            string pageSource = driver.PageSource;
            string sourceFilePath = Path.Combine(artifactDirectory, fileNameBase + "_source.html");

            File.WriteAllText(sourceFilePath, pageSource, Encoding.UTF8);
            Console.WriteLine("Page source: {0}", new Uri(sourceFilePath));
        }

        public void CreateErrorFile(Screenshot screenshot, string artifactDirectory, string fileNameBase)
        {
            string screenshotFilePath = Path.Combine(artifactDirectory, fileNameBase + "_screenshot.png");

            screenshot.SaveAsFile(screenshotFilePath, ScreenshotImageFormat.Png);
            Console.WriteLine("Screenshot: {0}", new Uri(screenshotFilePath));
        }
    }
}
