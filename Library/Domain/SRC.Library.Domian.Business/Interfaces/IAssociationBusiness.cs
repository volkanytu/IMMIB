using System;
using System.Collections.Generic;
using SRC.Library.Entities.CrmEntities;

namespace SRC.Library.Domain.Business.Interfaces
{
    public interface IAssociationBusiness
    {
        Association GetAssociation(int code);
        List<Association> GetAssociationsByEducation(Guid educationId);
    }
}