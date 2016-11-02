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

        [CrmFieldDataType(CrmDataType.STRING)]
        [CrmFieldName(KEY_FIRSTNAME)]
        public string FirstName { get; set; }

        [CrmFieldDataType(CrmDataType.STRING)]
        [CrmFieldName(KEY_LASTNAME)]
        public string LastName { get; set; }

        [CrmFieldDataType(CrmDataType.STRING)]
        [CrmFieldName(KEY_USERNAME)]
        public string UserName { get; set; }

        [CrmFieldDataType(CrmDataType.STRING)]
        [CrmFieldName(KEY_PASSWORD)]
        public string Password { get; set; }

        [CrmFieldDataType(CrmDataType.DATETIME)]
        [CrmFieldName(KEY_FIRST_LOGIN_DATE)]
        public DateTime? FirstLoginDate { get; set; }

        [CrmFieldDataType(CrmDataType.STRING)]
        [CrmFieldName(KEY_ID_NO)]
        public string IdNo { get; set; }

        [CrmFieldDataType(CrmDataType.DATETIME)]
        [CrmFieldName(KEY_BIRTHDATE)]
        public DateTime? BirthDate { get; set; }

        [CrmFieldDataType(CrmDataType.OPTIONSETVALUE)]
        [CrmFieldName(KEY_GENDER_CODE)]
        public OptionSetValueWrapper Gender { get; set; }

        [CrmFieldDataType(CrmDataType.STRING)]
        [CrmFieldName(KEY_MOBILE_PHONE)]
        public string MobilePhone { get; set; }

        [CrmFieldDataType(CrmDataType.ENTITYREFERENCE)]
        [CrmFieldName(KEY_GSM_OPERATOR_ID)]
        public EntityReferenceWrapper GsmOperator { get; set; }

        [CrmFieldDataType(CrmDataType.STRING)]
        [CrmFieldName(KEY_LAND_PHONE)]
        public string LandPhone { get; set; }

        [CrmFieldDataType(CrmDataType.STRING)]
        [CrmFieldName(KEY_WORK_PHONE)]
        public string WorkPhone { get; set; }

        [CrmFieldDataType(CrmDataType.STRING)]
        [CrmFieldName(KEY_FAX)]
        public string Fax { get; set; }

        [CrmFieldDataType(CrmDataType.STRING)]
        [CrmFieldName(KEY_EMAIL_ADDRESS)]
        public string EmailAddress { get; set; }

        [CrmFieldDataType(CrmDataType.ENTITYREFERENCE)]
        [CrmFieldName(KEY_UNIVERSITY_ID)]
        public EntityReferenceWrapper University { get; set; }

        [CrmFieldDataType(CrmDataType.STRING)]
        [CrmFieldName(KEY_COMPANY_NAME)]
        public string CompanyName { get; set; }

        [CrmFieldDataType(CrmDataType.STRING)]
        [CrmFieldName(KEY_TAX_NUMBER)]
        public string TaxNumber { get; set; }

        [CrmFieldDataType(CrmDataType.ENTITYREFERENCE)]
        [CrmFieldName(KEY_TAX_OFFICE_ID)]
        public EntityReferenceWrapper TaxOffice { get; set; }

        [CrmFieldDataType(CrmDataType.STRING)]
        [CrmFieldName(KEY_COMPANY_ADDRESS)]
        public string CompanyAddress { get; set; }

        [CrmFieldDataType(CrmDataType.STRING)]
        [CrmFieldName(KEY_COMPANY_POSITION)]
        public string CompanyPosition { get; set; }

        [CrmFieldDataType(CrmDataType.ENTITYREFERENCE)]
        [CrmFieldName(KEY_INFORMEDBY_ID)]
        public EntityReferenceWrapper InformedBy { get; set; }

        [CrmFieldDataType(CrmDataType.ENTITYREFERENCE)]
        [CrmFieldName(KEY_CITY_ID)]
        public EntityReferenceWrapper CityId { get; set; }

        [CrmFieldDataType(CrmDataType.OPTIONSETVALUE)]
        [CrmFieldName(KEY_EDUCATION_LEVEL)]
        public OptionSetValueWrapper EducationLevel { get; set; }

        [CrmFieldDataType(CrmDataType.BOOL)]
        [CrmFieldName(KEY_IS_EDUCATOR)]
        public bool? IsEducator { get; set; }

        [CrmFieldDataType(CrmDataType.BOOL)]
        [CrmFieldName(KEY_IS_ASSOCIATION_EMPLOYEE)]
        public bool? IsAssociationEmployee { get; set; }

        [CrmFieldDataType(CrmDataType.STRING)]
        [CrmFieldName(KEY_INFO)]
        public string Info { get; set; }

        public const string KEY_LOGICAL_NAME = "contact";
        public const string KEY_CONTACT_ID = "contactid";
        public const string KEY_FULLNAME = "fullname";
        public const string KEY_FIRSTNAME = "firstname";
        public const string KEY_LASTNAME = "lastname";
        public const string KEY_USERNAME = "new_username";
        public const string KEY_PASSWORD = "new_password";
        public const string KEY_FIRST_LOGIN_DATE = "new_firstlogindate";
        public const string KEY_ID_NO = "new_idno";
        public const string KEY_BIRTHDATE = "birthdate";
        public const string KEY_GENDER_CODE = "gendercode";
        public const string KEY_MOBILE_PHONE = "mobilephone";
        public const string KEY_GSM_OPERATOR_ID = "new_gsmoperatorid";
        public const string KEY_LAND_PHONE = "telephone2";
        public const string KEY_WORK_PHONE = "telephone1";
        public const string KEY_FAX = "fax";
        public const string KEY_EMAIL_ADDRESS = "emailaddress1";
        public const string KEY_UNIVERSITY_ID = "new_universityid";
        public const string KEY_COMPANY_NAME = "new_companyname";
        public const string KEY_TAX_NUMBER = "new_taxnumber";
        public const string KEY_TAX_OFFICE_ID = "new_taxofficeid";
        public const string KEY_COMPANY_ADDRESS = "new_address";
        public const string KEY_COMPANY_POSITION = "new_companyposition";
        public const string KEY_INFORMEDBY_ID = "new_informedbyid";
        public const string KEY_CITY_ID = "new_cityid";
        public const string KEY_EDUCATION_LEVEL = "new_educationlevel";
        public const string KEY_IS_EDUCATOR = "new_iseducator";
        public const string KEY_IS_ASSOCIATION_EMPLOYEE = "new_isassociationemployee";
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
            WAITING = 100000000
        }

        public enum GenderCode
        {
            MALE = 1,
            FEMALE = 2
        }

        public enum EducationLevelCode
        {
            PRIMARY_SCHOOL = 1,
            HIGH_SCHOOL = 2,
            DEGREE = 3
        }
    }
}
