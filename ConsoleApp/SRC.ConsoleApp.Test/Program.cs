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
            SRC.Library.Services.Members.ImmibMembers service = new Library.Services.Members.ImmibMembers();
            service.GetMembers();

            //PluginDebug pd = new PluginDebug();
            ////pd.Test(TaskType.EDUCATION_ATTENDANCE, PluginOperation.POST_UPDATE, "new_educationattendance", Guid.Parse("AB8A9CAA-FD07-E711-80D6-005056A507B1"));
            ////EducationAttendance attendance = new EducationAttendance();
            ////attendance.Id = new Guid("AB8A9CAA-FD07-E711-80D6-005056A507B1");
            ////attendance.Education = new EntityReferenceWrapper() { Id = new Guid("9D675227-3D03-E711-80D6-005056A507B1"), LogicalName = "new_education" };
            ////attendance.Contact = new EntityReferenceWrapper() { Id = new Guid("D26CC93B-23BA-E611-80CF-005056A507B1"), LogicalName = "contact" };
            //////Education education = new Education();
            //CreditCardLog cd = new CreditCardLog();
            //cd.EducationAttendance = new EntityReferenceWrapper() { Id = new Guid("AB8A9CAA-FD07-E711-80D6-005056A507B1"), LogicalName = "new_educationattendance" };
            //cd.ResultCode = "00";
            //pd.TestPlugin(cd, TaskType.CREDIT_CARD_LOG, PluginOperation.POST_CREATE, "new_creditcardlog");

        }
    }
}
