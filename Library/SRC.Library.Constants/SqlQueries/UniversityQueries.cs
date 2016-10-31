using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.Library.Constants.SqlQueries
{
    public class UniversityQueries
    {
        #region | GET_UNIVERSITY |
        public const string GET_UNIVERSITY = @"SELECT
	                                                        U.new_universityId AS Id
	                                                        ,U.new_name AS Name
	                                                        ,U.new_code AS Code
	                                                        ,U.statecode AS State
	                                                        ,U.statecode AS Status
	                                                        ,U.CreatedOn
	                                                        ,U.ModifiedOn
                                                        FROM
	                                                        new_university U WITH (NOLOCK)
                                                        WHERE
	                                                        U.new_universityId = @Id";

        #endregion

        #region | GET_UNIVERSITY_LIST |
        public const string GET_UNIVERSITY_LIST = @"SELECT
	                                                        U.new_universityId AS Id
	                                                        ,U.new_name AS Name
	                                                        ,U.new_code AS Code
	                                                        ,U.statecode AS State
	                                                        ,U.statecode AS Status
	                                                        ,U.CreatedOn
	                                                        ,U.ModifiedOn
                                                        FROM
	                                                        new_university U WITH (NOLOCK)";

        #endregion
    }
}
