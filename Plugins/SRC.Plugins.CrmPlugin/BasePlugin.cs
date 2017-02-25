using Autofac;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using SRC.Library.Data.SqlDao.Interfaces;
using SRC.Library.Entities.CrmEntities;
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

        public string DoWorkTest(TaskType taskType, PluginOperation pluginOperation, Guid? userId = null, string entityName = null, Guid? entityId = null)
        {
            IPluginExecutionContext context = new RemoteExecutionContext();

            IContainer container = IocContainerConfig.Container;

            IMsCrmAccess msCrmAccess = container.Resolve<IMsCrmAccess>();
            IOrganizationService service = msCrmAccess.GetCrmService();

            IBasePluginTask pluginTask = container.ResolveKeyed<IBasePluginTask>(taskType);

            Entity entity = service.Retrieve(entityName, entityId.Value, new ColumnSet(true));

            //entity["entitymoniker"] = entity.ToEntityReference();
            //entity["statecode"] = new OptionSetValue((int)Education.StateCode.PASSIVE);
            //entity["statuscode"] = new OptionSetValue((int)Education.StatusCode.CANCELED);

            //Entity preImage = service.Retrieve(entityName, entityId.Value, new ColumnSet(true));
            //Entity postImage = service.Retrieve(entityName, entityId.Value, new ColumnSet(true));
            //postImage["statecode"] = new OptionSetValue((int)SAHIBINDEN.Library.Entities.CrmEntities.Appointment.StateCode.CANCELED);
            //postImage["statuscode"] = new OptionSetValue((int)SAHIBINDEN.Library.Entities.CrmEntities.Appointment.StatusCode.CANCELLED);

            //context.InputParameters.Add("Target", entity);
            context.InputParameters.Add("EntityMoniker", entity.ToEntityReference());
            context.InputParameters.Add("State", new OptionSetValue((int)Education.StateCode.PASSIVE));
            context.InputParameters.Add("Status", new OptionSetValue((int)Education.StatusCode.CANCELED));

            //context.PreEntityImages.Add("PreImage", preImage);
            //context.PostEntityImages.Add("PostImage", postImage);

            pluginTask.Process(context, pluginOperation);

            return msCrmAccess.ServiceID.ToString();
        }

        public string DoWorkTest(TaskType taskType, PluginOperation pluginOperation, Entity entity, Guid? userId = null, string entityName = null)
        {
            IPluginExecutionContext context = new RemoteExecutionContext();

            IContainer container = IocContainerConfig.Container;

            IMsCrmAccess msCrmAccess = container.Resolve<IMsCrmAccess>();
            IOrganizationService service = msCrmAccess.GetCrmService();

            IBasePluginTask pluginTask = container.ResolveKeyed<IBasePluginTask>(taskType);

            //Entity preImage = service.Retrieve(entityName, entityId.Value, new ColumnSet(true));
            //Entity postImage = service.Retrieve(entityName, entityId.Value, new ColumnSet(true));

            context.InputParameters.Add("Target", entity);
            //context.PreEntityImages.Add("PreImage", preImage);
            //context.PostEntityImages.Add("PostImage", postImage);

            pluginTask.Process(context, pluginOperation);

            return msCrmAccess.ServiceID.ToString();
        }
    }
}
