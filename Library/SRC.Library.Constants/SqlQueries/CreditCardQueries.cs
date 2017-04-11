using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.Library.Constants.SqlQueries
{
    public class CreditCardQueries
    {
        #region | GET_CREDIT_CARD |
        public const string GET_CREDIT_CARD = @"SELECT
	                                                CL.new_creditcardlogId AS Id
	                                                ,CL.new_name AS Name
                                                    ,CL.new_educationattendanceid EducationAttendance
                                                    ,CL.new_educationattendanceidName EducationAttendanceName
	                                                ,CL.new_cvc AS Cvc
	                                                ,CL.new_expiremonth AS ExpireMonth
	                                                ,CL.new_expireyear AS ExpireYear
	                                                ,CL.new_amount AS Amount
	                                                ,CL.new_installmenttype AS InstallmentType
	                                                ,CL.new_resultcode AS ResultCode
	                                                ,CL.new_resultmessage AS Result
	                                                ,CL.statecode AS State
	                                                ,CL.statuscode AS Status
                                                FROM
	                                                new_creditcardlog CL WITH (NOLOCK)
                                                WHERE
	                                                CL.new_creditcardlogId = @Id";

        #endregion

        #region | GET_CREDIT_CARD_LIST |
        public const string GET_CREDIT_CARD_LIST = @"SELECT
	                                                    CL.new_creditcardlogId AS Id
	                                                    ,CL.new_name AS Name
                                                        ,CL.new_educationattendanceid EducationAttendance
                                                        ,CL.new_educationattendanceidName EducationAttendanceName
	                                                    ,CL.new_cvc AS Cvc
	                                                    ,CL.new_expiremonth AS ExpireMonth
	                                                    ,CL.new_expireyear AS ExpireYear
	                                                    ,CL.new_amount AS Amount
	                                                    ,CL.new_installmenttype AS InstallmentType
	                                                    ,CL.new_resultcode AS ResultCode
	                                                    ,CL.new_resultmessage AS Result
	                                                    ,CL.statecode AS State
	                                                    ,CL.statuscode AS Status
                                                    FROM
	                                                    new_creditcardlog CL WITH (NOLOCK) 
                                                    WHERE
	                                                    CL.StateCode = 0";

        #endregion
    }
}
