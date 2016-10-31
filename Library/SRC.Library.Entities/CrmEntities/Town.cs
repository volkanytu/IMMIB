using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.Library.Entities.CrmEntities
{
    [CrmSchemaName(KEY_LOGICAL_NAME)]
    public class Town : EntityBase
    {
        [CrmFieldDataType(CrmDataType.UNIQUEIDENTIFIER)]
        [CrmFieldName(KEY_TOWN_ID)]
        public Guid Id { get; set; }

        [CrmFieldDataType(CrmDataType.STRING)]
        [CrmFieldName(KEY_NAME)]
        public string Name { get; set; }

        [CrmFieldDataType(CrmDataType.INT)]
        [CrmFieldName(KEY_CODE)]
        public int? Code { get; set; }

        [CrmFieldDataType(CrmDataType.ENTITYREFERENCE)]
        [CrmFieldName(KEY_CITY_ID)]
        public EntityReferenceWrapper CityId { get; set; }

        public const string KEY_LOGICAL_NAME = "new_town";
        public const string KEY_TOWN_ID = "new_townid";
        public const string KEY_NAME = "new_name";
        public const string KEY_CODE = "new_code";
        public const string KEY_CITY_ID = "new_cityid";
    }
}
