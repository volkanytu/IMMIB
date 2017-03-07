using SRC.Plugins.CrmPlugin;
using SRC.Plugins.CrmPlugin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRC.Library.Data.SqlDao;
using Microsoft.Xrm.Sdk;

namespace SRC.ConsoleApp.Test
{
    public class PluginDebug : BasePlugin
    {
        public void Test(TaskType taskType, PluginOperation pluginOperation, string entityName, Guid entityId)
        {
            base.DoWorkTest(taskType, pluginOperation, null, entityName, entityId);
        }

        public void TestPlugin<T>(T objectValue, TaskType taskType, PluginOperation pluginOperation, string entityName) where T : class
        {
            Entity ent = objectValue.ToCrmEntity();

            base.DoWorkTest(taskType, pluginOperation,ent, null, entityName);
        }
    }
}
