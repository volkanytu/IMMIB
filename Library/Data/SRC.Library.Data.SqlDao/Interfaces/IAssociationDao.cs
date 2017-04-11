using System;
using System.Collections.Generic;
using SRC.Library.Entities.CrmEntities;

namespace SRC.Library.Data.SqlDao.Interfaces
{
    public interface IAssociationDao
    {
        Association GetAssociation(int code);
        List<Association> GetAssociationsByEducation(Guid educationId);
    }
}