using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SRC.Web.NewPortal.Models
{
    public class SaveEditorTestRequest
    {
        public string id { get; set; }
        public string typeName { get; set; }
        public int typeCode { get; set; }
        public string fieldName { get; set; }
        public string fieldValue { get; set; }
    }
}