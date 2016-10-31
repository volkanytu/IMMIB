using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.Library.Constants.SqlQueries
{
    public class TaxOfficeQueries
    {
        #region | GET_TAX_OFFICE |
        public const string GET_TAX_OFFICE = @"SELECT
	                                                        TF.new_taxofficeId AS Id
	                                                        ,TF.new_name AS Name
	                                                        ,TF.new_code AS Code
	                                                        ,TF.statecode AS State
	                                                        ,TF.statecode AS Status
	                                                        ,TF.CreatedOn
	                                                        ,TF.ModifiedOn
                                                        FROM
	                                                        new_taxoffice TF WITH (NOLOCK)
                                                        WHERE
	                                                        TF.new_taxofficeId = @Id";

        #endregion

        #region | GET_TAX_OFFICE_LIST |
        public const string GET_TAX_OFFICE_LIST = @"SELECT
	                                                        TF.new_taxofficeId AS Id
	                                                        ,TF.new_name AS Name
	                                                        ,TF.new_code AS Code
	                                                        ,TF.statecode AS State
	                                                        ,TF.statecode AS Status
	                                                        ,TF.CreatedOn
	                                                        ,TF.ModifiedOn
                                                        FROM
	                                                        new_taxoffice TF WITH (NOLOCK)";

        #endregion
    }
}
