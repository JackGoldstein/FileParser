using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace FileParser
{
    public class LogAnalysis
    {

        private readonly List<Log> logs;

        public LogAnalysis(List<Log> logs)
        {
            this.logs = logs;
        }

        // Outputs all logs to the console
        public void PrintLogs()
        {
            foreach (var log in logs)
            {
                Console.WriteLine($"{log.TimeStamp} [{log.EventType}] {log.Message}");
            }
        }

        // Counts the occurrences of each event type in the logs, returning a dictionary
        public Dictionary<string, int> CountEventTypes()
        {
            return logs.GroupBy(log => log.EventType)
                       .ToDictionary(group => group.Key, group => group.Count());
        }

        // Returns the top N messages for a specific event type, ordered by their occurrence count
        public List<(string Message, int Count)> TopMessages(string eventType, int topN = 3)
        {
            return logs.Where(log => log.EventType.Equals(eventType, StringComparison.OrdinalIgnoreCase))
                       .GroupBy(log => log.Message)
                       .Select(group => (Message: group.Key, Count: group.Count()))
                       .OrderByDescending(x => x.Count)
                       .Take(topN)
                       .ToList();
        }
    }
}
