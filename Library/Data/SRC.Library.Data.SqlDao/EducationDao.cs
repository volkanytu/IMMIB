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
    public class EducationDao  : BaseSqlDao<Education>, IEducationDao
    {
        private ISqlAccess _sqlAccess;
        private IMsCrmAccess _msCrmAccess;

        public EducationDao(ISqlAccess sqlAccess, IMsCrmAccess msCrmAccess)
            : base(sqlAccess, msCrmAccess, EducationQueries.GET_EDUCATION, EducationQueries.GET_EDUCATION_LIST)
        {
            _sqlAccess = sqlAccess;
            _msCrmAccess = msCrmAccess;
        }

        public List<Education> GetEducations(DateTime startDate, DateTime endDate)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@startDate",startDate),
                new SqlParameter("@endDate",endDate)
            };

            DataTable dt = _sqlAccess.GetDataTable(EducationQueries.GET_EDUCATION_LIST_BY_START_DATE, parameters);

            return dt.ToList<Education>().ToList();
        }
    }
}
