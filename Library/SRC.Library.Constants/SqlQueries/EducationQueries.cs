﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.Library.Constants.SqlQueries
{
    public class EducationQueries
    {
        #region | GET_EDUCATION |
        public const string GET_EDUCATION = @"SELECT
	                                            ED.new_educationId AS Id
                                                ,ED.new_name AS Name
	                                            ,ED.new_code AS Code
	                                            ,ED.new_educationdefinitionid AS EducationDefinition
	                                            ,ED.new_educationdefinitionidName AS EducationDefinitionName
	                                            ,ED.new_contactid AS Contact
	                                            ,ED.new_contactidName AS ContactName
	                                            ,ED.new_educationtype AS EducationType
                                                ,ED.new_educationamount AS EducationAmount
	                                            ,ED.new_quota AS Quota
	                                            ,ED.new_leftquota AS LeftQuota
                                                ,ED.new_studentquota AS StudentQuota
	                                            ,ED.new_studentleftquota AS StudentLeftQuota
	                                            ,ED.new_islimitedbysingleattend AS IsLimitedBySingleAttend
	                                            ,ED.new_maxsingleattendcount AS MaxSingleAttendCount
	                                            ,ED.new_ispaid AS IsPaid
	                                            ,ED.new_ispaymentreturnoncancel AS IsPaymentReturnOnCancel
	                                            ,ED.new_educationprice AS EducationPrice
	                                            ,ED.new_isstudentcanattend AS IsStudentCanAttend
	                                            ,ED.new_cityid AS City
	                                            ,ED.new_cityidName AS CityName
	                                            ,ED.new_townid AS Town
	                                            ,ED.new_townidName AS TownName
	                                            ,ED.new_educationlocationid AS EducationLocation
	                                            ,ED.new_educationlocationidName AS EducationLocationName
	                                            ,DATEADD(HOUR,3,ED.new_startdate) AS StartDate
	                                            ,DATEADD(HOUR,3,ED.new_enddate) AS EndDate
	                                            ,DATEADD(HOUR,3,ED.new_recordstartdate) AS RecordStartDate
	                                            ,DATEADD(HOUR,3,ED.new_recordenddate) AS RecordEndDate
	                                            ,ED.new_educationperiod AS EducationPeriod
	                                            ,ED.new_info AS Info
	                                            ,ED.statecode AS State
	                                            ,ED.statuscode AS Status
                                            FROM
	                                            new_education ED WITH (NOLOCK)
                                            WHERE
	                                            ED.new_educationId = @Id";

        #endregion

        #region | GET_EDUCATION_LIST |
        public const string GET_EDUCATION_LIST = @"SELECT
	                                                ED.new_educationId AS Id
                                                    ,ED.new_name AS Name
	                                                ,ED.new_code AS Code
	                                                ,ED.new_educationdefinitionid AS EducationDefinition
	                                                ,ED.new_educationdefinitionidName AS EducationDefinitionName
	                                                ,ED.new_contactid AS Contact
	                                                ,ED.new_contactidName AS ContactName
	                                                ,ED.new_educationtype AS EducationType
                                                    ,ED.new_educationamount AS EducationAmount
	                                                ,ED.new_quota AS Quota
                                                    ,ED.new_studentquota AS StudentQuota
	                                                ,ED.new_studentleftquota AS StudentLeftQuota
	                                                ,ED.new_leftquota AS LeftQuota
	                                                ,ED.new_islimitedbysingleattend AS IsLimitedBySingleAttend
	                                                ,ED.new_maxsingleattendcount AS MaxSingleAttendCount
	                                                ,ED.new_ispaid AS IsPaid
	                                                ,ED.new_ispaymentreturnoncancel AS IsPaymentReturnOnCancel
	                                                ,ED.new_educationprice AS EducationPrice
	                                                ,ED.new_isstudentcanattend AS IsStudentCanAttend
	                                                ,ED.new_cityid AS City
	                                                ,ED.new_cityidName AS CityName
	                                                ,ED.new_townid AS Town
	                                                ,ED.new_townidName AS TownName
	                                                ,ED.new_educationlocationid AS EducationLocation
	                                                ,ED.new_educationlocationidName AS EducationLocationName
	                                                ,ED.new_startdate AS StartDate
	                                                ,ED.new_enddate AS EndDate
	                                                ,ED.new_recordstartdate AS RecordStartDate
	                                                ,ED.new_recordenddate AS RecordEndDate
	                                                ,ED.new_educationperiod AS EducationPeriod
	                                                ,ED.new_info AS Info
	                                                ,ED.statecode AS State
	                                                ,ED.statuscode AS Status
                                                FROM
	                                                new_education ED WITH (NOLOCK)
                                                WHERE
	                                                ED.StateCode = 0";

        #endregion

        #region | GET_EDUCATION_LIST_BY_START_DATE |
        public const string GET_EDUCATION_LIST_BY_START_DATE = @"SELECT
	                                                ED.new_educationId AS Id
                                                    ,ED.new_name AS Name
	                                                ,ED.new_code AS Code
	                                                ,ED.new_educationdefinitionid AS EducationDefinition
	                                                ,ED.new_educationdefinitionidName AS EducationDefinitionName
	                                                ,ED.new_contactid AS Contact
	                                                ,ED.new_contactidName AS ContactName
	                                                ,ED.new_educationtype AS EducationType
                                                    ,ED.new_educationamount AS EducationAmount
	                                                ,ED.new_quota AS Quota
	                                                ,ED.new_leftquota AS LeftQuota
                                                    ,ED.new_studentquota AS StudentQuota
	                                                ,ED.new_studentleftquota AS StudentLeftQuota
	                                                ,ED.new_islimitedbysingleattend AS IsLimitedBySingleAttend
	                                                ,ED.new_maxsingleattendcount AS MaxSingleAttendCount
	                                                ,ED.new_ispaid AS IsPaid
	                                                ,ED.new_ispaymentreturnoncancel AS IsPaymentReturnOnCancel
	                                                ,ED.new_educationprice AS EducationPrice
	                                                ,ED.new_isstudentcanattend AS IsStudentCanAttend
	                                                ,ED.new_cityid AS City
	                                                ,ED.new_cityidName AS CityName
	                                                ,ED.new_townid AS Town
	                                                ,ED.new_townidName AS TownName
	                                                ,ED.new_educationlocationid AS EducationLocation
	                                                ,ED.new_educationlocationidName AS EducationLocationName
	                                                ,DATEADD(HOUR,3,ED.new_startdate) AS StartDate
	                                                ,DATEADD(HOUR,3,ED.new_enddate) AS EndDate
	                                                ,DATEADD(HOUR,3,ED.new_recordstartdate) AS RecordStartDate
	                                                ,DATEADD(HOUR,3,ED.new_recordenddate) AS RecordEndDate
	                                                ,ED.new_educationperiod AS EducationPeriod
	                                                ,ED.new_info AS Info
	                                                ,ED.statecode AS State
	                                                ,ED.statuscode AS Status
                                                FROM
	                                                new_education ED WITH (NOLOCK)
                                                WHERE
                                                    ED.new_startdate BETWEEN @startDate AND @endDate
                                                    AND
	                                                ED.StateCode = 0
                                                ORDER BY 
                                                    ED.new_startdate";

        #endregion

        #region | GET_EDUCATION_LIST_COMING_DONE |
        public const string GET_EDUCATION_LIST_COMING_DONE = @"SELECT
                                                    TOP 50
	                                                ED.new_educationId AS Id
                                                    ,ED.new_name AS Name
	                                                ,ED.new_code AS Code
	                                                ,ED.new_educationdefinitionid AS EducationDefinition
	                                                ,ED.new_educationdefinitionidName AS EducationDefinitionName
	                                                ,ED.new_contactid AS Contact
	                                                ,ED.new_contactidName AS ContactName
	                                                ,ED.new_educationtype AS EducationType
                                                    ,ED.new_educationamount AS EducationAmount
	                                                ,ED.new_quota AS Quota
	                                                ,ED.new_leftquota AS LeftQuota
                                                    ,ED.new_studentquota AS StudentQuota
	                                                ,ED.new_studentleftquota AS StudentLeftQuota
	                                                ,ED.new_islimitedbysingleattend AS IsLimitedBySingleAttend
	                                                ,ED.new_maxsingleattendcount AS MaxSingleAttendCount
	                                                ,ED.new_ispaid AS IsPaid
	                                                ,ED.new_ispaymentreturnoncancel AS IsPaymentReturnOnCancel
	                                                ,ED.new_educationprice AS EducationPrice
	                                                ,ED.new_isstudentcanattend AS IsStudentCanAttend
	                                                ,ED.new_cityid AS City
	                                                ,ED.new_cityidName AS CityName
	                                                ,ED.new_townid AS Town
	                                                ,ED.new_townidName AS TownName
	                                                ,ED.new_educationlocationid AS EducationLocation
	                                                ,ED.new_educationlocationidName AS EducationLocationName
	                                                ,DATEADD(HOUR,3,ED.new_startdate) AS StartDate
	                                                ,DATEADD(HOUR,3,ED.new_enddate) AS EndDate
	                                                ,DATEADD(HOUR,3,ED.new_recordstartdate) AS RecordStartDate
	                                                ,DATEADD(HOUR,3,ED.new_recordenddate) AS RecordEndDate
	                                                ,ED.new_educationperiod AS EducationPeriod
	                                                ,ED.new_info AS Info
	                                                ,ED.statecode AS State
	                                                ,ED.statuscode AS Status
                                                FROM
	                                                new_education ED WITH (NOLOCK)
                                                WHERE
	                                                ED.StateCode = 0 ORDER BY ED.new_enddate DESC";

        #endregion

        #region | GET_EDUCATION_LIST_OF_ATTENDANCES |
        public const string GET_EDUCATION_LIST_OF_ATTENDANCES = @"SELECT
	                                                ED.new_educationId AS Id
                                                    ,ED.new_name AS Name
	                                                ,ED.new_code AS Code
	                                                ,ED.new_educationdefinitionid AS EducationDefinition
	                                                ,ED.new_educationdefinitionidName AS EducationDefinitionName
	                                                ,ED.new_contactid AS Contact
	                                                ,ED.new_contactidName AS ContactName
	                                                ,ED.new_educationtype AS EducationType
                                                    ,ED.new_educationamount AS EducationAmount
	                                                ,ED.new_quota AS Quota
	                                                ,ED.new_leftquota AS LeftQuota
                                                    ,ED.new_studentquota AS StudentQuota
	                                                ,ED.new_studentleftquota AS StudentLeftQuota
	                                                ,ED.new_islimitedbysingleattend AS IsLimitedBySingleAttend
	                                                ,ED.new_maxsingleattendcount AS MaxSingleAttendCount
	                                                ,ED.new_ispaid AS IsPaid
	                                                ,ED.new_ispaymentreturnoncancel AS IsPaymentReturnOnCancel
	                                                ,ED.new_educationprice AS EducationPrice
	                                                ,ED.new_isstudentcanattend AS IsStudentCanAttend
	                                                ,ED.new_cityid AS City
	                                                ,ED.new_cityidName AS CityName
	                                                ,ED.new_townid AS Town
	                                                ,ED.new_townidName AS TownName
	                                                ,ED.new_educationlocationid AS EducationLocation
	                                                ,ED.new_educationlocationidName AS EducationLocationName
	                                                ,DATEADD(HOUR,3,ED.new_startdate) AS StartDate
	                                                ,DATEADD(HOUR,3,ED.new_enddate) AS EndDate
	                                                ,DATEADD(HOUR,3,ED.new_recordstartdate) AS RecordStartDate
	                                                ,DATEADD(HOUR,3,ED.new_recordenddate) AS RecordEndDate
	                                                ,ED.new_educationperiod AS EducationPeriod
	                                                ,ED.new_info AS Info
	                                                ,ED.statecode AS State
	                                                ,ED.statuscode AS Status
                                                FROM
	                                                new_education ED WITH (NOLOCK)
                                                INNER JOIN
													new_educationattendance EA WITH (NOLOCK)
													ON
													ED.new_educationId = EA.new_educationid
                                                WHERE
													EA.new_educationattendanceId IN({0}) ";
        #endregion

        #region | GET_EDUCATION_CODE_MAX_VALUE |
        public const string GET_EDUCATION_CODE_MAX_VALUE = @"SELECT
	                                                                MAX(ED.new_educationcodevalue)
                                                                FROM
	                                                                new_education ED WITH (NOLOCK)";
        #endregion

    }
}
