using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.Library.Constants.SqlQueries
{
    public class SmsQueries
    {
        #region | GET_SMS |
        public const string GET_SMS = @"SELECT
	                                        S.new_smsId AS Id
	                                        ,S.new_name AS [Name]
	                                        ,S.new_contactid AS Contact
	                                        ,S.new_contactidName AS ContactName
	                                        ,S.new_messagestate AS MessageState
	                                        ,S.new_phonenumber AS PhoneNumber
	                                        ,S.new_message AS [Message]
	                                        ,S.statecode AS State
	                                        ,S.statuscode AS Status
                                        FROM
	                                        new_sms S WITH (NOLOCK)
                                        WHERE
	                                        S.new_smsId = '{0}'";

        #endregion

        #region | GET_SMS_LIST |
        public const string GET_SMS_LIST = @"SELECT
	                                            S.new_smsId AS Id
	                                            ,S.new_name AS [Name]
	                                            ,S.new_contactid AS Contact
	                                            ,S.new_contactidName AS ContactName
	                                            ,S.new_messagestate AS MessageState
	                                            ,S.new_phonenumber AS PhoneNumber
	                                            ,S.new_message AS [Message]
	                                            ,S.statecode AS State
	                                            ,S.statuscode AS Status
                                            FROM
	                                            new_sms S WITH (NOLOCK)
                                            WHERE
	                                            S.statecode = 0
	                                            AND
	                                            S.statuscode = 100000000";

        #endregion
    }
}
