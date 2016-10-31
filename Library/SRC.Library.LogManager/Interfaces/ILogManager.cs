using SRC.Library.Entities.CustomEntities;
using System;

namespace SRC.Library.LogManager.Interfaces
{
    public interface ILogManager
    {
        void Log(LogEntity logEntity);
        void Log(string applicationName, string functionName, string logKey, string detail, LogEntity.EventType eventType);
    }
}
