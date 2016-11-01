using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.Library.Entities.CrmEntities
{
    [CrmSchemaName(KEY_LOGICAL_NAME)]
    public class Association : EntityBase
    {
        [CrmFieldDataType(CrmDataType.UNIQUEIDENTIFIER)]
        [CrmFieldName(KEY_ASSOCIATION_ID)]
        public Guid Id { get; set; }

        [CrmFieldDataType(CrmDataType.STRING)]
        [CrmFieldName(KEY_NAME)]
        public string Name { get; set; }

        [CrmFieldDataType(CrmDataType.INT)]
        [CrmFieldName(KEY_CODE)]
        public int? Code { get; set; }

        public const string KEY_LOGICAL_NAME = "new_association";
        public const string KEY_ASSOCIATION_ID = "new_associationid";
        public const string KEY_NAME = "new_name";
        public const string KEY_CODE = "new_code";

        public enum StateCode
        {
            ACTIVE = 0,
            PASSIVE = 1
        }

        public enum StatusCode
        {
            ACTIVE = 1,
            PASSIVE = 2
        }
    }
}
