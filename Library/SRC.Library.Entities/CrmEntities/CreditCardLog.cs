using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.Library.Entities.CrmEntities
{
    [CrmSchemaName(KEY_LOGICAL_NAME)]
    public class CreditCardLog : EntityBase
    {
        [CrmFieldDataType(CrmDataType.UNIQUEIDENTIFIER)]
        [CrmFieldName(KEY_CREDIT_CARD_LOG_ID)]
        public Guid Id { get; set; }

        [CrmFieldDataType(CrmDataType.ENTITYREFERENCE)]
        [CrmFieldName(KEY_EDUCATION_ATTENDANCE_ID)]
        public EntityReferenceWrapper EducationAttendance { get; set; }

        [CrmFieldDataType(CrmDataType.STRING)]
        [CrmFieldName(KEY_NAME)]
        public string Name { get; set; }

        [CrmFieldDataType(CrmDataType.STRING)]
        [CrmFieldName(KEY_CVC)]
        public string Cvc { get; set; }

        [CrmFieldDataType(CrmDataType.INT)]
        [CrmFieldName(KEY_EXPIRE_MONTH)]
        public int? ExpireMonth { get; set; }

        [CrmFieldDataType(CrmDataType.INT)]
        [CrmFieldName(KEY_EXPIRE_YEAR)]
        public int? ExpireYear { get; set; }

        [CrmFieldDataType(CrmDataType.DECIMAL)]
        [CrmFieldName(KEY_AMOUNT)]
        public decimal? Amount { get; set; }

        [CrmFieldDataType(CrmDataType.OPTIONSETVALUE)]
        [CrmFieldName(KEY_INSTALLMENT_TYPE)]
        public OptionSetValueWrapper InstallmentType { get; set; }

        [CrmFieldDataType(CrmDataType.STRING)]
        [CrmFieldName(KEY_RESULT_CODE)]
        public string ResultCode { get; set; }

        [CrmFieldDataType(CrmDataType.STRING)]
        [CrmFieldName(KEY_RESULT)]
        public string Result { get; set; }

        public const string KEY_LOGICAL_NAME = "new_creditcardlog";
        public const string KEY_CREDIT_CARD_LOG_ID = "new_creditcardlogid";
        public const string KEY_EDUCATION_ATTENDANCE_ID = "new_educationattendanceid";
        public const string KEY_NAME = "new_name";
        public const string KEY_CVC = "new_cvc";
        public const string KEY_EXPIRE_MONTH = "new_expiremonth";
        public const string KEY_EXPIRE_YEAR = "new_expireyear";
        public const string KEY_AMOUNT = "new_amount";
        public const string KEY_INSTALLMENT_TYPE = "new_installmenttype";
        public const string KEY_RESULT_CODE = "new_resultcode";
        public const string KEY_RESULT = "new_resultmessage";

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

        public enum InstallmentTypeCode
        {
            ONE = 1,
            TWO,
            THREE,
            FOUR,
            FIVE,
            SIX,
            SEVEN,
            EIGHT,
            NINE
        }
    }
}
