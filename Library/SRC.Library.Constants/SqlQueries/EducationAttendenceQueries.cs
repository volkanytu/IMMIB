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
    }
}
