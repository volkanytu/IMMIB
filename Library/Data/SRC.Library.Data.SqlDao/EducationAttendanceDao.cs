using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRC.Library.Constants.SqlQueries;
using SRC.Library.Data.Interfaces;
using SRC.Library.Data.SqlDao.Interfaces;
using SRC.Library.Entities.CrmEntities;

namespace SRC.Library.Data.SqlDao
{
    public class EducationAttendanceDao : BaseSqlDao<EducationAttendance>, IEducationAttendanceDao
    {
        private ISqlAccess _sqlAccess;
        private IMsCrmAccess _msCrmAccess;

        public EducationAttendanceDao(ISqlAccess sqlAccess, IMsCrmAccess msCrmAccess)
            : base(sqlAccess, msCrmAccess, EducationAttendenceQueries.GET_EDUCATION_ATTENDANCE, EducationAttendenceQueries.GET_EDUCATION_ATTENDANCE_LIST)
        {
            _sqlAccess = sqlAccess;
            _msCrmAccess = msCrmAccess;
        }

        public List<EducationAttendance> GetEducationAttendances(Guid contactId)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@contactId",contactId)
            };

            DataTable dt = _sqlAccess.GetDataTable(EducationAttendenceQueries.GET_EDUCATION_ATTENDANCE_LIST_BY_CONTACT, parameters);

            return dt.ToList<EducationAttendance>().ToList();
        }

        public List<EducationAttendance> GetEducationAttendancesForExpectedPayments(int remainDay)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@remainDay",remainDay)
            };

            DataTable dt = _sqlAccess.GetDataTable(EducationAttendenceQueries.GET_EDUCATION_EXPECTED_PAYMENT, parameters);

            return dt.ToList<EducationAttendance>().ToList();
        }
    }
}
