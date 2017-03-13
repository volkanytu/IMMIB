using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRC.Library.Data.SqlDao;
using SRC.Library.Data.SqlDao.Interfaces;
using SRC.Library.Domain.Business.Interfaces;
using SRC.Library.Entities.CrmEntities;
using SRC.Library.Data.Interfaces;

namespace SRC.Library.Domain.Business
{
    public class EducationAttendanceBusiness : IEducationAttendanceBusiness
    {
        private IEducationAttendanceDao _educationAttendanceDao;
        private IBaseDao<EducationAttendance> _educationAttendanceBaseDao;

        public EducationAttendanceBusiness(IEducationAttendanceDao educationAttendanceDao, IBaseDao<EducationAttendance> educationAttendanceBaseDao)
        {
            _educationAttendanceDao = educationAttendanceDao;
            _educationAttendanceBaseDao = educationAttendanceBaseDao;
        }

        public List<EducationAttendance> GetEducations(Guid contactId)
        {
            return _educationAttendanceDao.GetEducationAttendances(contactId);
        }

        public List<EducationAttendance> GetEducationAttendancesForExpectedPayments(int remainDay)
        {
            return _educationAttendanceDao.GetEducationAttendancesForExpectedPayments(remainDay);
        }

        public List<EducationAttendance> GetEducationAttendancesForEducation(Guid educationId)
        {
            return _educationAttendanceDao.GetEducationAttendancesForEducation(educationId);
        }

        public void CancelAllEducationAttendaces(Guid educationId)
        {
            var attendanceList = this.GetEducationAttendancesForEducation(educationId);
            foreach (var attendance in attendanceList)
            {
                _educationAttendanceBaseDao.SetState(attendance.Id, (int)EducationAttendance.StateCode.PASSIVE, (int)EducationAttendance.StatusCode.EVENT_CANCELED);
            }
        }

        public int GetEducationAttendancesCountByMonth(Guid contactId, DateTime educationStartDate)
        {
            return _educationAttendanceDao.GetEducationAttendancesCountByMonth(contactId, educationStartDate);
        }

        public string GetEducationAttendanceCode(Guid educationId, string educationCode)
        {
            return educationCode+"/"+(11 + _educationAttendanceDao.GetEducationAttendancesCountForEducation(educationId));
        }
    }
}
