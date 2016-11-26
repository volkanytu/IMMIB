using SRC.Library.Entities;
using System;
using System.Collections.Generic;

namespace SRC.Library.Business.Interfaces
{
    public interface IBaseBusiness<TEntity>
     where TEntity : new()
    {
        void AssociateIn(Guid Id, EntityReferenceWrapper sourceEntity, string relationShipName);
        void AssociateTo(Guid Id, EntityReferenceWrapper targetEntity, string relationShipName);
        void Delete(Guid Id);
        TEntity Get(Guid Id);
        List<TEntity> GetList();
        Guid Insert(TEntity entity);
        void Update(TEntity entity);
        void SetState(Guid Id, int stateCode, int statusCode);
    }
}
