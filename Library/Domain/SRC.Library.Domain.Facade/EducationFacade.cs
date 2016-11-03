using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRC.Library.Constants.LogKey;
using SRC.Library.Domain.Business.Interfaces;
using SRC.Library.Entities;
using SRC.Library.Entities.CrmEntities;

namespace SRC.Library.Domain.Facade
{
    public class EducationFacade
    {
        private IEducationBusiness _educationBusiness;
        private IEducationAttendanceBusiness _educationAttendanceBusiness;

        public EducationFacade(IEducationBusiness educationBusiness, IEducationAttendanceBusiness educationAttendanceBusiness)
        {
            _educationBusiness = educationBusiness;
            _educationAttendanceBusiness = educationAttendanceBusiness;
        }

        public List<Education> GetEducations(int? month, int? year)
        {
            month.CheckNull("Ay boş olamaz!", EducationLogKeys.MONTH_NULL);
            month.CheckNull("Yıl boş olamaz!", EducationLogKeys.YEAR_NULL);

            DateTime startDate = new DateTime((int)year, (int)month, 1);
            DateTime endDate = startDate.AddMonths(1);

            return _educationBusiness.GetEducations(startDate, endDate);
        }

        public List<EducationAttendance> GetEducationAttendances(Guid? contactId)
        {
            contactId.CheckNull("Üye bilgisi boş olamaz!", ContactLogKeys.CONTACT_NULL);

            return _educationAttendanceBusiness.GetEducations((Guid)contactId);
        }
    }
}
