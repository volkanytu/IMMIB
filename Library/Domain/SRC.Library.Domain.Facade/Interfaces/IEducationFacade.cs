using System;
using System.Collections.Generic;
using SRC.Library.Entities.CrmEntities;

namespace SRC.Library.Domain.Facade.Interfaces
{
    public interface IEducationFacade
    {
        List<Education> GetEducations(int? month, int? year, Guid? associationId = null);
        List<Education> GetEducationsOfAttendances(List<EducationAttendance> attendances);
        List<EducationAttendance> GetContactAttendances(Guid? contactId);
        Guid CreateEducationAttendance(EducationAttendance educationAttendance);
        void CancelEducationAttendance(Guid? educationAttendanceId);
        Guid CreateCreditCard(CreditCardLog creditCard);
        void SetEducationAttendance(List<Education> educations, List<EducationAttendance> educationAttendances);
        void SetEducationAttendance(Education education, List<EducationAttendance> educationAttendances);
        List<Education> GetDoneEducationList(Guid? associationId = null);
        List<Education> GetComingEducationList(Guid? associationId = null);
    }
}