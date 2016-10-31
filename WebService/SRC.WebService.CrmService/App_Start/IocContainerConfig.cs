using Autofac;
using Autofac.Extras.DynamicProxy;
using Autofac.Integration.WebApi;
using System.Configuration;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using SRC.Library.Ioc.IocManager;
using SRC.Library.Entities.CustomEntities;

namespace SRC.WebService.CrmService
{
    public class IocContainerConfig
    {
        public static string APPLICATION_NAME = "CrmService";

        public static void BuildIocContainer()
        {
            var builder = new ContainerBuilder();

            #region | IOC REGISTER |
            //IocContainerBuilder.RegisterDataAccess(builder);
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
