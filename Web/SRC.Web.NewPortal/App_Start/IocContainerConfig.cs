using Autofac;
using Autofac.Integration.WebApi;
using Autofac.Extras.DynamicProxy;
using System.Web;
using System.Web.Mvc;
using SRC.Library.Ioc.IocManager;
using System.Web.Http;
using System.Reflection;

namespace SRC.Web.NewPortal
{
    public class IocContainerConfig
    {
        private static string APPLICATION_NAME = "WEB_PORTAL";

        public static void BuildIocContainer()
        {
            var builder = new ContainerBuilder();

            #region | IOC REGISTER |
            IocContainerBuilder.RegisterDataAccess(builder);
            IocContainerBuilder.RegisterPortal(builder);
            //IocContainerBuilder.RegisterLogManager(builder, APPLICATION_NAME, LogEntity.LogClientType.ELASTIC);
            //IocContainerBuilder.RegisterInterceptors(builder);
            #endregion

            var config = GlobalConfiguration.Configuration;
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(config);
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
