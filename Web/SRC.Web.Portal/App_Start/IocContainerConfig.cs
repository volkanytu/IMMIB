using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Extras.DynamicProxy;
using System.Web;
using System.Web.Mvc;
using SRC.Library.Ioc.IocManager;

namespace SRC.Web.Portal
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

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterModule<AutofacWebTypesModule>();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
