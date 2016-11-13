using SRC.Library.Entities.CrmEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SRC.Web.Portal.Models
{
    public class EducationQueryModel
    {
        public int? Month { get; set; }
        public int? Year { get; set; }
        public List<Education> EducationList { get; set; }
    }
}