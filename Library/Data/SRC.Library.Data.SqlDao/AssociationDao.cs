using SRC.Library.Constants.SqlQueries;
using SRC.Library.Data.Interfaces;
using SRC.Library.Data.SqlDao.Interfaces;
using SRC.Library.Entities.CrmEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.Library.Data.SqlDao
{
    public class AssociationDao : BaseSqlDao<Association>, IAssociationDao
    {
        private ISqlAccess _sqlAccess;
        private IMsCrmAccess _msCrmAccess;

        public AssociationDao(ISqlAccess sqlAccess, IMsCrmAccess msCrmAccess)
            : base(sqlAccess, msCrmAccess, AssociationQueries.GET_ASSOCIATION, AssociationQueries.GET_ASSOCIATION_LIST)
        {
            _sqlAccess = sqlAccess;
            _msCrmAccess = msCrmAccess;
        }

        public Association GetAssociation(int code)
        {
            SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@code",code)
                };

            DataTable dt = _sqlAccess.GetDataTable(AssociationQueries.GET_ASSOCIATION_BY_CODE, parameters);

            return dt.ToList<Association>().FirstOrDefault();
        }

        public List<Association> GetAssociationsByEducation(Guid educationId)
        {
            SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@education",educationId)
                };

            DataTable dt = _sqlAccess.GetDataTable(AssociationQueries.GET_ASSOCIATION_BY_EDUCATION, parameters);

            return dt.ToList<Association>();
        }
    }

}
