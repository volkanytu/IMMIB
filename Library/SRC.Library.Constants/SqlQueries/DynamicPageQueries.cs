using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.Library.Constants.SqlQueries
{
    public class DynamicPageQueries
    {
        #region | GET_DYNAMIC_PAGE |
        public const string GET_DYNAMIC_PAGE = @"SELECT
	                                                DP.new_dynamicpageId AS Id
	                                                ,DP.new_name AS Name
	                                                ,DP.new_pagetype AS PageType
	                                                ,DP.new_content AS Content
	                                                ,DP.statecode AS State
	                                                ,DP.statuscode AS Status
                                                FROM
	                                                new_dynamicpage DP WITH (NOLOCK)
                                                WHERE
	                                                DP.new_dynamicpageId = @Id
	                                                AND
	                                                DP.statecode = 0";

        #endregion

        #region | GET_DYNAMIC_PAGE_LIST |
        public const string GET_DYNAMIC_PAGE_LIST = @"SELECT
	                                                    DP.new_dynamicpageId AS Id
	                                                    ,DP.new_name AS Name
	                                                    ,DP.new_pagetype AS PageType
	                                                    ,DP.new_content AS Content
	                                                    ,DP.statecode AS State
	                                                    ,DP.statuscode AS Status
                                                    FROM
	                                                    new_dynamicpage DP WITH (NOLOCK)
                                                    WHERE
	                                                    DP.statecode = 0";

        #endregion
    }
}
