namespace TestUtilities.Logs
{
    public class Logger(string scenarioName)
    {
        private readonly DatabaseConnector _dbConnector = new();
        private readonly string _scenarioName = scenarioName;

        public void WriteErrorLog(string message) => WriteLog(message, "Error");

        public void WriteInfoLog(string message) => WriteLog(message, "Info");

        public void WriteWarningLog(string message) => WriteLog(message, "Warning");

        private void WriteLog(string message, string type)
        {
            var logEntry = new LogEntry
            {
                TestName = _scenarioName,
                LogTime = DateTime.Now,
                LogLevel = type,
                Message = message,
                Id = _dbConnector.GetNextSequenceValue("log_entries")
        };
            _dbConnector.GetLogsStorage().InsertOne(logEntry);
        }
    }
}