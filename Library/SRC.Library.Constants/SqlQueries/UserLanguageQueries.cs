using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.Library.Constants.SqlQueries
{
    public class UserLanguageQueries
    {
        #region | GET_USER_LANGUAGE |
        public const string GET_USER_LANGUAGE = @"SELECT
	                                                UL.new_userlanguageId AS Id
	                                                ,UL.new_name AS Name
	                                                ,UL.new_contactid AS Contact
	                                                ,UL.new_contactidName AS ContactName
	                                                ,UL.new_languageid AS Language
	                                                ,UL.new_languageidName AS LanguageName
	                                                ,UL.new_level AS Level
	                                                ,UL.statecode AS State
	                                                ,UL.statuscode AS Status
                                                FROM
	                                                new_userlanguage UL WITH (NOLOCK)
                                                WHERE
	                                                UL.new_userlanguageId = @Id
                                                    AND
                                                    UL.statecode = 0";
        #endregion

        #region | GET_USER_LANGUAGE_LIST |
        public const string GET_USER_LANGUAGE_LIST = @"SELECT
	                                                    UL.new_userlanguageId AS Id
	                                                    ,UL.new_name AS Name
	                                                    ,UL.new_contactid AS Contact
	                                                    ,UL.new_contactidName AS ContactName
	                                                    ,UL.new_languageid AS Language
	                                                    ,UL.new_languageidName AS LanguageName
	                                                    ,UL.new_level AS Level
	                                                    ,UL.statecode AS State
	                                                    ,UL.statuscode AS Status
                                                    FROM
	                                                    new_userlanguage UL WITH (NOLOCK) 
                                                        AND
                                                        UL.statecode = 0";
        #endregion

        #region | GET_CONTACT_USER_LANGUAGE_LIST |
        public const string GET_CONTACT_USER_LANGUAGE_LIST = @"SELECT
	                                                            UL.new_userlanguageId AS Id
	                                                            ,UL.new_name AS Name
	                                                            ,UL.new_contactid AS Contact
	                                                            ,UL.new_contactidName AS ContactName
	                                                            ,UL.new_languageid AS Language
	                                                            ,UL.new_languageidName AS LanguageName
	                                                            ,UL.new_level AS Level
	                                                            ,UL.statecode AS State
	                                                            ,UL.statuscode AS Status
                                                            FROM
	                                                            new_userlanguage UL WITH (NOLOCK)
                                                            WHERE
	                                                            UL.new_contactid = @contactId
	                                                            AND
	                                                            UL.statecode = 0";
        #endregion
    }
}
