using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.Library.Entities.CrmEntities
{
    [CrmSchemaName(KEY_LOGICAL_NAME)]
    public class LoginLog : EntityBase
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

        [CrmFieldDataType(CrmDataType.DATETIME)]
        [CrmFieldName(KEY_LOGIN_DATE)]
        public DateTime? LoginDate { get; set; }

        [CrmFieldDataType(CrmDataType.STRING)]
        [CrmFieldName(KEY_IP_ADDRESS)]
        public string IpAddress { get; set; }

        [CrmFieldDataType(CrmDataType.INT)]
        [CrmFieldName(KEY_LOGIN_COUNT)]
        public int? LoginCount { get; set; }

        public const string KEY_LOGICAL_NAME = "new_login";
        public const string KEY_LOGIN_ID = "new_loginid";
        public const string KEY_NAME = "new_name";  
        public const string KEY_CONTACT_ID = "new_contactid";
        public const string KEY_LOGIN_DATE = "new_logindate";
        public const string KEY_IP_ADDRESS = "new_ipaddress";
        public const string KEY_LOGIN_COUNT = "new_logincount";

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
