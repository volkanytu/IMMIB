using Autofac;
using SRC.Library.Business.Interfaces;
using SRC.Library.Domain.Business.Interfaces;
using SRC.Library.Entities.CrmEntities;
using SRC.Library.Ioc.IocManager;
using SRC.Plugins.CrmPlugin.Entities;
using SRC.Plugins.CrmPlugin.Interfaces;
using SRC.Plugins.CrmPlugin.PluginTasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.Plugins.CrmPlugin
{
    public class IocContainerConfig
    {
        private static readonly Lazy<IocContainerConfig> lazy = new Lazy<IocContainerConfig>(() => new IocContainerConfig());
        private static readonly Lazy<IContainer> DependencyResolverTrunk = new Lazy<IContainer>(GetContainer);

        public static IocContainerConfig Instance { get { return lazy.Value; } }
        public static IContainer Container { get { return DependencyResolverTrunk.Value; } }

        private IocContainerConfig()
        {

        }

        private static IContainer GetContainer()
        {
            var builder = IocContainerBuilder.RegisterDataAccess(new ContainerBuilder()); 
            IocContainerBuilder.RegisterPlugin(builder);

            builder.Register<IBasePluginTask>(c => new EducationTask(c.Resolve<IEducationBusiness>(), c.Resolve<IEducationAttendanceBusiness>(), c.Resolve<IBaseBusiness<EducationAttendance>>()))
                .Keyed<IBasePluginTask>(TaskType.EDUCATION)
                .InstancePerDependency();

            return builder.Build();
        }
    }
}
