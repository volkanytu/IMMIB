using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRC.Library.Data.Interfaces;
using SRC.Library.Data.SqlDao.Interfaces;
using SRC.Library.Domain.Business.Interfaces;
using SRC.Library.Entities.CrmEntities;

namespace SRC.Library.Domain.Business
{
    public class AssociationBusiness : IAssociationBusiness
    {
        private IBaseDao<Association> _baseDao;
        private IAssociationDao _associationDao;

        public AssociationBusiness(IBaseDao<Association> baseDao, IAssociationDao associationDao)
        {
            _baseDao = baseDao;
            _associationDao = associationDao;
        }

        public Association GetAssociation(int code)
        {
            return _associationDao.GetAssociation(code);
        }

        public List<Association> GetAssociationsByEducation(Guid educationId)
        {
            return _associationDao.GetAssociationsByEducation(educationId);
        }
    }
}
