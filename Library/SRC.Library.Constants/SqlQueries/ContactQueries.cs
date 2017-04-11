using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.Library.Constants.SqlQueries
{
    public class ContactQueries
    {
        #region | GET_CONTACT |
        public const string GET_CONTACT = @"SELECT
	                                        C.ContactId AS Id
                                            ,C.ParentCustomerId AS Account
                                            ,C.ParentCustomerIdName AS AccountName
                                            ,'account' AS AccountTypeName
	                                        ,C.FullName
	                                        ,C.FirstName
	                                        ,C.LastName
                                            ,C.FullName
	                                        ,C.new_username AS UserName
	                                        ,C.new_password AS Password
	                                        ,C.new_firstlogindate AS FirstLoginDate
	                                        ,C.new_idno AS IdNo
	                                        ,C.BirthDate AS BirthDate
	                                        ,C.CustomerTypeCode AS CustomerType
                                            ,C.GenderCode AS Gender
	                                        ,C.MobilePhone
	                                        ,C.new_gsmoperatorid AS GsmOperator
	                                        ,C.new_gsmoperatoridName AS GsmOperatorName
	                                        ,C.Telephone2 AS LandPhone
	                                        ,C.Telephone1 AS WorkPhone
	                                        ,C.Fax
	                                        ,C.EMailAddress1 AS EmailAddress
	                                        ,C.new_universityid AS University
	                                        ,C.new_universityidName AS UniversityName
                                            ,'new_university' AS UniversityTypeName
	                                        ,C.new_companyname AS CompanyName
	                                        ,C.new_taxnumber AS TaxNumber
	                                        ,C.new_taxofficeid AS TaxOffice
	                                        ,C.new_taxofficeidName AS TaxOfficeName
	                                        ,C.new_address AS CompanyAddress
	                                        ,C.new_companyposition AS CompanyPosition
	                                        ,C.new_informedbyid AS InformedBy
	                                        ,C.new_informedbyidName AS InformedByName
	                                        ,C.new_cityid AS City
	                                        ,C.new_cityidName AS CityName
                                            ,'new_city' AS CityTypeName
	                                        ,C.new_educationlevel AS EducationLevel
	                                        ,C.new_iseducator AS IsEducator
	                                        ,C.new_isassociationemployee AS IsAssociationEmployee
	                                        ,C.new_info AS Info
	                                        ,C.StateCode AS State
	                                        ,C.StatusCode AS Status
                                        FROM
	                                        Contact C WITH (NOLOCK)
                                        WHERE
	                                        C.ContactId = @Id";

        #endregion

        #region | GET_CONTACT_LIST |
        public const string GET_CONTACT_LIST = @"SELECT
	                                                C.ContactId AS Id
                                                    ,C.ParentCustomerId AS Account
                                                    ,C.ParentCustomerIdName AS AccountName
                                                    ,'account' AS AccountTypeName
	                                                ,C.FullName
	                                                ,C.FirstName
	                                                ,C.LastName
                                                    ,C.FullName
	                                                ,C.new_username AS UserName
	                                                ,C.new_password AS Password
	                                                ,C.new_firstlogindate AS FirstLoginDate
	                                                ,C.new_idno AS IdNo
	                                                ,C.BirthDate AS BirthDate
                                                    ,C.CustomerTypeCode AS CustomerType
	                                                ,C.GenderCode AS Gender
	                                                ,C.MobilePhone
	                                                ,C.new_gsmoperatorid AS GsmOperator
	                                                ,C.new_gsmoperatoridName AS GsmOperatorName
	                                                ,C.Telephone2 AS LandPhone
	                                                ,C.Telephone1 AS WorkPhone
	                                                ,C.Fax
	                                                ,C.EMailAddress1 AS EmailAddress
	                                                ,C.new_universityid AS University
	                                                ,C.new_universityidName AS UniversityName
	                                                ,C.new_companyname AS CompanyName
	                                                ,C.new_taxnumber AS TaxNumber
	                                                ,C.new_taxofficeid AS TaxOffice
	                                                ,C.new_taxofficeidName AS TaxOfficeName
	                                                ,C.new_address AS CompanyAddress
	                                                ,C.new_companyposition AS CompanyPosition
	                                                ,C.new_informedbyid AS InformedBy
	                                                ,C.new_informedbyidName AS InformedByName
	                                                ,C.new_cityid AS City
	                                                ,C.new_cityidName AS CityName
	                                                ,C.new_educationlevel AS EducationLevel
	                                                ,C.new_iseducator AS IsEducator
	                                                ,C.new_isassociationemployee AS IsAssociationEmployee
	                                                ,C.new_info AS Info
	                                                ,C.StateCode AS State
	                                                ,C.StatusCode AS Status
                                                FROM
	                                                Contact C WITH (NOLOCK)
                                                WHERE
	                                               C.StateCode = 0";

        #endregion

        #region | GET_CONTACT_BY_USERNAME |
        public const string GET_CONTACT_BY_USERNAME = @"SELECT
	                                                C.ContactId AS Id
                                                    ,C.ParentCustomerId AS Account
                                                    ,C.ParentCustomerIdName AS AccountName
                                                    ,'account' AS AccountTypeName
	                                                ,C.FullName As Name
	                                                ,C.FirstName
	                                                ,C.LastName
                                                    ,C.FullName
	                                                ,C.new_username AS UserName
	                                                ,C.new_password AS Password
	                                                ,C.new_firstlogindate AS FirstLoginDate
	                                                ,C.new_idno AS IdNo
	                                                ,C.BirthDate AS BirthDate
                                                    ,C.CustomerTypeCode AS CustomerType
	                                                ,C.GenderCode AS Gender
	                                                ,C.MobilePhone
	                                                ,C.new_gsmoperatorid AS GsmOperator
	                                                ,C.new_gsmoperatoridName AS GsmOperatorName
	                                                ,C.Telephone2 AS LandPhone
	                                                ,C.Telephone1 AS WorkPhone
	                                                ,C.Fax
	                                                ,C.EMailAddress1 AS EmailAddress
	                                                ,C.new_universityid AS University
	                                                ,C.new_universityidName AS UniversityName
	                                                ,C.new_companyname AS CompanyName
	                                                ,C.new_taxnumber AS TaxNumber
	                                                ,C.new_taxofficeid AS TaxOffice
	                                                ,C.new_taxofficeidName AS TaxOfficeName
	                                                ,C.new_address AS CompanyAddress
	                                                ,C.new_companyposition AS CompanyPosition
	                                                ,C.new_informedbyid AS InformedBy
	                                                ,C.new_informedbyidName AS InformedByName
	                                                ,C.new_cityid AS City
	                                                ,C.new_cityidName AS CityName
	                                                ,C.new_educationlevel AS EducationLevel
	                                                ,C.new_iseducator AS IsEducator
	                                                ,C.new_isassociationemployee AS IsAssociationEmployee
	                                                ,C.new_info AS Info
	                                                ,C.StateCode AS State
	                                                ,C.StatusCode AS Status
                                                FROM
	                                                Contact C WITH (NOLOCK)
                                                WHERE
	                                                C.new_username = @userName AND C.StateCode = 0";
        #endregion

        #region | GET_CONTACT_BY_USERNAME_PASSWORD |
        public const string GET_CONTACT_BY_USERNAME_PASSWORD = @"SELECT
	                                                C.ContactId AS Id
                                                    ,C.ParentCustomerId AS Account
                                                    ,C.ParentCustomerIdName AS AccountName
                                                    ,'account' AS AccountTypeName
	                                                ,C.FullName  As Name
	                                                ,C.FirstName
	                                                ,C.LastName
	                                                ,C.new_username AS UserName
	                                                ,C.new_password AS Password
	                                                ,C.new_firstlogindate AS FirstLoginDate
	                                                ,C.new_idno AS IdNo
	                                                ,C.BirthDate AS BirthDate
                                                    ,C.CustomerTypeCode AS CustomerType
	                                                ,C.GenderCode AS Gender
	                                                ,C.MobilePhone
	                                                ,C.new_gsmoperatorid AS GsmOperator
	                                                ,C.new_gsmoperatoridName AS GsmOperatorName
	                                                ,C.Telephone2 AS LandPhone
	                                                ,C.Telephone1 AS WorkPhone
	                                                ,C.Fax
	                                                ,C.EMailAddress1 AS EmailAddress
	                                                ,C.new_universityid AS University
	                                                ,C.new_universityidName AS UniversityName
	                                                ,C.new_companyname AS CompanyName
	                                                ,C.new_taxnumber AS TaxNumber
	                                                ,C.new_taxofficeid AS TaxOffice
	                                                ,C.new_taxofficeidName AS TaxOfficeName
	                                                ,C.new_address AS CompanyAddress
	                                                ,C.new_companyposition AS CompanyPosition
	                                                ,C.new_informedbyid AS InformedBy
	                                                ,C.new_informedbyidName AS InformedByName
	                                                ,C.new_cityid AS City
	                                                ,C.new_cityidName AS CityName
	                                                ,C.new_educationlevel AS EducationLevel
	                                                ,C.new_iseducator AS IsEducator
	                                                ,C.new_isassociationemployee AS IsAssociationEmployee
	                                                ,C.new_info AS Info
	                                                ,C.StateCode AS State
	                                                ,C.StatusCode AS Status
                                                FROM
	                                                Contact C WITH (NOLOCK)
                                                WHERE
	                                                C.new_username = @userName
	                                                AND
	                                                C.new_password = @password 
                                                    AND 
                                                    C.StateCode = 0";
        #endregion
    }
}
