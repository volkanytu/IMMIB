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

        [CrmFieldDataType(CrmDataType.STRING)]
        [CrmFieldName(KEY_PHONE_NUMBER)]
        public string PhoneNumber { get; set; }

        [CrmFieldDataType(CrmDataType.ENTITYREFERENCE)]
        [CrmFieldName(KEY_CONTACT_ID)]
        public EntityReferenceWrapper Contact { get; set; }

        [CrmFieldDataType(CrmDataType.STRING)]
        [CrmFieldName(KEY_MESSAGE)]
        public string Message { get; set; }

        [CrmFieldDataType(CrmDataType.STRING)]
        [CrmFieldName(KEY_MESSAGE_STATE)]
        public string MessageState { get; set; }

        [CrmFieldDataType(CrmDataType.STRING)]
        [CrmFieldName(KEY_MESSAGE_STATUS)]
        public string MessageStatus { get; set; }

        public const string REMEMBER_PASSWORD_TEXT = "SN. {0}, IMMIB Eğitim Portalı şifreniz: {1} olarak değiştirilmiştir. Teşekkürler...";

        public const string KEY_LOGICAL_NAME = "new_sms";
        public const string KEY_SMS_ID = "new_smsid ";
        public const string KEY_NAME= "new_name";
        public const string KEY_PHONE_NUMBER = "new_phonenumber";
        public const string KEY_CONTACT_ID = "new_contactid";
        public const string KEY_MESSAGE = "new_message";
        public const string KEY_MESSAGE_STATE = "new_messagestate";
        public const string KEY_MESSAGE_STATUS = "new_messagestatustext";

        public enum StateCode
        {
            ACTIVE = 0,
            PASSIVE = 1
        }

        public enum StatusCode
        {
            ACTIVE = 1,
            WAITING_SEND = 100000000,
            SENT = 100000001,
            CANT_SEND = 100000002,
            PASSIVE = 2
        }
    }
}
