using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.Library.Constants.SqlQueries
{
    public class TownQueries
    {
        #region | GET_TOWN |
        public const string GET_TOWN = @"SELECT
	                                                        T.new_townId AS Id
	                                                        ,T.new_name AS Name
	                                                        ,T.new_code AS Code
	                                                        ,T.statecode AS State
	                                                        ,T.statecode AS Status
															,T.new_cityid AS City
															,T.new_cityidName AS CityName
	                                                        ,T.CreatedOn
	                                                        ,T.ModifiedOn
                                                        FROM
	                                                        new_town T WITH (NOLOCK)
                                                        WHERE
	                                                        T.new_townId = @Id AND T.StateCode = 0";

        #endregion

        #region | GET_TOWN_LIST |
        public const string GET_TOWN_LIST = @"SELECT
	                                                        T.new_townId AS Id
	                                                        ,T.new_name AS Name
	                                                        ,T.new_code AS Code
	                                                        ,T.statecode AS State
	                                                        ,T.statecode AS Status
															,T.new_cityid AS City
															,T.new_cityidName AS CityName
	                                                        ,T.CreatedOn
	                                                        ,T.ModifiedOn
                                                        FROM
	                                                        new_town T WITH (NOLOCK)
                                                        WHERE
	                                                        T.StateCode = 0";

        #endregion
    }
}
