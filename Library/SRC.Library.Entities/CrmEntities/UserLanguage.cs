using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.Library.Entities.CrmEntities
{
    [CrmSchemaName(KEY_LOGICAL_NAME)]
    public class UserLanguage : EntityBase
    {
        [CrmFieldDataType(CrmDataType.UNIQUEIDENTIFIER)]
        [CrmFieldName(KEY_LOGIN_ID)]
        public Guid Id { get; set; }

        [CrmFieldDataType(CrmDataType.STRING)]
        [CrmFieldName(KEY_NAME)]
        public string Name { get; set; }

        [CrmFieldDataType(CrmDataType.ENTITYREFERENCE)]
        [CrmFieldName(KEY_CONTACT_ID)]
        public EntityReferenceWrapper Contact { get; set; }

        [CrmFieldDataType(CrmDataType.ENTITYREFERENCE)]
        [CrmFieldName(KEY_LANGUAGE_ID)]
        public EntityReferenceWrapper Language { get; set; }

        [CrmFieldDataType(CrmDataType.OPTIONSETVALUE)]
        [CrmFieldName(KEY_LEVEL)]
        public OptionSetValueWrapper Level { get; set; }

        public const string KEY_LOGICAL_NAME = "new_login";
        public const string KEY_LOGIN_ID = "new_loginid";
        public const string KEY_NAME = "new_name";
        public const string KEY_CONTACT_ID = "new_contactid";
        public const string KEY_LANGUAGE_ID = "new_languageid";
        public const string KEY_LEVEL = "new_level";

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

        public enum LevelCode
        {
            BEGINNING = 1,
            STARTER = 2,
            INTERMEDIATE = 3,
            UPPER_INTERMEDIATE = 4,
            ADVANCED = 5

        }
    }
}
