using OpenQA.Selenium;
using System.Text;
using TechTalk.SpecFlow.Tracing;

namespace AutomationPractice.Helper
{
    public static class FileManager
    {
        public static string GetFileNameBaseForScreenshot()
        {
            return string.Format("Error_{0}_{1}_{2}",
                            FeatureContext.Current.FeatureInfo.Title.ToIdentifier(),
                            ScenarioContext.Current.ScenarioInfo.Title.ToIdentifier(),
                            DateTime.Now.ToString("yyyyMMdd_HHmmss"));
        }

        public static string GetArtifactDirectory()
        {
            var artifactDirectory = Path.Combine(Directory.GetCurrentDirectory(), "testresults");
            if (!Directory.Exists(artifactDirectory))
                Directory.CreateDirectory(artifactDirectory);
            return artifactDirectory;
        }

        public static void CreateSourceFile(IWebDriver driver, string artifactDirectory, string fileNameBase)
        {
            string pageSource = driver.PageSource;
            string sourceFilePath = Path.Combine(artifactDirectory, fileNameBase + "_source.html");
            File.WriteAllText(sourceFilePath, pageSource, Encoding.UTF8);
            Console.WriteLine("Page source: {0}", new Uri(sourceFilePath));
        }

        public static void CreateErrorFile(Screenshot screenshot, string artifactDirectory, string fileNameBase)
        {

            string screenshotFilePath = Path.Combine(artifactDirectory, fileNameBase + "_screenshot.png");

            screenshot.SaveAsFile(screenshotFilePath, ScreenshotImageFormat.Png);
            Console.WriteLine("Screenshot: {0}", new Uri(screenshotFilePath));
        }
    }
}
