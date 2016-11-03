using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRC.Library.Constants.LogKey;
using SRC.Library.Data.SqlDao;
using SRC.Library.Data.SqlDao.Interfaces;
using SRC.Library.Domain.Business.Interfaces;
using SRC.Library.Entities;
using SRC.Library.Entities.CrmEntities;

namespace SRC.Library.Domain.Business
{
    public class EducationBusiness : IEducationBusiness
    {
        private IEducationDao _educationDao;

        public EducationBusiness(IEducationDao educationDao)
        {
            _educationDao = educationDao;
        }

        public List<Education> GetEducations(DateTime startDate, DateTime endDate)
        {
            return _educationDao.GetEducations(startDate, endDate);
        }

        public List<Education> GetEducationsOfAttendances(List<EducationAttendance> educationAttendanceList)
        {
            return _educationDao.GetEducationsOfAttendances(educationAttendanceList);
        }
    }
}
