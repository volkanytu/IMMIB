using SRC.Library.Entities.CrmEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SRC.Web.Portal.Models
{
    public class EducationModel
    {
        public List<Education> EducationList { get; set; }
        public List<EducationAttendance> AttendanceList { get; set; }
    }
}