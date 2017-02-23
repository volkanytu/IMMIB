using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.Library.Entities.CrmEntities
{
    [CrmSchemaName(KEY_LOGICAL_NAME)]
    public class Education : EntityBase
    {
        [CrmFieldDataType(CrmDataType.UNIQUEIDENTIFIER)]
        [CrmFieldName(KEY_EDUCATION_ID)]
        public Guid Id { get; set; }

        [CrmFieldDataType(CrmDataType.STRING)]
        [CrmFieldName(KEY_NAME)]
        public string Name { get; set; }

        [CrmFieldDataType(CrmDataType.STRING)]
        [CrmFieldName(KEY_CODE)]
        public string Code { get; set; }

        [CrmFieldDataType(CrmDataType.ENTITYREFERENCE)]
        [CrmFieldName(KEY_EDUCATION_DEFINITION_ID)]
        public EntityReferenceWrapper EducationDefinition { get; set; }

        [CrmFieldDataType(CrmDataType.ENTITYREFERENCE)]
        [CrmFieldName(KEY_CONTACT_ID)]
        public EntityReferenceWrapper Contact { get; set; }

        [CrmFieldDataType(CrmDataType.OPTIONSETVALUE)]
        [CrmFieldName(KEY_EDUCATION_TYPE)]
        public OptionSetValueWrapper EducationType { get; set; }

        [CrmFieldDataType(CrmDataType.DECIMAL)]
        [CrmFieldName(KEY_EDUCATION_AMOUNT)]
        public decimal? EducationAmount { get; set; }


        [CrmFieldDataType(CrmDataType.INT)]
        [CrmFieldName(KEY_QUOTA)]
        public int? Quota { get; set; }

        [CrmFieldDataType(CrmDataType.INT)]
        [CrmFieldName(KEY_LEFT_QUOTA)]
        public int? LeftQuota { get; set; }

        [CrmFieldDataType(CrmDataType.INT)]
        [CrmFieldName(KEY_STUDENT_QUOTA)]
        public int? StudentQuota { get; set; }

        [CrmFieldDataType(CrmDataType.INT)]
        [CrmFieldName(KEY_STUDENT_LEFT_QUOTA)]
        public int? StudentLeftQuota { get; set; }

        [CrmFieldDataType(CrmDataType.BOOL)]
        [CrmFieldName(KEY_IS_LIMITED_SINGLE_ATTEND)]
        public bool? IsLimitedBySingleAttend { get; set; }

        [CrmFieldDataType(CrmDataType.INT)]
        [CrmFieldName(KEY_MAX_SINGLE_ATTEND_COUNT)]
        public int? MaxSingleAttendCount { get; set; }

        [CrmFieldDataType(CrmDataType.BOOL)]
        [CrmFieldName(KEY_IS_PAID)]
        public bool? IsPaid { get; set; }

        [CrmFieldDataType(CrmDataType.BOOL)]
        [CrmFieldName(KEY_IS_PAYMENT_RETURN_ON_CANCEL)]
        public bool? IsPaymentReturnOnCancel { get; set; }

        [CrmFieldDataType(CrmDataType.DECIMAL)]
        [CrmFieldName(KEY_EDUCATION_PRICE)]
        public decimal? EducationPrice { get; set; }

        [CrmFieldDataType(CrmDataType.BOOL)]
        [CrmFieldName(KEY_IS_STUDENT_CAN_ATTEND)]
        public bool? IsStudentCanAttend { get; set; }

        [CrmFieldDataType(CrmDataType.ENTITYREFERENCE)]
        [CrmFieldName(KEY_CITY_ID)]
        public EntityReferenceWrapper City { get; set; }

        [CrmFieldDataType(CrmDataType.ENTITYREFERENCE)]
        [CrmFieldName(KEY_TOWN_ID)]
        public EntityReferenceWrapper Town { get; set; }

        [CrmFieldDataType(CrmDataType.ENTITYREFERENCE)]
        [CrmFieldName(KEY_EDUCATION_LOCATION_ID)]
        public EntityReferenceWrapper EducationLocation { get; set; }

        [CrmFieldDataType(CrmDataType.DATETIME)]
        [CrmFieldName(KEY_START_DATE)]
        public DateTime? StartDate { get; set; }

        [CrmFieldDataType(CrmDataType.DATETIME)]
        [CrmFieldName(KEY_END_DATE)]
        public DateTime? EndDate { get; set; }

        [CrmFieldDataType(CrmDataType.DATETIME)]
        [CrmFieldName(KEY_RECORD_START_DATE)]
        public DateTime? RecordStartDate { get; set; }

        [CrmFieldDataType(CrmDataType.DATETIME)]
        [CrmFieldName(KEY_RECORD_END_DATE)]
        public DateTime? RecordEndDate { get; set; }

        [CrmFieldDataType(CrmDataType.INT)]
        [CrmFieldName(KEY_EDUCATION_PERIOD)]
        public int? EducationPeriod { get; set; }

        [CrmFieldDataType(CrmDataType.STRING)]
        [CrmFieldName(KEY_INFO)]
        public string Info { get; set; }

        public EducationAttendance Attendance { get; set; }

        public bool IsExpired
        {
            get
            {
                if (StartDate != null && StartDate > DateTime.Now)
                {
                    return false;
                }

                return true;
            }
        }

        public string FormattedEducationHour
        {
            get
            {
                if (StartDate != null && EndDate != null)
                {
                    return string.Format("{0}-{1}", StartDate.Value.ToString("HH:mm"), EndDate.Value.ToString("HH:mm"));
                }

                return null;
            }
        }

        public string FormattedEducationDate
        {
            get
            {
                if (StartDate != null && EndDate != null)
                {
                    return string.Format("{0}-{1}", StartDate.Value.ToString("dd.MM.yyyy"), EndDate.Value.ToString("dd.MM.yyyy"));
                }

                return null;
            }
        }

        public string FormattedRecordDate
        {
            get
            {
                if (RecordStartDate != null && RecordEndDate != null)
                {
                    return string.Format("{0}-{1}", RecordStartDate.Value.ToString("dd.MM.yyyy"), RecordEndDate.Value.ToString("dd.MM.yyyy"));
                }

                return null;
            }
        }

        public List<EntityReferenceWrapper> AssociationPermissions { get; set; }

        public const string KEY_LOGICAL_NAME = "new_education";
        public const string KEY_EDUCATION_ID = "new_educationid";
        public const string KEY_NAME = "new_name";
        public const string KEY_CODE = "new_code";
        public const string KEY_EDUCATION_DEFINITION_ID = "new_educationdefinitionid";
        public const string KEY_CONTACT_ID = "new_contactid";
        public const string KEY_EDUCATION_TYPE = "new_educationtype";
        public const string KEY_EDUCATION_AMOUNT = "new_educationamount";
        public const string KEY_QUOTA = "new_quota";
        public const string KEY_LEFT_QUOTA = "new_leftquota";
        public const string KEY_STUDENT_QUOTA = "new_quota";
        public const string KEY_STUDENT_LEFT_QUOTA = "new_leftquota";
        public const string KEY_IS_LIMITED_SINGLE_ATTEND = "new_islimitedbysingleattend";
        public const string KEY_MAX_SINGLE_ATTEND_COUNT = "new_maxsingleattendcount";
        public const string KEY_IS_PAID = "new_ispaid";
        public const string KEY_IS_PAYMENT_RETURN_ON_CANCEL = "new_ispaymentretunoncancel";
        public const string KEY_EDUCATION_PRICE = "new_educationprice";
        public const string KEY_IS_STUDENT_CAN_ATTEND = "new_isstudentcanattend";
        public const string KEY_CITY_ID = "new_cityid";
        public const string KEY_TOWN_ID = "new_townid";
        public const string KEY_EDUCATION_LOCATION_ID = "new_educationlocationid";
        public const string KEY_START_DATE = "new_startdate";
        public const string KEY_END_DATE = "new_enddate";
        public const string KEY_RECORD_START_DATE = "new_recordstartdate";
        public const string KEY_RECORD_END_DATE = "new_recordenddate";
        public const string KEY_EDUCATION_PERIOD = "new_educationperiod";
        public const string KEY_INFO = "new_info";

        public enum StateCode
        {
            ACTIVE = 0,
            PASSIVE = 1
        }

        public enum StatusCode
        {
            ACTIVE = 1,
            PASSIVE = 2,
            PUBLISHED = 100000000,
            CANCELED = 100000001
        }

        public enum EducationTypeCode
        {
            EXTERNAL_EDUCATION = 1,
            INTERNAL_EDUCATION = 2
        }
    }
}
