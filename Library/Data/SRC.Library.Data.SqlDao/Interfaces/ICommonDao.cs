using SRC.Library.Entities;
using System;
using System.Collections.Generic;

namespace SRC.Library.Data.SqlDao.Interfaces
{
    public interface ICommonDao
    {
        string GetEntityNameByCode(int objectTypeCode);
        object GetEntityFieldValue(string entityName, string fieldName);
        void UpdateEntityField(EntityReferenceWrapper erEntity, KeyValuePair<string, object> value);
    }
}
