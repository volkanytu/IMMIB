using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SRC.Library.Entities.CustomEntities
{
    public class LogEntity
    {
        public string ContextIdentifier { get; set; }
        public string ApplicationName { get; set; }
        public string FunctionName { get; set; }
        public string LogKey { get; set; }
        public string Detail { get; set; }
        public string CallerMethod { get; set; }
        public string StackTrace { get; set; }
        public string ExceptionFullPath { get; set; }
        public DateTime? CreatedOn { get; set; }
        public EventType? LogEventType { get; set; }
        public List<LogItem> ItemList { get; set; }

        public enum EventType
        {
            Info = 100000000,
            Warning,
            Exception
        }

        public enum LogClientType
        {
            SQL,
            ELASTIC,
            FILE
        }
    }
}
