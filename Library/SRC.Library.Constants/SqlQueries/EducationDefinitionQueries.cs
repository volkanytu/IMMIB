using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.Library.Constants.SqlQueries
{
    public class EducationDefinitionQueries
    {
        #region | GET_EDUCATION_DEFINITION |
        public const string GET_EDUCATION_DEFINITION = @"SELECT
	                                                        ED.new_educationdefinitionId AS Id
	                                                        ,ED.new_name AS Name
	                                                        ,ED.new_code AS Code
	                                                        ,ED.statecode AS State
	                                                        ,ED.statecode AS Status
	                                                        ,ED.CreatedOn
	                                                        ,ED.ModifiedOn
                                                        FROM
	                                                        new_educationdefinition ED WITH (NOLOCK)
                                                        WHERE
	                                                        ED.new_educationdefinitionId = @Id";

        #endregion

        #region | GET_EDUCATION_DEFINITION_LIST |
        public const string GET_EDUCATION_DEFINITION_LIST = @"SELECT
	                                                        ED.new_educationdefinitionId AS Id
	                                                        ,ED.new_name AS Name
	                                                        ,ED.new_code AS Code
	                                                        ,ED.statecode AS State
	                                                        ,ED.statecode AS Status
	                                                        ,ED.CreatedOn
	                                                        ,ED.ModifiedOn
                                                        FROM
	                                                        new_educationdefinition ED WITH (NOLOCK)
                                                        WHERE
	                                                        ED.StateCode = 0";

        #endregion
    }
}
