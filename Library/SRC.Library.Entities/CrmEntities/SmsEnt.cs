using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.Library.Entities.CrmEntities
{
    [CrmSchemaName(KEY_LOGICAL_NAME)]
    public class SmsEnt : EntityBase
    {
        [CrmFieldDataType(CrmDataType.UNIQUEIDENTIFIER)]
        [CrmFieldName(KEY_SMS_ID)]
        public Guid Id { get; set; }

        [CrmFieldDataType(CrmDataType.STRING)]
        [CrmFieldName(KEY_NAME)]
        public string Name { get; set; }

        public string PhoneNumber { get; set; }
        public EntityReferenceWrapper Contact { get; set; }
        public string Message { get; set; }

        public const string REMEMBER_PASSWORD_TEXT = "SN. {0}, IMMIB Eğitim Portalı şifreniz: {1} olarak değiştirilmiştir. Teşekkürler...";

        public const string KEY_LOGICAL_NAME = "new_sms";
        public const string KEY_SMS_ID = "new_smsid ";
        public const string KEY_NAME= "new_name";
    }
}
