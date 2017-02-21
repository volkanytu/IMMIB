using Microsoft.Xrm.Sdk;
using SRC.Plugins.CrmPlugin.Entities;
using System;
namespace SRC.Plugins.CrmPlugin.Interfaces
{
    public interface IBasePluginTask
    {
        void Process(IPluginExecutionContext context, PluginOperation pluginOperation);
    }
}
