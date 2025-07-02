using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace FileParser
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to the Log File Parser!");

            //Prompts the user to select default or use custom log file path
            string filePath = GetFilePath();

            //Parses the log file and returns a list of log objects
            var logEntries = ParseLogs.ParseLogFile(filePath);

            if (logEntries.Count > 0)
            {
                var logAnalysis = new LogAnalysis(logEntries);

                // Runs the menu for log analysis options 
                RunMenu(logAnalysis);

            }
            else
            {
                Console.WriteLine("\nNo valid log entries found.");
                return;
            }
        }

        // Loops until the user selects a valid option for log file path
        private static string GetFilePath()
        {
            const string defaultPath = ".\\Logs\\sample_log.txt";

            while (true)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Use default log file");
                Console.WriteLine("2. Enter custom log file path");

                var choice = Console.ReadLine();

                if (choice == "1")
                {
                    if (File.Exists(defaultPath))
                    {
                        return defaultPath;
                    }
                    Console.WriteLine($"Default file not found at: {defaultPath}");
                }
                else if (choice == "2")
                {
                    Console.WriteLine("Enter full path to your log file:");
                    var customPath = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(customPath) && File.Exists(customPath))
                    {
                        return customPath;
                    }

                    Console.WriteLine("Invalid path or file does not exist.");
                }
                else
                {
                    Console.WriteLine("Invalid option. Please select 1 or 2.");
                }
            }
        }

        //Displays a menu for the user to select log analysis options
        private static void RunMenu(LogAnalysis logAnalysis)
        {
            while (true)
            {
                Console.WriteLine("\nSelect an option:");
                Console.WriteLine("1. Display all log entries");
                Console.WriteLine("2. Display event type counts");
                Console.WriteLine("3. Display top messages for an event type");
                Console.WriteLine("4. Exit");

                var input = Console.ReadLine();

                if (input == "1")
                {
                    logAnalysis.PrintLogs();

                }
                else if (input == "2")
                {

                    var eventCounts = logAnalysis.CountEventTypes();
                    Console.WriteLine("\nEvent Type Counts:");
                    foreach (var kvp in eventCounts)
                    {
                        Console.WriteLine($"{kvp.Key}: {kvp.Value}");
                    }

                }
                else if (input == "3")
                {

                    Console.WriteLine("\nEnter the event type (e.g., 'error', 'info', 'warning') to get top messages:");
                    var eventType = Console.ReadLine()?.Trim().ToUpper();

                    if (string.IsNullOrWhiteSpace(eventType))
                    {
                        Console.WriteLine("Event type cannot be empty. Please try again.");
                        continue;
                    }

                    var topMessages = logAnalysis.TopMessages(eventType);

                    if (topMessages.Count == 0)
                    {
                        Console.WriteLine($"\nNo messages found for event type '{eventType}'.");
                        continue;
                    }
                    else
                    {

                        Console.WriteLine($"\nTop {eventType} Messages:");
                        foreach (var message in topMessages)
                        {
                            Console.WriteLine($"{message.Message} - Count: {message.Count}");
                        }
                    }


                }
                else if (input == "4")
                {

                    Console.WriteLine("\nExiting the program. Goodbye!");
                    return;
                }
                else
                {
                    Console.WriteLine("\nInvalid option. Please try again.");
                }
            }
        }
    }
}