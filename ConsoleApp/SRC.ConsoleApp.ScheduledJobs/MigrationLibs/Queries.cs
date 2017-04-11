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

        public static string GET_CONTACTS = @"SELECT
                                                --COUNT(0)
                                                c.ContactId AS Id
                                                ,c.FullName AS Name
                                                ,c.FirstName
                                                ,c.LastName
                                                ,u.New_name AS UserName
                                                ,u.New_pass AS [Password]
                                                ,c.New_tc_kimlik_no AS IdNo
                                                ,c.BirthDate
                                                ,c.GenderCode AS Gender
                                                ,CASE 
	                                                WHEN c.CustomerTypeCode=200000 THEN 2
	                                                WHEN c.CustomerTypeCode=200001 THEN 1 END AS CustomerType
                                                ,c.MobilePhone
                                                ,c.Fax
                                                ,c.Telephone1 AS WorkPhone
                                                ,c.Telephone2 AS LandPhone
                                                ,c.EMailAddress1 AS EmailAddress
                                                ,c.New_occupationposition AS CompanyPosition
                                                ,c.new_cityid AS City
                                                ,c.new_cityidName AS CityName
                                                ,'new_city' AS CityTypeName
                                                ,c.New_is_instructor AS IsEducator
                                                ,c.New_is_immib_employee AS IsAssociationEmployee
                                                ,c.ParentCustomerId AS ParentCustomer
                                                ,c.ParentCustomerIdName AS ParentCustomerName
                                                ,'account' AS ParentCustomerTypeName
                                                ,u.New_first_logindate AS FirstLoginDate
                                                ,c.New_cv AS Info
                                            FROM
                                            Contact AS c
	                                            LEFT JOIN
		                                            New_user AS u
			                                            ON
			                                            c.ContactId=u.new_contactid
                                            WHERE
                                            c.StateCode=0";

        public static string GET_EDUCATIONS = @"SELECT
	                                                e.New_activityId AS Id
	                                                ,e.New_name AS Name
	                                                ,e.New_activity_code AS Code
	                                                ,e.new_activity_definationid AS EducationDefinition
	                                                ,e.new_activity_definationidName AS EducationDefinitionName
	                                                ,'new_educationdefinition' AS EducationDefinitionTypeName
	                                                ,e.New_instructor_contactid AS Contact
	                                                ,e.New_instructor_contactidName AS ContactName
	                                                ,'contact' AS ContactTypeName
	                                                ,CASE WHEN e.New_activity_type=0 THEN 1 ELSE 2 END AS EducationType
	                                                ,e.New_activity_charge AS EducationAmount
	                                                ,e.New_quota AS Quota
	                                                ,e.New_left_quota AS LeftQuota
	                                                ,e.New_is_participant_per_invitation_limited AS  IsLimitedBySingleAttend
	                                                ,e.New_max_numberof_participant_per_intivitation AS MaxSingleAttendCount
	                                                ,e.New_is_paid_return_due_to_cancellation AS IsPaymentReturnOnCancel
	                                                ,e.New_is_activity_paid AS IsPaid
	                                                ,e.New_activity_charge AS EducationPrice
	                                                ,e.New_student_can_be_participated AS IsStudentCanAttend
	                                                ,e.new_cityid AS City
	                                                ,e.new_cityidName AS CityName
	                                                ,'new_city' AS CityTypeName
	                                                ,e.new_townid AS Town
	                                                ,e.new_townidName AS TownName
	                                                ,'new_town' AS TownTypeName
	                                                ,e.New_activity_locationid AS EducationLocation 
	                                                ,e.New_activity_locationidName AS EducationLocationName
	                                                ,'new_educationlocation' AS EducationLocationTypeName
	                                                ,e.New_activity_actuelstart_date AS StartDate
	                                                ,e.New_activity_actuelend_date AS EndDate
	                                                ,e.New_registration_startdate AS RecordStartDate
	                                                ,e.New_registration_enddate AS RecordEndDate
	                                                ,e.New_activity_duration AS EducationPeriod
	                                                ,e.New_defination_details AS Info
                                            FROM
                                            New_activity AS e
                                            WHERE
                                            e.statecode=0";

        public static string GET_EDUCATION_ASSOCIATIONS = @"SELECT
	                                                            p.New_immib_unityid AS Id
	                                                            ,p.New_immib_unityidName AS Name
	                                                            ,'new_association' AS LogicalName
                                                            FROM
                                                            New_activity_attendee_permission AS p
                                                            WHERE
                                                            p.New_activityid='{0}'";

        public static string GET_EDUCATION_ATTENDANCE = @"SELECT
	                                                        a.New_activity_attendeesId AS Id
	                                                        ,a.New_name AS Name
	                                                        ,a.New_name AS Code
	                                                        ,a.new_activityid AS Education
	                                                        ,a.new_activityidName AS EducationName
	                                                        ,'new_education' AS EducationTypeName
	                                                        ,a.new_contactid AS Contact
	                                                        ,a.new_contactidName AS ContactName
	                                                        ,'contact' AS ContactTypeName
	                                                        ,a.New_katilim_onayi_var_mi AS IsAttendanceConfirmed
	                                                        ,a.New_payment_success AS IsPaymentDone
	                                                        ,a.New_paraiadesiyapildi AS IsChargeBackDone
	                                                        ,a.New_bankaonaykodu AS BankConfirmationCode
	                                                        ,a.New_payment_type AS PaymentType
	                                                        ,CASE
		                                                        WHEN a.New_participation_status=1 THEN 100000000
		                                                        WHEN a.New_participation_status=2 THEN 100000001
		                                                        WHEN a.New_participation_status=8 THEN 100000002
		                                                        WHEN a.New_participation_status=3 THEN 100000003
		                                                        WHEN a.New_participation_status=4 THEN 100000004
		                                                        WHEN a.New_participation_status=5 THEN 100000005
		                                                        WHEN a.New_participation_status=6 THEN 100000006
		                                                        WHEN a.New_participation_status=7 THEN 100000007
	                                                        END AS [Status]
                                                    FROM
                                                    New_activity_attendees AS a
                                                    WHERE
                                                    a.statecode=0";

        public static string GET_CREDIT_CARD_LOGS = @"SELECT
                                                        k.New_kredikartiloguId AS Id
                                                        ,k.New_name AS Name
                                                        ,k.New_kartsahibi AS FullName
                                                        ,k.New_kartno AS CardNumber
                                                        ,k.New_cvcno AS Cvc
                                                        ,k.New_sonkullanmatarihiay AS ExpireMonth
                                                        ,k.New_sonkullanmatarihiyil AS ExpireYear
                                                        ,k.New_tutar AS Amount
                                                        ,k.New_taksitturu AS InstallmentType
                                                        ,k.New_kod AS ResultCode
                                                        ,k.New_mesaj AS Result
                                                    FROM
                                                    New_kredikartilogu AS k
                                                    WHERE
                                                    k.statecode=0";

    }
}
