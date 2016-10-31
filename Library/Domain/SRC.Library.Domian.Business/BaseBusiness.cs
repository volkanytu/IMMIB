using SRC.Library.Business.Interfaces;
using SRC.Library.Data.Interfaces;
using SRC.Library.Data.SqlDao.Interfaces;
using SRC.Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.Library.Business
{
    public class BaseBusiness<TEntity> : IBaseBusiness<TEntity>
        where TEntity : new()
    {
        private IBaseDao<TEntity> _baseDao;

        public BaseBusiness(IBaseDao<TEntity> baseDao)
        {
            _baseDao = baseDao;
        }

        public Guid Insert(TEntity entity)
        {
            return _baseDao.Insert(entity);
        }

        public void Update(TEntity entity)
        {
            _baseDao.Update(entity);
        }

        public void Delete(Guid Id)
        {
            _baseDao.Delete(Id);
        }

        public virtual TEntity Get(Guid Id)
        {
            return _baseDao.Get(Id);
        }

        public virtual List<TEntity> GetList()
        {
            return _baseDao.GetList();
        }

        public void AssociateTo(Guid Id, EntityReferenceWrapper targetEntity, string relationShipName)
        {
            _baseDao.AssociateTo(Id, targetEntity, relationShipName);
        }

        public void AssociateIn(Guid Id, EntityReferenceWrapper sourceEntity, string relationShipName)
        {
            _baseDao.AssociateIn(Id, sourceEntity, relationShipName);
        }
    }
}
