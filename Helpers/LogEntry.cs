using MongoDB.Bson;

namespace AutomationPractice.Helpers
{
    public class LogEntry
    {
        public int Id { get; set; }
        public string TestName { get; set; }
        public DateTime LogTime { get; set; }
        public string LogLevel { get; set; }
        public string Message { get; set; }
    }
}
