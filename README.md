# File Parser - Log Analysis

## Overview

This C# console application reads and parses log entries containing timestamps, event types, and messages. The program can print all logs, count occurrences of each event type, and identify the top 3 most frequent messages associated with a specific event type.

This project utilizes strong Object-Oriented Programming principles through clear separation of concerns between log parsing, data representation, and log analysis.

## Approach

- Separation of concerns:
  - The Log class models a single log entry and contains properties for the timestamp, event type, and message.
  - The ParseLogs class handles file reading and parses through log lines, creating and storing valid logs in a list.
  - The LogAnalysis class encapsulates analysis functionality like printing logs, counting event types, and finding frequent message phrases.
  - The Program class handles user interaction and application flow through a menu driven interface.
 
- User Experience:
  - The user can either use the provided sample log file or input a path to a custom file.
  - An interactive menu allows the user to choose to view logs, view event type counts, and the top 3 messages for a selected event type.

 - Design Choices:
    - Given the sample file size and for simplicity the program reads the entire file into memory.
    - The program skips invalid log lines to maintain a simple and reliable execution flow.

## Assumptions

- The log file will always strictly follow the format [YYYY-MM-DD HH:MM:ss] EVENT_TYPE Message.
- Each component of a log line (timestamp, event type, message) is separated by a single space.
- The event type contains no spaces and are treated case-insensitively.
- The message may contain spaces and any characters.
- The user provides valid input when interacting with the menu.
- The log file is not modified while the program is running.
- The top 3 messages feature retrieves the 3 most frequently occurring exact message strings for a specified event type.

## Known Limitations

- The entire log file is read into memory (could cause issues for larger files).
- The program can only process one log file per execution.
- Empty/incorrectly formatted log lines will be ignored and an error message will be printed to the console.
- The top 3 messages feature only counts exact matches rather than messages that are very similar to each other.
- The program assumes that the timestamps are valid and will always match the assumed format and will skip invalid lines instead of handling special cases.
- Limited error handling outside of basic file and input validation. 

  

