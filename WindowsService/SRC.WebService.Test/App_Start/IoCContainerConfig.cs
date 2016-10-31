using System.Configuration;
using System.Reflection;
using Autofac;
using Autofac.Extras.DynamicProxy;
using SRC.Library.LogManager.Interfaces;
using SRC.Library.Ioc.Interceptor;
using SRC.WindowsService.TestService.Interfaces;
using SRC.WindowsService.TestService.Libs;

namespace SRC.WindowsService.TestService
{
    public class IocContainerConfig
    {
        public static string APPLICATION_NAME = "TEST_SERVICE";

        public static IContainer BuildIocContainer()
        {
            var builder = new ContainerBuilder();

            #region | IOC REGISTER |
            //IocContainerBuilder.RegisterDataAccess(builder);
            //IocContainerBuilder.RegisterLogManager(builder, APPLICATION_NAME, LogEntity.LogClientType.ELASTIC);
            //IocContainerBuilder.RegisterInterceptors(builder);
            #endregion

            builder.Register<IServiceManager>(c => new ServiceManager())
                .InstancePerLifetimeScope()
                .InterceptedBy(typeof(LogInterceptor));

            var container = builder.Build();

            return container;
        }
    }
}
