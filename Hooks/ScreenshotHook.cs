using AutomationPractice.Drivers;
using AutomationPractice.Helpers;
using OpenQA.Selenium;

namespace AutomationPractice.Hooks
{
    [Binding]
    public class ScreenshotHook
    {
        private readonly IWebDriver _driver = Driver.GetInstanceOfDriver().GetDriver();

        [AfterScenario]
        public void AfterWebTest()
        {
            if (ScenarioContext.Current.TestError != null)
            {
                Logger.WriteWarningLog("Screenshot is taken, because test is failed");
                TakeScreenshot(_driver);
            }
        }

        private void TakeScreenshot(IWebDriver driver)
        {
            try
            {
                string fileNameBase = FileManager.GetFileNameBaseForScreenshot();
                string artifactDirectory = FileManager.GetArtifactDirectory();

                ITakesScreenshot takesScreenshot = driver as ITakesScreenshot;

                if (takesScreenshot != null)
                {
                    var screenshot = takesScreenshot.GetScreenshot();

                    FileManager.CreateSourceFile(_driver, artifactDirectory, fileNameBase);
                    FileManager.CreateErrorFile(screenshot, artifactDirectory, fileNameBase);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while taking screenshot: {ex}");
            }
        }
    }
}
