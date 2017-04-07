using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.Library.Entities.CrmEntities
{
    [CrmSchemaName(KEY_LOGICAL_NAME)]
    public class Account: EntityBase
    {
        [CrmFieldDataType(CrmDataType.UNIQUEIDENTIFIER)]
        [CrmFieldName(KEY_ACCOUNT_ID)]
        public Guid Id { get; set; }

        [CrmFieldDataType(CrmDataType.STRING)]
        [CrmFieldName(KEY_NAME)]
        public string Name { get; set; }

        [CrmFieldDataType(CrmDataType.INT)]
        [CrmFieldName(KEY_CODE)]
        public int? Code { get; set; }

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

        [CrmFieldDataType(CrmDataType.STRING)]
        [CrmFieldName(KEY_WEB_SITE)]
        public string WebSite { get; set; }

        [CrmFieldDataType(CrmDataType.STRING)]
        [CrmFieldName(KEY_TAX_NUMBER)]
        public string TaxNumber { get; set; }

        [CrmFieldDataType(CrmDataType.ENTITYREFERENCE)]
        [CrmFieldName(KEY_TAX_OFFICE)]
        public string TaxOffice { get; set; }

        [CrmFieldDataType(CrmDataType.STRING)]
        [CrmFieldName(KEY_ADDRESS)]
        public string Address { get; set; }

        [CrmFieldDataType(CrmDataType.STRING)]
        [CrmFieldName(KEY_REGISTRY_ID)]
        public string RegistryId { get; set; }

        [CrmFieldDataType(CrmDataType.BOOL)]
        [CrmFieldName(KEY_IS_ASSOCIATION_MEMBER)]
        public bool? IsAssociationMember { get; set; }

        [CrmFieldDataType(CrmDataType.ENTITYREFERENCE)]
        [CrmFieldName(KEY_CITY_ID)]
        public EntityReferenceWrapper City { get; set; }

        [CrmFieldDataType(CrmDataType.BOOL)]
        [CrmFieldName(KEY_IS_CHECKED)]
        public bool? IsChecked { get; set; }

        [CrmFieldDataType(CrmDataType.BOOL)]
        [CrmFieldName(KEY_IS_EDUCATION_COMPANY)]
        public bool? IsEducationCompany { get; set; }

        public List<EntityReferenceWrapper> MemberOfAssociations { get; set; }  

        public const string KEY_LOGICAL_NAME = "account";
        public const string KEY_ACCOUNT_ID = "accountid";
        public const string KEY_NAME = "name";
        public const string KEY_CODE = "new_code";
        public const string KEY_LAND_PHONE = "telephone1";
        public const string KEY_WORK_PHONE = "telephone2";
        public const string KEY_FAX = "fax";
        public const string KEY_EMAIL_ADDRESS = "emailaddress1";
        public const string KEY_WEB_SITE = "websiteurl";
        public const string KEY_TAX_NUMBER = "new_taxnumber";
        public const string KEY_TAX_OFFICE = "new_taxoffice";
        public const string KEY_ADDRESS = "address1_line1";
        public const string KEY_REGISTRY_ID = "new_registryid";
        public const string KEY_IS_ASSOCIATION_MEMBER = "new_isassociationmember";
        public const string KEY_CITY_ID = "new_cityid";
        public const string KEY_IS_CHECKED = "new_ischecked";
        public const string KEY_IS_EDUCATION_COMPANY = "new_iseducationcompany";

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
