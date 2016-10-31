using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.Library.Entities.CrmEntities
{
    [CrmSchemaName(KEY_LOGICAL_NAME)]
    public class Contact : EntityBase
    {
        [CrmFieldDataType(CrmDataType.UNIQUEIDENTIFIER)]
        [CrmFieldName(KEY_CONTACT_ID)]
        public Guid Id { get; set; }

        [CrmFieldDataType(CrmDataType.STRING)]
        [CrmFieldName(KEY_FULLNAME)]
        public string Name { get; set; }

        public const string KEY_LOGICAL_NAME = "contact";
        public const string KEY_CONTACT_ID = "contactid";
        public const string KEY_FULLNAME = "fullname";
    }
}
