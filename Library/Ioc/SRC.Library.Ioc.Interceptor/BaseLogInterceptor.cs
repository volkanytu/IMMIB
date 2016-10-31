using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SRC.Library.LogManager.Interfaces;
using SRC.Library.Entities.CustomEntities;
using SRC.Library.Common;

namespace SRC.Library.Ioc.Interceptor
{
    public class BaseLogInterceptor
    {
        private ILogManager _logManager;
        private const string APPLICATION_NAME = "BaseLogInterceptor";

        public BaseLogInterceptor(ILogManager logManager)
        {
            _logManager = logManager;
        }

        protected void Log(IInvocation invocation, Exception ex, string identifier = null)
        {
            try
            {
                string logKey = ex.GetType().Name;
                List<LogItem> logItemList = null;

                if (ex is CustomException)
                {
                    logKey = ((CustomException)ex).LogKey;
                    logItemList = ((CustomException)ex).LogItemList;
                }

                LogEntity log = new LogEntity();
                log.FunctionName = string.Format("{0}_{1}", invocation.TargetType.Name, invocation.Method.Name);
                log.Detail = ex.Message;
                log.StackTrace = ex is CustomException ? ((CustomException)ex).InnerStackTrace : ex.StackTrace;
                log.ExceptionFullPath = ex is CustomException ? ((CustomException)ex).ExceptionFullPath : string.Empty;
                log.CallerMethod = Utils.GetCallerMethod();
                log.CreatedOn = DateTime.Now;
                log.LogKey = logKey;
                log.LogEventType = LogEntity.EventType.Exception;
                log.ContextIdentifier = identifier;
                log.ItemList = logItemList;

                _logManager.Log(log);
            }
            catch (Exception exception)
            {
                string errorFileLogPath = string.Format(@"{0}\{1}{2}", Globals.FileLogPath, APPLICATION_NAME, Globals.LogExt);

                FileLog.WriteToFile(string.Format("{0};{1};{2}", invocation.Method.Name, exception.Message, exception.StackTrace), @errorFileLogPath);
            }
        }
    }
}
