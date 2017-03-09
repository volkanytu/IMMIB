using System;
using System.Collections.Generic;
using SRC.Library.Entities.CrmEntities;

namespace SRC.Library.Domain.Business.Interfaces
{
    public interface IEducationBusiness
    {
        List<Education> GetEducations(DateTime startDate, DateTime endDate);
        List<Education> GetEducationsOfAttendances(List<EducationAttendance> educationAttendanceList);
        List<Education> GetLastEducations();
        string GetEducationCode();
    }
}