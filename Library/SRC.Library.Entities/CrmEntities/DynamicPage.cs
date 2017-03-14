using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.Library.Entities.CrmEntities
{
    [CrmSchemaName(KEY_LOGICAL_NAME)]
    public class DynamicPage : EntityBase
    {
        [CrmFieldDataType(CrmDataType.UNIQUEIDENTIFIER)]
        [CrmFieldName(KEY_DYANMIC_PAGE_ID)]
        public Guid Id { get; set; }

        [CrmFieldDataType(CrmDataType.STRING)]
        [CrmFieldName(KEY_NAME)]
        public string Name { get; set; }

        [CrmFieldDataType(CrmDataType.OPTIONSETVALUE)]
        [CrmFieldName(KEY_PAGE_TYPE)]
        public OptionSetValueWrapper PageType { get; set; }

        [CrmFieldDataType(CrmDataType.STRING)]
        [CrmFieldName(KEY_CONTENT)]
        public string Content { get; set; }

        public const string KEY_LOGICAL_NAME = "new_dynamicpage";
        public const string KEY_DYANMIC_PAGE_ID = "new_dynamicpageid";
        public const string KEY_NAME = "new_name";
        public const string KEY_PAGE_TYPE = "new_pagetype";
        public const string KEY_CONTENT = "new_content";

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
            NOT_PUBLISHED = 100000001,
        }

        public enum PageTypeCode
        {
            ROTATOR = 1,
            FOOTER = 2,
            EDUCATION_APPLICATION_CONDITION = 3,
            TRANSFER_INFORMATION = 4,
            CONTACT = 5,
            NEW_USER_CONTRACT=6,
            APPLY_CONTRACT = 7,
            CANCEL_CONTRACT=8
        }
    }
}
