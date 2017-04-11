using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.Library.Constants.SqlQueries
{
    public class AssociationQueries
    {
        #region | GET_ASSOCIATION |
        public const string GET_ASSOCIATION = @"SELECT
	                                                AC.new_associationId AS Id
	                                                ,AC.new_name AS Name
	                                                ,AC.new_code AS Code
	                                                ,AC.statecode AS State
	                                                ,AC.statecode AS Status
	                                                ,AC.CreatedOn
	                                                ,AC.ModifiedOn
                                                FROM
	                                                new_association AC WITH (NOLOCK)
                                                WHERE
	                                                AC.new_associationId = @Id";

        #endregion

        #region | GET_ASSOCIATION_LIST |
        public const string GET_ASSOCIATION_LIST = @"SELECT
	                                                AC.new_associationId AS Id
	                                                ,AC.new_name AS Name
	                                                ,AC.new_code AS Code
	                                                ,AC.statecode AS State
	                                                ,AC.statecode AS Status
	                                                ,AC.CreatedOn
	                                                ,AC.ModifiedOn
                                                FROM
	                                                new_association AC WITH (NOLOCK)
                                                WHERE
	                                                AC.StateCode = 0";

        #endregion

        #region | GET_ASSOCIATION_BY_CODE |
        public const string GET_ASSOCIATION_BY_CODE = @"SELECT
	                                                AC.new_associationId AS Id
	                                                ,AC.new_name AS Name
	                                                ,AC.new_code AS Code
	                                                ,AC.statecode AS State
	                                                ,AC.statecode AS Status
	                                                ,AC.CreatedOn
	                                                ,AC.ModifiedOn
                                                FROM
	                                                new_association AC WITH (NOLOCK)
                                                WHERE
	                                                AC.StateCode = 0
                                                    AND
                                                    AC.new_code = @Code";

        #endregion

        #region | GET_ASSOCIATION_ER_BY_EDUCATION |
        public const string GET_ASSOCIATION_ER_BY_EDUCATION = @"SELECT 
	                                                            EA.new_associationid AS Id
	                                                            ,a.new_name AS Name 
	                                                            ,'new_association' AS LogicalName                                                                
                                                            FROM
                                                            new_new_education_new_association EA WITH (NOLOCK)
	                                                            JOIN
		                                                            new_association AS a
			                                                            ON
			                                                            EA.new_associationid=a.new_associationId
                                                            WHERE
	                                                            EA.new_educationid = @educationId";
        #endregion
    }
}
