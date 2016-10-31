using Microsoft.Xrm.Sdk;
using SRC.Library.Data.Interfaces;
using System;
namespace SRC.Library.Data.SqlDao.Interface
{
    public interface ISqlEntityAccess
    {
        object Create(Entity entity, string PKName);
        void Delete(string entityName, Guid id, string PKName);
        void Update(Entity entity, string PKName);

        ISqlAccess SqlAccess { get; }
    }
}
