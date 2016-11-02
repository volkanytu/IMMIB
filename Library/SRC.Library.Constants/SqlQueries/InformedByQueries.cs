using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.Library.Constants.SqlQueries
{
    public class InformedByQueries
    {
        #region | GET_INFORMEDBY |
        public const string GET_INFORMEDBY = @"SELECT
	                                                        IB.new_informedbyId AS Id
	                                                        ,IB.new_name AS Name
	                                                        ,IB.new_code AS Code
	                                                        ,IB.statecode AS State
	                                                        ,IB.statecode AS Status
	                                                        ,IB.CreatedOn
	                                                        ,IB.ModifiedOn
                                                        FROM
	                                                        new_informedby IB WITH (NOLOCK)
                                                        WHERE
	                                                        IB.new_informedbyId = @Id AND IB.StateCode = 0";

        #endregion

        #region | GET_INFORMEDBY_LIST |
        public const string GET_INFORMEDBY_LIST = @"SELECT
	                                                        IB.new_informedbyId AS Id
	                                                        ,IB.new_name AS Name
	                                                        ,IB.new_code AS Code
	                                                        ,IB.statecode AS State
	                                                        ,IB.statecode AS Status
	                                                        ,IB.CreatedOn
	                                                        ,IB.ModifiedOn
                                                        FROM
	                                                        new_informedby IB WITH (NOLOCK)
                                                        WHERE
	                                                        IB.StateCode = 0";

        #endregion
    }
}
