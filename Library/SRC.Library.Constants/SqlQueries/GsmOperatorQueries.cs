using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.Library.Constants.SqlQueries
{
    public class GsmOperatorQueries
    {
        #region | GET_GSM_OPERATOR |
        public const string GET_GSM_OPERATOR = @"SELECT
	                                                        G.new_gsmoperatorId AS Id
	                                                        ,G.new_name AS Name
	                                                        ,G.new_code AS Code
	                                                        ,G.statecode AS State
	                                                        ,G.statecode AS Status
	                                                        ,G.CreatedOn
	                                                        ,G.ModifiedOn
                                                        FROM
	                                                        new_gsmoperator G WITH (NOLOCK)
                                                        WHERE
	                                                        G.new_gsmoperatorId = @Id";

        #endregion

        #region | GET_GSM_OPERATOR_LIST |
        public const string GET_GSM_OPERATOR_LIST = @"SELECT
	                                                        G.new_gsmoperatorId AS Id
	                                                        ,G.new_name AS Name
	                                                        ,G.new_code AS Code
	                                                        ,G.statecode AS State
	                                                        ,G.statecode AS Status
	                                                        ,G.CreatedOn
	                                                        ,G.ModifiedOn
                                                        FROM
	                                                        new_gsmoperator G WITH (NOLOCK)";

        #endregion
    }
}
