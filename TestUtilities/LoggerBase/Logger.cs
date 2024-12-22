namespace TestUtilities.Logs
{
    public class Logger(string scenarioName)
    {
        private readonly DatabaseConnector _dbConnector = new();

        public void WriteErrorLog(string message) => WriteLog(message, LogType.Error);

        public void WriteInfoLog(string message) => WriteLog(message, LogType.Info);

        public void WriteWarningLog(string message) => WriteLog(message, LogType.Warning);

        private void WriteLog(string message, LogType type)
        {
            var logEntry = new LogEntry
            {
                TestName = scenarioName,
                LogTime = DateTime.Now,
                LogLevel = type.ToString(),
                Message = message,
                Id = _dbConnector.GetNextSequenceValue("log_entries")
            };
            _dbConnector.GetLogsStorage().InsertOne(logEntry);
        }
    }
}