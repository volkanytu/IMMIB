using System;
using System.Collections.Generic;
using SRC.Library.Entities.CrmEntities;

namespace SRC.Library.Data.SqlDao.Interfaces
{
    public interface IEducationAttendanceDao
    {
        List<EducationAttendance> GetEducationAttendances(Guid contactId);
        List<EducationAttendance> GetEducationAttendancesForExpectedPayments();
    }
}