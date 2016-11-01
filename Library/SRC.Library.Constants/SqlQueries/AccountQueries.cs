using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.Library.Constants.SqlQueries
{
    public class AccountQueries
    {
        #region | GET_ACCOUNT |
        public const string GET_ACCOUNT = @"SELECT
	                                        AC.AccountId AS Id
	                                        ,AC.Name
	                                        ,AC.new_code AS Code
	                                        ,AC.Telephone1 AS LandPhone
	                                        ,AC.Telephone2 AS WorkPhone
	                                        ,AC.Fax
	                                        ,AC.EMailAddress1 AS EmailAddress
	                                        ,AC.WebSiteURL AS WebSite
	                                        ,AC.new_taxnumber AS TaxNumber
	                                        ,AC.new_taxofficeid AS TaxOfficeId
	                                        ,AC.new_taxofficeidName AS TaxOfficeIdName
	                                        ,AC.Address1_Line1 AS Address
	                                        ,AC.new_registryid AS RegistryId
	                                        ,AC.new_isassociationmember AS IsAssociationMember
	                                        ,AC.new_cityid AS CityId
	                                        ,AC.new_cityidName AS CityIdName
	                                        ,AC.new_ischecked AS IsChecked
	                                        ,AC.new_iseducationcompany AS IsEducationCompany
                                            ,AC.StateCode AS State
                                            ,AC.StatusCode AS Status
                                        FROM
	                                        Account AC WITH (NOLOCK)
                                        WHERE
	                                        AC.AccountId = @Id";

        #endregion

        #region | GET_ACCOUNT_LIST |
        public const string GET_ACCOUNT_LIST = @"SELECT
	                                        AC.AccountId AS Id
	                                        ,AC.Name
	                                        ,AC.new_code AS Code
	                                        ,AC.Telephone1 AS LandPhone
	                                        ,AC.Telephone2 AS WorkPhone
	                                        ,AC.Fax
	                                        ,AC.EMailAddress1 AS EmailAddress
	                                        ,AC.WebSiteURL AS WebSite
	                                        ,AC.new_taxnumber AS TaxNumber
	                                        ,AC.new_taxofficeid AS TaxOfficeId
	                                        ,AC.new_taxofficeidName AS TaxOfficeIdName
	                                        ,AC.Address1_Line1 AS Address
	                                        ,AC.new_registryid AS RegistryId
	                                        ,AC.new_isassociationmember AS IsAssociationMember
	                                        ,AC.new_cityid AS CityId
	                                        ,AC.new_cityidName AS CityIdName
	                                        ,AC.new_ischecked AS IsChecked
	                                        ,AC.new_iseducationcompany AS IsEducationCompany
                                            ,AC.StateCode AS State
                                            ,AC.StatusCode AS Status
                                        FROM
	                                        Account AC WITH (NOLOCK)";

        #endregion
    }
}
