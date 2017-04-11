using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.Library.Constants.SqlQueries
{
    public class EducationLocationQueries
    {
        #region | GET_EDUCATION_LOCATION |
        public const string GET_EDUCATION_LOCATION = @"SELECT
	                                                        ED.new_educationlocationId AS Id
	                                                        ,ED.new_name AS Name
	                                                        ,ED.new_code AS Code
	                                                        ,ED.statecode AS State
	                                                        ,ED.statecode AS Status
	                                                        ,ED.CreatedOn
	                                                        ,ED.ModifiedOn
                                                        FROM
	                                                        new_educationlocation ED WITH (NOLOCK)
                                                        WHERE
	                                                        ED.new_educationlocationId = @Id";

        #endregion

        #region | GET_EDUCATION_LOCATION_LIST |
        public const string GET_EDUCATION_LOCATION_LIST = @"SELECT
	                                                        ED.new_educationlocationId AS Id
	                                                        ,ED.new_name AS Name
	                                                        ,ED.new_code AS Code
	                                                        ,ED.statecode AS State
	                                                        ,ED.statecode AS Status
	                                                        ,ED.CreatedOn
	                                                        ,ED.ModifiedOn
                                                        FROM
	                                                        new_educationlocation ED WITH (NOLOCK)
                                                        WHERE
                                                            ED.StateCode = 0";

        #endregion
    }
}
