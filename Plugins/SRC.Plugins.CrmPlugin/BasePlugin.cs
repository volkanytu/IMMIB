using Autofac;
using Microsoft.Xrm.Sdk;
using SRC.Library.Data.SqlDao.Interfaces;
using SRC.Plugins.CrmPlugin.Entities;
using SRC.Plugins.CrmPlugin.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.Plugins.CrmPlugin
{
    public abstract class BasePlugin
    {
        public BasePlugin()
        {

        }

        public string DoWork(IServiceProvider serviceProvider, TaskType taskType, PluginOperation pluginOperation, Guid? userId = null)
        {
            IPluginExecutionContext context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
            IOrganizationServiceFactory serviceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            IOrganizationService service = serviceFactory.CreateOrganizationService(userId ?? context.UserId);

            IContainer container = IocContainerConfig.Container;
            IMsCrmAccess msCrmAccess;

            using (var scope = container.BeginLifetimeScope())
            {
                msCrmAccess = scope.Resolve<IMsCrmAccess>();
                msCrmAccess.CrmService = service;

                IBasePluginTask pluginTask = scope.ResolveKeyed<IBasePluginTask>(taskType);

                pluginTask.Process(context, pluginOperation);
            }

            return msCrmAccess.ServiceID.ToString();
        }
    }
}
