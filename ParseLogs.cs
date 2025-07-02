using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace FileParser
{
    public class ParseLogs
    {
        // Reads a log file and parses each line into a Log object.
        public static List<Log> ParseLogFile(string filePath)
        {
            var logs = new List<Log>();

            try
            {

                string[] lines = File.ReadAllLines(filePath);

                if (lines.Length == 0)
                {
                    Console.WriteLine("Log file is empty.");
                    return logs;
                }

                foreach (string line in lines)
                {

                    if (string.IsNullOrWhiteSpace(line))
                    {
                        continue; // Skip empty lines
                    }

                    var log = ParseLogLine(line);

                    // Only add valid logs to the list
                    if (log != null)
                    {
                        logs.Add(log);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading log file: {ex.Message}");
                return logs;
            }

            return logs;
        }

        // Parses a single log line into a Log object.
        private static Log ParseLogLine(string line)
        {

            try
            {
                // Expected format: [2023-10-01 12:00:00] EventType Message
                var parts = line.Split(new[] { ' ' }, 4);
                if (parts.Length < 4)
                {
                    throw new FormatException("Log line does not contain enough parts.");
                }

                // Create the timestamp from the first two parts
                string timeStampPart = $"{parts[0].TrimStart('[')} {parts[1].TrimEnd(']')}";
                DateTime timeStamp = DateTime.ParseExact(timeStampPart, "yyyy-MM-dd HH:mm:ss", null);

                string eventType = parts[2];
                string message = parts[3];

                return new Log(timeStamp, eventType, message);
            }
            catch (Exception ex)
            {
                // Skips invalid log lines and logs the error
                Console.WriteLine($"Error parsing log line: {ex.Message}");
                return null;
            }
        }
    }
}
