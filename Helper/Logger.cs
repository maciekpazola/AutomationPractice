using AutomationPractice.Helper;
using System.Configuration;

namespace logger
{
    public static class Logger
    {
        private static void WriteLog(string message, string type)
        {
            string logFile = FileManager.GetArtifactDirectory() + @"\log.txt";
            using (StreamWriter sw = new StreamWriter(logFile, true))
            {
                sw.WriteLine($"{DateTime.Now} : [{type}] {message}");
            }
        }
        public static void WriteErrorLog(string message) => WriteLog(message, "Error");

        public static void WriteInfoLog(string message) => WriteLog(message, "Info");

        public static void WriteWarningLog(string message) => WriteLog(message, "Warning");

        public static void WriteToLog(string message)
        {
            string logFile = FileManager.GetArtifactDirectory() + @"\log.txt";
            using (StreamWriter sw = new StreamWriter(logFile, true))
            {
                sw.WriteLine(message);
            }
        }

        public static void ClearLogFile()
        {
            string logFile = FileManager.GetArtifactDirectory() + @"\log.txt";
            File.Delete(logFile);
        }
    }
}