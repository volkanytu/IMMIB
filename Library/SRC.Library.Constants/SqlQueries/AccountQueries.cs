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
                                            ,AC.new_associationid AS Association
                                            ,AC.new_associationidName AS AssociationName
	                                        ,AC.new_taxoffice AS TaxOffice
	                                        ,AC.Address1_Line1 AS Address
	                                        ,AC.new_registryid AS RegistryId
	                                        ,AC.new_isassociationmember AS IsAssociationMember
	                                        ,AC.new_cityid AS City
	                                        ,AC.new_cityidName AS CityName
	                                        ,AC.new_ischecked AS IsChecked
	                                        ,AC.new_iseducationcompany AS IsEducationCompany
                                            ,AC.StateCode AS State
                                            ,AC.StatusCode AS Status
                                        FROM
	                                        Account AC WITH (NOLOCK)
                                        WHERE
	                                        AC.AccountId = @Id AND AC.StateCode = 0";

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
                                            ,AC.new_associationid AS Association
                                            ,AC.new_associationidName AS AssociationName
	                                        ,AC.new_taxoffice AS TaxOffice
	                                        ,AC.Address1_Line1 AS Address
	                                        ,AC.new_registryid AS RegistryId
	                                        ,AC.new_isassociationmember AS IsAssociationMember
	                                        ,AC.new_cityid AS City
	                                        ,AC.new_cityidName AS CityName
	                                        ,AC.new_ischecked AS IsChecked
	                                        ,AC.new_iseducationcompany AS IsEducationCompany
                                            ,AC.StateCode AS State
                                            ,AC.StatusCode AS Status
                                        FROM
	                                        Account AC WITH (NOLOCK) 
                                        WHERE
                                            AC.StateCode = 0";

        #endregion

        #region | GET_ACCOUNT_BY_TAX_NUMBER |
        public const string GET_ACCOUNT_BY_TAX_NUMBER = @"SELECT
	                                        AC.AccountId AS Id
	                                        ,AC.Name
	                                        ,AC.new_code AS Code
	                                        ,AC.Telephone1 AS LandPhone
	                                        ,AC.Telephone2 AS WorkPhone
	                                        ,AC.Fax
	                                        ,AC.EMailAddress1 AS EmailAddress
	                                        ,AC.WebSiteURL AS WebSite
	                                        ,AC.new_taxnumber AS TaxNumber
                                            ,AC.new_associationid AS Association
                                            ,AC.new_associationidName AS AssociationName
	                                        ,AC.new_taxoffice AS TaxOffice
	                                        ,AC.Address1_Line1 AS Address
	                                        ,AC.new_registryid AS RegistryId
	                                        ,AC.new_isassociationmember AS IsAssociationMember
	                                        ,AC.new_cityid AS City
	                                        ,AC.new_cityidName AS CityName
	                                        ,AC.new_ischecked AS IsChecked
	                                        ,AC.new_iseducationcompany AS IsEducationCompany
                                            ,AC.StateCode AS State
                                            ,AC.StatusCode AS Status
                                        FROM
	                                        Account AC WITH (NOLOCK)
                                        WHERE
	                                        AC.new_taxnumber = @taxNumber AND AC.StateCode = 0";

        #endregion
    }
}
