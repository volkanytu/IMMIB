using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.Library.Entities.CrmEntities
{
    public class EntityBase
    {
        [CrmFieldDataType(CrmDataType.OPTIONSETVALUE)]
        [CrmFieldName("statecode")]
        public OptionSetValueWrapper State { get; set; }

        [CrmFieldDataType(CrmDataType.OPTIONSETVALUE)]
        [CrmFieldName("statuscode")]
        public OptionSetValueWrapper Status { get; set; }

        [CrmFieldDataType(CrmDataType.DATETIME)]
        public DateTime? CreatedOn { get; set; }

        [CrmFieldDataType(CrmDataType.DATETIME)]
        public DateTime? ModifiedOn { get; set; }

        public string CreatedOnStr
        {
            get
            {
                if (CreatedOn != null)
                {
                    return CreatedOn.Value.ToString("dd.MM.yyyy HH:mm");
                }

                return null;
            }
        }

        public string ModifiedOnStr
        {
            get
            {
                if (ModifiedOn != null)
                {
                    return ModifiedOn.Value.ToString("dd.MM.yyyy HH:mm");
                }

                return null;
            }
        }
    }
}
