using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParser
{
    //simple Log class to represent a log entry
    public class Log
    {
        public DateTime TimeStamp { get; }

        public string EventType { get; }

        public string Message { get; }

        public Log(DateTime timeStamp, string eventType, string message)
        {
            TimeStamp = timeStamp;
            EventType = eventType;
            Message = message;
        }
    }
}
