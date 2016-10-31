using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.Library.Entities.CrmEntities
{
    [CrmSchemaName(KEY_LOGICAL_NAME)]
    public class InformedBy : EntityBase
    {
        [CrmFieldDataType(CrmDataType.UNIQUEIDENTIFIER)]
        [CrmFieldName(KEY_INFORMEDBY_ID)]
        public Guid Id { get; set; }

        [CrmFieldDataType(CrmDataType.STRING)]
        [CrmFieldName(KEY_NAME)]
        public string Name { get; set; }

        [CrmFieldDataType(CrmDataType.INT)]
        [CrmFieldName(KEY_CODE)]
        public int? Code { get; set; }

        public const string KEY_LOGICAL_NAME = "new_informedby";
        public const string KEY_INFORMEDBY_ID = "new_informedbyid";
        public const string KEY_NAME = "new_name";
        public const string KEY_CODE = "new_code";
    }
}
