using System;
using System.Collections.Generic;
using SRC.Library.Entities.CrmEntities;
using SRC.Library.Entities;

namespace SRC.Library.Data.SqlDao.Interfaces
{
    public interface IAssociationDao
    {
        Association GetAssociation(int code);
        List<EntityReferenceWrapper> GetAssociationErListByEducation(Guid educationId);
    }
}