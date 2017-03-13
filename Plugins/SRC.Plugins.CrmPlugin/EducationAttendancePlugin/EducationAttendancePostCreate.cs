using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using SRC.Plugins.CrmPlugin.Entities;

namespace SRC.Plugins.CrmPlugin.EducationAttendancePlugin
{
    public class EducatioAttendancePostCreate : BasePlugin, IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            base.DoWork(serviceProvider, TaskType.EDUCATION_ATTENDANCE, PluginOperation.POST_CREATE);
        }
    }
}
