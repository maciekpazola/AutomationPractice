namespace TestUtilities.Logs
{
    public class LogEntry
    {
        public required int Id { get; set; }
        public required string TestName { get; set; }
        public required DateTime LogTime { get; set; }
        public required string LogLevel { get; set; }
        public required string Message { get; set; }
    }
}
