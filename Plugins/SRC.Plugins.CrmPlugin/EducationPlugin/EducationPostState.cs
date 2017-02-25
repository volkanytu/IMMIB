using Microsoft.Xrm.Sdk;
using SRC.Plugins.CrmPlugin.Entities;
using System;

namespace SRC.Plugins.CrmPlugin.EducationPlugin
{
    public class EducationPostState : BasePlugin, IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            base.DoWork(serviceProvider, TaskType.EDUCATION, PluginOperation.SET_STATE);
        }
    }
}
