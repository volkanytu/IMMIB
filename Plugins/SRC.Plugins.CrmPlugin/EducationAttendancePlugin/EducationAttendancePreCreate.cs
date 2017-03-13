using Microsoft.Xrm.Sdk;
using SRC.Plugins.CrmPlugin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.Plugins.CrmPlugin.EducationAttendancePlugin
{
    public class EducatioAttendancePreCreate : BasePlugin, IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            base.DoWork(serviceProvider, TaskType.EDUCATION_ATTENDANCE, PluginOperation.PRE_CREATE);
        }
    }
}
