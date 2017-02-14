using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRC.Library.Data.SqlDao;
using SRC.Library.Data.SqlDao.Interfaces;
using SRC.Library.Domain.Business.Interfaces;
using SRC.Library.Entities.CrmEntities;

namespace SRC.Library.Domain.Business
{
    public class EducationAttendanceBusiness : IEducationAttendanceBusiness
    {
        private IEducationAttendanceDao _educationAttendanceDao;

        public EducationAttendanceBusiness(IEducationAttendanceDao educationAttendanceDao)
        {
            _educationAttendanceDao = educationAttendanceDao;
        }

        public List<EducationAttendance> GetEducations(Guid contactId)
        {
            return _educationAttendanceDao.GetEducationAttendances(contactId);
        }

        public List<EducationAttendance> GetEducationAttendancesForExpectedPayments(int remainDay)
        {
            return _educationAttendanceDao.GetEducationAttendancesForExpectedPayments(remainDay);
        }
    }
}
