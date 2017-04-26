using SRC.Library.Entities.CrmEntities;
using SRC.Library.Entities.CustomEntities;
using System;
namespace SRC.Library.Data.SqlDao.Interfaces
{
    public interface IContactDao
    {
        Contact GetContact(string userName);
        Contact GetContact(string userName, string password);
        Guid CreateAttachment(Attachment attachment);
    }
}
