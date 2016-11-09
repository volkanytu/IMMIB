using SRC.Library.Entities.CrmEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SRC.Web.Portal.Models
{
    public class ProfilePageModel
    {
        public Contact Contact { get; set; }
        public List<EducationAttendance> Attendances { get; set; }
    }
}