using System;
using System.Collections.Generic;
using SRC.Library.Entities.CrmEntities;
using SRC.Library.Entities;

namespace SRC.Library.Domain.Business.Interfaces
{
    public interface IAssociationBusiness
    {
        Association GetAssociation(int code);
        List<EntityReferenceWrapper> GetAssociationErListByEducation(Guid educationId);
    }
}