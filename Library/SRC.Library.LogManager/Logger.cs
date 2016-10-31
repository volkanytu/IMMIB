using SRC.Library.Data.Interfaces;
using SRC.Library.Entities.CustomEntities;
using SRC.Library.LogManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SRC.Library.LogManager
{
    public class Logger : ILogManager
    {
        private ILog _logDao;

        public Logger(ILog logDao)
        {
            _logDao = logDao;
        }

        public void Log(LogEntity logEntity)
        {
            _logDao.Log(logEntity);
        }

        public void Log(string applicationName, string functionName, string logKey, string detail, LogEntity.EventType eventType)
        {
            LogEntity logEntity = new LogEntity()
                                        {
                                            ApplicationName = applicationName,
                                            FunctionName = functionName,
                                            LogKey = logKey,
                                            CreatedOn = DateTime.Now,
                                            Detail = detail,
                                            LogEventType = eventType
                                        };

            Log(logEntity);
        }
    }
}
