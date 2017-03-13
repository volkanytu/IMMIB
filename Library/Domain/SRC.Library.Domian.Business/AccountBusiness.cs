using SRC.Library.Data.SqlDao;
using SRC.Library.Data.SqlDao.Interfaces;
using SRC.Library.Domain.Business.Interfaces;
using SRC.Library.Entities.CrmEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRC.Library.Constants.LogKey;
using SRC.Library.Entities.CustomEntities;
using SRC.Library.Common;
using SRC.Library.Data.Interfaces;

namespace SRC.Library.Domain.Business
{
    public class AccountBusiness : IAccountBusiness
    {
        private IBaseDao<Account> _baseDao;
        private IAccountDao _accountDao;

        public AccountBusiness(IBaseDao<Account> baseDao, IAccountDao accountDao)
        {
            _baseDao = baseDao;
            _accountDao = accountDao;
        }

        public Account GetAccount(string taxNumber)
        {
            return _accountDao.GetAccount(taxNumber);
        }
    }
}
