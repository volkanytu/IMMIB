using System.Configuration;
using System.Reflection;
using Autofac;
using Autofac.Extras.DynamicProxy;
using SRC.ConsoleApp.ScheduledJobs.Interfaces;
using SAHIBINDEN.ConsoleApp.ScheduledJobs.Jobs;
using SRC.ConsoleApp.ScheduledJobs.Jobs;
using SRC.Library.LogManager.Interfaces;
using SRC.Library.Ioc.Interceptor;

namespace SRC.ConsoleApp.ScheduledJobs
{
    public class IocContainerConfig
    {
        public static string APPLICATION_NAME = "SCHEDULED_JOBS";

        public static IContainer BuildIocContainer()
        {
            var builder = new ContainerBuilder();

            #region | IOC REGISTER |
            //IocContainerBuilder.RegisterDataAccess(builder);
            //IocContainerBuilder.RegisterLogManager(builder, APPLICATION_NAME, LogEntity.LogClientType.ELASTIC);
            //IocContainerBuilder.RegisterInterceptors(builder);
            #endregion

            builder.Register<BaseJob>(c => new TestJob(c.Resolve<ILogManager>()))
                .Keyed<BaseJob>(JobType.TestJob.ToString())
                .InstancePerLifetimeScope()
                .InterceptedBy(typeof(LogInterceptor));

            var container = builder.Build();

            return container;
        }
    }
}
