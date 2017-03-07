using SRC.Plugins.CrmPlugin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using SRC.Library.Entities;
using SRC.Library.Entities.CrmEntities;

namespace SRC.ConsoleApp.Test
{
    class Program
    {
        static void Main(string[] args)
        {

            PluginDebug pd = new PluginDebug();
            //pd.Test(TaskType.EDUCATION, PluginOperation.SET_STATE, "new_education", Guid.Parse("E7DCAAC8-39F1-E611-80D6-005056A507B1"));
            EducationAttendance attendance = new EducationAttendance();
            attendance.Education = new EntityReferenceWrapper() { Id = new Guid("A6679D4F-3E03-E711-80D6-005056A507B1"), LogicalName = "new_education" };
            attendance.Contact = new EntityReferenceWrapper() { Id = new Guid("D26CC93B-23BA-E611-80CF-005056A507B1"), LogicalName = "contact" };
            pd.TestPlugin(attendance, TaskType.EDUCATION_ATTENDANCE, PluginOperation.PRE_CREATE, "new_educationattendance");
            
        }
    }
}
