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
	                                        ,C.FullName
	                                        ,C.FirstName
	                                        ,C.LastName
	                                        ,C.new_username AS UserName
	                                        ,C.new_password AS Password
	                                        ,C.new_firstlogindate AS FirstLoginDate
	                                        ,C.new_idno AS IdNo
	                                        ,C.BirthDate AS BirthDate
	                                        ,C.GenderCode AS Gender
	                                        ,C.MobilePhone
	                                        ,C.new_gsmoperatorid AS GsmOperatorId
	                                        ,C.new_gsmoperatoridName AS GsmOperatorIdName
	                                        ,C.Telephone2 AS LandPhone
	                                        ,C.Telephone1 AS WorkPhone
	                                        ,C.Fax
	                                        ,C.EMailAddress1 AS EmailAddress
	                                        ,C.new_universityid AS UniversityId
	                                        ,C.new_universityidName AS UniversityIdName
	                                        ,C.new_companyname AS CompanyName
	                                        ,C.new_taxnumber AS TaxNumber
	                                        ,C.new_taxofficeid AS TaxOfficeId
	                                        ,C.new_taxofficeidName AS TaxOfficeIdName
	                                        ,C.new_address AS CompanyAddress
	                                        ,C.new_companyposition AS CompanyPosition
	                                        ,C.new_informedbyid AS InformedById
	                                        ,C.new_informedbyidName AS InformedByIdName
	                                        ,C.new_cityid AS CityId
	                                        ,C.new_cityidName AS CityIdName
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
	                                                ,C.FullName
	                                                ,C.FirstName
	                                                ,C.LastName
	                                                ,C.new_username AS UserName
	                                                ,C.new_password AS Password
	                                                ,C.new_firstlogindate AS FirstLoginDate
	                                                ,C.new_idno AS IdNo
	                                                ,C.BirthDate AS BirthDate
	                                                ,C.GenderCode AS Gender
	                                                ,C.MobilePhone
	                                                ,C.new_gsmoperatorid AS GsmOperatorId
	                                                ,C.new_gsmoperatoridName AS GsmOperatorIdName
	                                                ,C.Telephone2 AS LandPhone
	                                                ,C.Telephone1 AS WorkPhone
	                                                ,C.Fax
	                                                ,C.EMailAddress1 AS EmailAddress
	                                                ,C.new_universityid AS UniversityId
	                                                ,C.new_universityidName AS UniversityIdName
	                                                ,C.new_companyname AS CompanyName
	                                                ,C.new_taxnumber AS TaxNumber
	                                                ,C.new_taxofficeid AS TaxOfficeId
	                                                ,C.new_taxofficeidName AS TaxOfficeIdName
	                                                ,C.new_address AS CompanyAddress
	                                                ,C.new_companyposition AS CompanyPosition
	                                                ,C.new_informedbyid AS InformedById
	                                                ,C.new_informedbyidName AS InformedByIdName
	                                                ,C.new_cityid AS CityId
	                                                ,C.new_cityidName AS CityIdName
	                                                ,C.new_educationlevel AS EducationLevel
	                                                ,C.new_iseducator AS IsEducator
	                                                ,C.new_isassociationemployee AS IsAssociationEmployee
	                                                ,C.new_info AS Info
	                                                ,C.StateCode AS State
	                                                ,C.StatusCode AS Status
                                                FROM
	                                                Contact C WITH (NOLOCK)";

        #endregion

        #region | GET_CONTACT_BY_USERNAME |
        public const string GET_CONTACT_BY_USERNAME = @"SELECT
	                                                C.ContactId AS Id
	                                                ,C.FullName
	                                                ,C.FirstName
	                                                ,C.LastName
	                                                ,C.new_username AS UserName
	                                                ,C.new_password AS Password
	                                                ,C.new_firstlogindate AS FirstLoginDate
	                                                ,C.new_idno AS IdNo
	                                                ,C.BirthDate AS BirthDate
	                                                ,C.GenderCode AS Gender
	                                                ,C.MobilePhone
	                                                ,C.new_gsmoperatorid AS GsmOperatorId
	                                                ,C.new_gsmoperatoridName AS GsmOperatorIdName
	                                                ,C.Telephone2 AS LandPhone
	                                                ,C.Telephone1 AS WorkPhone
	                                                ,C.Fax
	                                                ,C.EMailAddress1 AS EmailAddress
	                                                ,C.new_universityid AS UniversityId
	                                                ,C.new_universityidName AS UniversityIdName
	                                                ,C.new_companyname AS CompanyName
	                                                ,C.new_taxnumber AS TaxNumber
	                                                ,C.new_taxofficeid AS TaxOfficeId
	                                                ,C.new_taxofficeidName AS TaxOfficeIdName
	                                                ,C.new_address AS CompanyAddress
	                                                ,C.new_companyposition AS CompanyPosition
	                                                ,C.new_informedbyid AS InformedById
	                                                ,C.new_informedbyidName AS InformedByIdName
	                                                ,C.new_cityid AS CityId
	                                                ,C.new_cityidName AS CityIdName
	                                                ,C.new_educationlevel AS EducationLevel
	                                                ,C.new_iseducator AS IsEducator
	                                                ,C.new_isassociationemployee AS IsAssociationEmployee
	                                                ,C.new_info AS Info
	                                                ,C.StateCode AS State
	                                                ,C.StatusCode AS Status
                                                FROM
	                                                Contact C WITH (NOLOCK)
                                                WHERE
	                                                C.new_username = @userName";
        #endregion

        #region | GET_CONTACT_BY_USERNAME_PASSWORD |
        public const string GET_CONTACT_BY_USERNAME_PASSWORD = @"SELECT
	                                                C.ContactId AS Id
	                                                ,C.FullName
	                                                ,C.FirstName
	                                                ,C.LastName
	                                                ,C.new_username AS UserName
	                                                ,C.new_password AS Password
	                                                ,C.new_firstlogindate AS FirstLoginDate
	                                                ,C.new_idno AS IdNo
	                                                ,C.BirthDate AS BirthDate
	                                                ,C.GenderCode AS Gender
	                                                ,C.MobilePhone
	                                                ,C.new_gsmoperatorid AS GsmOperatorId
	                                                ,C.new_gsmoperatoridName AS GsmOperatorIdName
	                                                ,C.Telephone2 AS LandPhone
	                                                ,C.Telephone1 AS WorkPhone
	                                                ,C.Fax
	                                                ,C.EMailAddress1 AS EmailAddress
	                                                ,C.new_universityid AS UniversityId
	                                                ,C.new_universityidName AS UniversityIdName
	                                                ,C.new_companyname AS CompanyName
	                                                ,C.new_taxnumber AS TaxNumber
	                                                ,C.new_taxofficeid AS TaxOfficeId
	                                                ,C.new_taxofficeidName AS TaxOfficeIdName
	                                                ,C.new_address AS CompanyAddress
	                                                ,C.new_companyposition AS CompanyPosition
	                                                ,C.new_informedbyid AS InformedById
	                                                ,C.new_informedbyidName AS InformedByIdName
	                                                ,C.new_cityid AS CityId
	                                                ,C.new_cityidName AS CityIdName
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
	                                                C.new_password = @password";
        #endregion
    }
}
