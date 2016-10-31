using Newtonsoft.Json;
using SRC.Library.Common;
using SRC.Library.Data.Interfaces;
using SRC.Library.Entities.CustomEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.Library.LogManager
{
    public class FileLogger : ILog
    {
        private string _fileLogPath;

        public FileLogger(string fileLogPath)
        {
            _fileLogPath = fileLogPath;
        }

        public void Log(LogEntity logEntity)
        {
            logEntity.CreatedOn = DateTime.Now;

            string jsonData = JsonConvert.SerializeObject(logEntity);

            string logDirectoryToday = string.Format(@"{0}\{1}", _fileLogPath, DateTime.Now.ToString("yyyy.MM.dd"));
            string logFilePathApplication = string.Format(@"{0}\{1}{2}", logDirectoryToday, logEntity.ApplicationName, Globals.LogExt);
        }
    }
}
