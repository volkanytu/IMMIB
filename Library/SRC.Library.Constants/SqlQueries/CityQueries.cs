using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.Library.Constants.SqlQueries
{
    public class CityQueries
    {
        #region | GET_CITY |
        public const string GET_CITY = @"SELECT
	                                                C.new_cityId AS Id
	                                                ,C.new_name AS Name
	                                                ,C.new_code AS Code
	                                                ,C.statecode AS State
	                                                ,C.statecode AS Status
	                                                ,C.CreatedOn
	                                                ,C.ModifiedOn
                                                FROM
	                                                new_city C WITH (NOLOCK)
                                                WHERE
	                                                C.new_cityId = @Id AND C.StateCode = 0";

        #endregion

        #region | GET_CITY_LIST |
        public const string GET_CITY_LIST = @"SELECT
	                                                C.new_cityId AS Id
	                                                ,C.new_name AS Name
	                                                ,C.new_code AS Code
	                                                ,C.statecode AS State
	                                                ,C.statecode AS Status
	                                                ,C.CreatedOn
	                                                ,C.ModifiedOn
                                                FROM
	                                                new_city C WITH (NOLOCK)
                                                WHERE
	                                                C.StateCode = 0";

        #endregion
    }
}
