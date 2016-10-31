using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SRC.Library.Entities.CustomEntities
{
    public class CustomException : Exception
    {
        public CustomException(string message, string logKey)
            : base(message)
        {
            LogKey = logKey;
        }

        public CustomException(string message, string logKey, string contextIdentifier)
            : base(message)
        {
            LogKey = logKey;
            ContextIdentifier = contextIdentifier;
        }

        public CustomException(List<LogItem> logItemList, string logKey)
            : base(logKey)
        {
            LogKey = logKey;
            LogItemList = logItemList;
        }

        public CustomException(LogItem validationItem)
            : base(validationItem.LogKey)
        {
            LogKey = validationItem.LogKey;
            LogItemList = new List<LogItem>() { validationItem };
        }

        public CustomException(LogItem validationItem, string innerStackTrace)
            : base(validationItem.LogKey)
        {
            LogKey = validationItem.LogKey;
            LogItemList = new List<LogItem>() { validationItem };
            InnerStackTrace = innerStackTrace;
        }

        public void AddToExceptionFullPath(string exceptionPath)
        {
            ExceptionFullPath = (string.IsNullOrWhiteSpace(ExceptionFullPath) ? string.Empty : ExceptionFullPath);
            exceptionPath = (string.IsNullOrWhiteSpace(exceptionPath) ? string.Empty : exceptionPath);

            ExceptionFullPath = string.Join("|", ExceptionFullPath.Trim(), exceptionPath.Trim());
        }

        public string LogKey { get; private set; }
        public string ContextIdentifier { get; set; }
        public string InnerStackTrace { get; private set; }
        public string ExceptionFullPath { get; private set; }
        public List<LogItem> LogItemList { get; private set; }
    }
}
