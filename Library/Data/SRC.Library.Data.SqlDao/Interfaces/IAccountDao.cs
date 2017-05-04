using SRC.Library.Entities.CrmEntities;
using System;
namespace SRC.Library.Data.SqlDao.Interfaces
{
    public interface IAccountDao
    {
        Account GetAccount(string taxNumber);
        void PassiveAllAccount();
    }
}
