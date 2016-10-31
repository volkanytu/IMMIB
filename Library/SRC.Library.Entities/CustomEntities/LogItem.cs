using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SRC.Library.Entities.CustomEntities
{
    public class LogItem
    {
        public LogItem(string logKey)
        {
            LogKey = logKey;
        }

        public string LogKey { get; private set; }
        public string ErrorMessage { get; set; }      
        public string RecordId { get; set; }
    }
}
