using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.Library.Constants.SqlQueries
{
    public class EducationAttendenceQueries
    {
        #region | GET_EDUCATION_ATTENDANCE |
        public const string GET_EDUCATION_ATTENDANCE = @"SELECT
	                                                        EA.new_educationattendanceId AS Id
	                                                        ,EA.new_name AS Name
	                                                        ,EA.new_code AS Code
	                                                        ,EA.new_educationid AS Education
	                                                        ,EA.new_educationidName AS EducationName
	                                                        ,EA.new_contactid AS Contact
	                                                        ,EA.new_contactidName AS ContactName
	                                                        ,EA.new_denyinfo AS DenyInfo
	                                                        ,EA.new_isattendanceconfirmed AS IsAttendanceConfirmed
	                                                        ,EA.new_ispaymentdone AS IsPaymentDone
	                                                        ,EA.new_ischargebackdone AS IsChargeBackDone
	                                                        ,EA.new_bankconfirmationcode AS BankConfirmationCode
	                                                        ,EA.new_paymenttype AS PaymentType
	                                                        ,EA.statecode AS State
	                                                        ,EA.statuscode AS Status
                                                        FROM
	                                                        new_educationattendance EA WITH (NOLOCK)
                                                        WHERE
	                                                        EA.new_educationattendanceId = @Id
                                                            AND
	                                                        EA.StateCode = 0";

        #endregion

        #region | GET_EDUCATION_ATTENDANCE_LIST |
        public const string GET_EDUCATION_ATTENDANCE_LIST = @"SELECT
	                                                            EA.new_educationattendanceId AS Id
	                                                            ,EA.new_name AS Name
	                                                            ,EA.new_code AS Code
	                                                            ,EA.new_educationid AS Education
	                                                            ,EA.new_educationidName AS EducationName
	                                                            ,EA.new_contactid AS Contact
	                                                            ,EA.new_contactidName AS ContactName
	                                                            ,EA.new_denyinfo AS DenyInfo
	                                                            ,EA.new_isattendanceconfirmed AS IsAttendanceConfirmed
	                                                            ,EA.new_ispaymentdone AS IsPaymentDone
	                                                            ,EA.new_ischargebackdone AS IsChargeBackDone
	                                                            ,EA.new_bankconfirmationcode AS BankConfirmationCode
	                                                            ,EA.new_paymenttype AS PaymentType
	                                                            ,EA.statecode AS State
	                                                            ,EA.statuscode AS Status
                                                            FROM
	                                                            new_educationattendance EA WITH (NOLOCK)
                                                            WHERE
	                                                            EA.StateCode = 0";

        #endregion

        #region | GET_EDUCATION_ATTENDANCE_LIST_BY_CONTACT |
        public const string GET_EDUCATION_ATTENDANCE_LIST_BY_CONTACT = @"SELECT
	                                                            EA.new_educationattendanceId AS Id
	                                                            ,EA.new_name AS Name
	                                                            ,EA.new_code AS Code
	                                                            ,EA.new_educationid AS Education
	                                                            ,EA.new_educationidName AS EducationName
	                                                            ,EA.new_contactid AS Contact
	                                                            ,EA.new_contactidName AS ContactName
	                                                            ,EA.new_denyinfo AS DenyInfo
	                                                            ,EA.new_isattendanceconfirmed AS IsAttendanceConfirmed
	                                                            ,EA.new_ispaymentdone AS IsPaymentDone
	                                                            ,EA.new_ischargebackdone AS IsChargeBackDone
	                                                            ,EA.new_bankconfirmationcode AS BankConfirmationCode
	                                                            ,EA.new_paymenttype AS PaymentType
	                                                            ,EA.statecode AS State
	                                                            ,EA.statuscode AS Status
                                                            FROM
	                                                            new_educationattendance EA WITH (NOLOCK)
                                                            WHERE
	                                                            EA.new_contactid = @contactId
                                                                AND
                                                                EA.StateCode = 0";

        #endregion

        #region | GET_EDUCATION_EXPECTED_PAYMENT |
        public const string GET_EDUCATION_EXPECTED_PAYMENT = @"SELECT 
	                                                                EA.new_educationattendanceId AS Id
                                                                FROM
	                                                                new_educationattendance EA WITH (NOLOCK)
                                                                INNER JOIN
	                                                                new_education E WITH (NOLOCK)
	                                                                ON
	                                                                E.new_educationId = EA.new_educationid
                                                                WHERE 
	                                                                EA.StateCode = 0
	                                                                AND
	                                                                EA.statuscode = 100000000
	                                                                AND
	                                                                E.statecode = 0
	                                                                AND
	                                                                DATEDIFF(DAY,GETDATE(),DATEADD(DAY,1,E.new_startdate)) <@remainDay";
        #endregion

        #region | GET_EDUCATION_ATTENDANCE_LIST_BY_EDUCATION |
        public const string GET_EDUCATION_ATTENDANCE_LIST_BY_EDUCATION = @"SELECT
	                                                            EA.new_educationattendanceId AS Id
	                                                            ,EA.new_name AS Name
	                                                            ,EA.new_code AS Code
	                                                            ,EA.new_educationid AS Education
	                                                            ,EA.new_educationidName AS EducationName
	                                                            ,EA.new_contactid AS Contact
	                                                            ,EA.new_contactidName AS ContactName
	                                                            ,EA.new_denyinfo AS DenyInfo
	                                                            ,EA.new_isattendanceconfirmed AS IsAttendanceConfirmed
	                                                            ,EA.new_ispaymentdone AS IsPaymentDone
	                                                            ,EA.new_ischargebackdone AS IsChargeBackDone
	                                                            ,EA.new_bankconfirmationcode AS BankConfirmationCode
	                                                            ,EA.new_paymenttype AS PaymentType
	                                                            ,EA.statecode AS State
	                                                            ,EA.statuscode AS Status
                                                            FROM
	                                                            new_educationattendance EA WITH (NOLOCK)
                                                            WHERE
	                                                            EA.StateCode = 0
                                                                AND
                                                                EA.new_educationid = @educationId";


        #endregion

        //TODO: Bu query'ye status code enumları nasıl ekleriz?
        #region GET_EDUCATION_ATTENDANCE_BY_MONTH

        public const string GET_EDUCATION_ATTENDANCE_BY_MONTH = @"DECLARE @StartDate DATETIME = DATEADD(HOUR,-3,DATEADD(month, DATEDIFF(month, 0, @date ), 0))
                                                                    DECLARE @EndDate DATETIME = DATEADD(HOUR,-3,DATEADD(mm, DATEDIFF(m,0,@date )+1,0))

                                                                    SELECT
	                                                                    COUNT(0)
                                                                    FROM
	                                                                    new_educationattendance EA WITH (NOLOCK)
                                                                    WHERE
	                                                                    EA.new_contactid = @contactId
	                                                                    AND
	                                                                    EA.new_educationstartdate BETWEEN @StartDate AND @EndDate
	                                                                    AND
	                                                                    EA.StatusCode IN(100000000,100000001,100000002,100000003,100000004)";
        #endregion
    }
}
