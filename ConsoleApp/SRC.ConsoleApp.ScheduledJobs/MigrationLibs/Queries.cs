using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.ConsoleApp.ScheduledJobs.MigrationLibs
{
    public class Queries
    {
        public static string GET_CITIES = @"SELECT
                                                c.New_cityId AS Id
                                                ,c.New_name AS Name
                                                ,c.New_code AS Code
                                            FROM
                                            New_city AS c
                                            WHERE
                                            c.statecode=0
                                            --AND
                                            --c.New_UlkeIdName='TURKEY' OR c.New_UlkeId IS NULL";

        public static string GET_TOWNS = @"SELECT
                                                c.New_townId AS Id
                                                ,c.New_name AS Name
                                                ,c.New_cityid AS City
                                                ,c.New_cityidName AS CityName
                                                ,'new_city' AS CityTypeName
                                            FROM
                                            New_town AS c
                                            WHERE
                                            c.statecode=0";

        public static string GET_EDUCATION_DEF = @"SELECT
	                                                d.New_activity_definationId AS Id
	                                                ,d.New_name AS Name
                                                FROM
                                                New_activity_defination AS d";

        public static string GET_ASSOCIATIONS = @"SELECT
                                                    i.New_immib_unityId AS Id
                                                    ,i.New_name AS Name
                                                    ,CAST(i.New_birlikkodu AS INT) AS Code
                                                    FROM
                                                    New_immib_unity AS i
                                                    WHERE
                                                    i.statecode=0";

        public static string GET_EDUCATION_LOCATIONS = @"SELECT
                                                        l.New_activity_locationId AS Id
                                                        ,l.New_name AS Name
                                                        FROM
                                                        New_activity_location AS l
                                                        WHERE
                                                        l.statecode=0";

        public static string GET_ACCOUNTS = @"SELECT
                                            acc.AccountId AS Id
                                            ,acc.Name
                                            ,acc.New_cityId AS City
                                            ,acc.New_cityIdName AS CityName
                                            ,'new_city' AS CityTypeName
                                            ,acc.New_is_immib_member AS IsAssociationMember
                                            ,acc.New_Kontrol AS IsChecked
                                            ,acc.New_register_number AS RegistryId
                                            ,acc.WebSiteURL AS WebSite
                                            ,acc.EMailAddress1 AS EmailAddress
                                            ,acc.Fax AS Fax
                                            ,acc.New_tax_office AS TaxOffice
                                            ,acc.New_tax_number AS TaxNumber
                                            ,acc.New_egitim_firmasi_mi AS IsEducationCompany
                                            ,acc.Telephone1 AS LandPhone
                                            ,acc.Telephone2 AS WorkPhone
                                            ,ISNULL(acc.Address1_Name,'') +' ' + ISNULL(acc.Address1_Line1,'') AS Address
                                            FROM
                                            Account AS acc
                                            WHERE
                                            acc.StateCode=0 ORDER BY acc.CreatedOn DESC";
        public static string GET_ACCOUNT_ASSOCIATION = @"SELECT
	                                                        m.New_immib_unityid AS Id
	                                                        ,m.New_immib_unityidName AS Name
	                                                        ,'new_association' AS LogcalName
                                                        FROM
                                                        New_immib_unity_member AS m
                                                        WHERE
                                                        (m.New_durum IS NULL
                                                         OR
                                                         m.New_durum=1
                                                        )
                                                        AND
                                                        m.New_accountid='{0}'";

    }
}
