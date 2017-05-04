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
    public class AccountDao : BaseSqlDao<Account>, IAccountDao
    {
        private ISqlAccess _sqlAccess;
        private IMsCrmAccess _msCrmAccess;

        public AccountDao(ISqlAccess sqlAccess, IMsCrmAccess msCrmAccess)
            : base(sqlAccess, msCrmAccess, AccountQueries.GET_ACCOUNT, AccountQueries.GET_ACCOUNT_LIST)
        {
            _sqlAccess = sqlAccess;
            _msCrmAccess = msCrmAccess;
        }

        public Account GetAccount(string taxNumber)
        {
            SqlParameter[] parameters = { new SqlParameter("@taxNumber",taxNumber) };

            DataTable dt = _sqlAccess.GetDataTable(AccountQueries.GET_ACCOUNT_BY_TAX_NUMBER, parameters);

            return dt.ToList<Account>().FirstOrDefault();
        }


        public void PassiveAllAccount()
        {
            _sqlAccess.ExecuteNonQuery(AccountQueries.PASSIVE_ALL_ACCOUNT);
        }
    }
}
