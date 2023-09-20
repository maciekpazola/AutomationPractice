using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium;

namespace AutomationPractice.Helpers
{
    public class Logger
    {
        private readonly FeatureContext _featureContext;
        private readonly ScenarioContext _scenarioContext;
        private readonly FileManager _fileManager;
        private readonly DatabaseConnector _dbConnector;
        public Logger(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;
            _fileManager = new(_featureContext, _scenarioContext);
            _dbConnector = new();
        }

        public void WriteErrorLog(string message) => WriteLog(message, "Error");

        public void WriteInfoLog(string message) => WriteLog(message, "Info");

        public void WriteWarningLog(string message) => WriteLog(message, "Warning");

        private void WriteLog(string message, string type)
        {
            var logEntry = new LogEntry
            {
                TestName = _scenarioContext.ScenarioInfo.Title,
                LogTime = DateTime.Now,
                LogLevel = type,
                Message = message
            };
            logEntry.Id = _dbConnector.GetNextSequenceValue("log_entries");
            _dbConnector.GetLogsStorage().InsertOne(logEntry);
        }
    }
}