using SRC.Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.Library.Data.Interfaces
{
    public interface IBaseDao<TEntity>
     where TEntity : new()
    {
        //TEST
        Guid Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(Guid Id);
        TEntity Get(Guid Id);
        List<TEntity> GetList();
        void SetState(Guid Id, int stateCode, int statusCode);
        void AssociateTo(Guid Id, EntityReferenceWrapper targetEntity, string relationShipName);
        void AssociateIn(Guid Id, EntityReferenceWrapper sourceEntity, string relationShipName);
    }
}
