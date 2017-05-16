using SRC.Library.Data.SqlDao.Interfaces;
using SRC.Library.Domain.Business.Interfaces;
using SRC.Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.Library.Domain.Business
{
    public class CommonBusiness : ICommonBusiness
    {
        private ICommonDao _commonDao;

        public CommonBusiness(ICommonDao commonDao)
        {
            _commonDao = commonDao;
        }

        public string GetEntityNameByCode(int objectTypeCode)
        {
            return _commonDao.GetEntityNameByCode(objectTypeCode);
        }

        public object GetEntityFieldValue(string entityName, string fieldName)
        {
            return _commonDao.GetEntityFieldValue(entityName, fieldName);
        }

        public void UpdateEntityField(EntityReferenceWrapper erEntity, KeyValuePair<string, object> value)
        {
            _commonDao.UpdateEntityField(erEntity, value);
        }
    }
}
