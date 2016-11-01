using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.Library.Entities.CrmEntities
{
    [CrmSchemaName(KEY_LOGICAL_NAME)]
    public class EducationAttendance:EntityBase
    {
        [CrmFieldDataType(CrmDataType.UNIQUEIDENTIFIER)]
        [CrmFieldName(KEY_EDUCATION_ATTENDANCE_ID)]
        public Guid Id { get; set; }

        [CrmFieldDataType(CrmDataType.STRING)]
        [CrmFieldName(KEY_NAME)]
        public string Name { get; set; }

        [CrmFieldDataType(CrmDataType.STRING)]
        [CrmFieldName(KEY_CODE)]
        public string Code { get; set; }

        [CrmFieldDataType(CrmDataType.ENTITYREFERENCE)]
        [CrmFieldName(KEY_EDUCATION_ID)]
        public EntityReferenceWrapper EducationId { get; set; }

        [CrmFieldDataType(CrmDataType.ENTITYREFERENCE)]
        [CrmFieldName(KEY_CONTACT_ID)]
        public EntityReferenceWrapper ContactId { get; set; }

        [CrmFieldDataType(CrmDataType.STRING)]
        [CrmFieldName(KEY_DENY_INFO)]
        public string DenyInfo { get; set; }

        [CrmFieldDataType(CrmDataType.BOOL)]
        [CrmFieldName(KEY_IS_ATTENDANCE_CONFIRMED)]
        public bool? IsAttendanceConfirmed { get; set; }

        [CrmFieldDataType(CrmDataType.BOOL)]
        [CrmFieldName(KEY_IS_PAYMENT_DONE)]
        public bool? IsPaymentDone { get; set; }

        [CrmFieldDataType(CrmDataType.BOOL)]
        [CrmFieldName(KEY_IS_CHARGE_BACK_DONE)]
        public bool? IsChargeBackDone { get; set; }

        [CrmFieldDataType(CrmDataType.STRING)]
        [CrmFieldName(KEY_BANK_CONFIRMATION_CODE)]
        public string BankConfirmationCode { get; set; }

        [CrmFieldDataType(CrmDataType.OPTIONSETVALUE)]
        [CrmFieldName(KEY_PAYMENT_TYPE)]
        public OptionSetValueWrapper PaymentType { get; set; }

        public const string KEY_LOGICAL_NAME = "new_educationattendance";
        public const string KEY_EDUCATION_ATTENDANCE_ID = "new_educationattendanceid";
        public const string KEY_NAME = "new_name";
        public const string KEY_CODE = "new_code";
        public const string KEY_EDUCATION_ID = "new_educationid";
        public const string KEY_CONTACT_ID = "new_contactid";
        public const string KEY_DENY_INFO = "new_denyinfo";
        public const string KEY_IS_ATTENDANCE_CONFIRMED = "new_isattendanceconfirmed";
        public const string KEY_IS_PAYMENT_DONE = "new_ispaymentdone";
        public const string KEY_IS_CHARGE_BACK_DONE = "new_ischargebackdone";
        public const string KEY_BANK_CONFIRMATION_CODE = "new_bankconfirmationcode";
        public const string KEY_PAYMENT_TYPE = "new_paymenttype";

        public enum StateCode
        {
            ACTIVE = 0,
            PASSIVE = 1
        }

        public enum StatusCode
        {
            ACTIVE = 1,
            PASSIVE = 2,
            WAITING_PAYMENT = 100000000,
            REGISTRATION_CONFIRMED = 100000001,
            REGISTRATION_CONFIRMED_STUDENT = 100000002,
            REGISTRATION_NOT_CONFIRMED = 100000003,
            JOINED = 100000004,
            DID_NOT_JOINED = 100000005,
            EVENT_CANCELED = 100000006,
            PARTICIPANT_CANCELED = 100000007
        }

        public enum PaymentTypeCode
        {
            MONEY_ORDER = 1,
            CREDIT_CARD = 2
        }
    }
}
