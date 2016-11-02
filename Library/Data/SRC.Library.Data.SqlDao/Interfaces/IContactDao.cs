using SRC.Library.Entities.CrmEntities;
using System;
namespace SRC.Library.Data.SqlDao.Interfaces
{
    public interface IContactDao
    {
        Contact GetContact(string userName);
        Contact GetContact(string userName, string password);
    }
}
