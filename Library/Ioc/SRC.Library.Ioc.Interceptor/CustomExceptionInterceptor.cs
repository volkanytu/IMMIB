using Castle.DynamicProxy;
using SRC.Library.Entities.CustomEntities;
using System;
using System.Diagnostics;

namespace SRC.Library.Ioc.Interceptor
{
    public class CustomExceptionInterceptor : IInterceptor
    {
        public CustomExceptionInterceptor()
        {

        }

        public void Intercept(IInvocation invocation)
        {
            Stopwatch sWatch = new Stopwatch();
            sWatch.Start();

            try
            {
                invocation.Proceed();
            }
            catch (CustomException ex)
            {
                string functionName = string.Format("{0}_{1}", invocation.TargetType.Name, invocation.Method.Name);
                ex.AddToExceptionFullPath(functionName);

                throw ex;
            }
            catch (Exception ex)
            {
                string functionName = string.Format("{0}_{1}", invocation.TargetType.Name, invocation.Method.Name);
                string logKey = ex.GetType().Name;

                LogItem validationItem = new LogItem(logKey);
                validationItem.ErrorMessage = ex.Message;

                CustomException ce = new CustomException(validationItem, ex.StackTrace);
                ce.AddToExceptionFullPath(functionName);

                throw ce;
            }

            sWatch.Stop();
        }
    }
}
