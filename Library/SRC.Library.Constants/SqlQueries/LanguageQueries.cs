using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.Library.Constants.SqlQueries
{
    public class LanguageQueries
    {
        #region | GET_LANGUAGE |
        public const string GET_LANGUAGE = @"SELECT
	                                                        L.new_languageId AS Id
	                                                        ,L.new_name AS Name
	                                                        ,L.new_code AS Code
	                                                        ,L.statecode AS State
	                                                        ,L.statecode AS Status
	                                                        ,L.CreatedOn
	                                                        ,L.ModifiedOn
                                                        FROM
	                                                        new_language L WITH (NOLOCK)
                                                        WHERE
	                                                        L.new_languageId = @Id";

        #endregion

        #region | GET_LANGUAGE_LIST |
        public const string GET_LANGUAGE_LIST = @"SELECT
	                                                        L.new_languageId AS Id
	                                                        ,L.new_name AS Name
	                                                        ,L.new_code AS Code
	                                                        ,L.statecode AS State
	                                                        ,L.statecode AS Status
	                                                        ,L.CreatedOn
	                                                        ,L.ModifiedOn
                                                        FROM
	                                                        new_language L WITH (NOLOCK)";

        #endregion
    }
}
