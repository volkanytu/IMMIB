using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.Library.Constants.SqlQueries
{
    public class CommonQueries
    {
        public const string GET_ENTITY_NAME_BY_CODE = @"SELECT TOP 1 e.Name FROM Entity AS e WHERE e.ObjectTypeCode=@objectTypeCode";
    }
}
