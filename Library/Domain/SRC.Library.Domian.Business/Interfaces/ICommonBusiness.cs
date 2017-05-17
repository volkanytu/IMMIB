using SRC.Library.Entities;
using System;
using System.Collections.Generic;

namespace SRC.Library.Domain.Business.Interfaces
{
    public interface ICommonBusiness
    {
        string GetEntityNameByCode(int objectTypeCode);
        object GetEntityFieldValue(Guid id, string entityName, string fieldName);
        void UpdateEntityField(EntityReferenceWrapper erEntity, KeyValuePair<string, object> value);
    }
}
