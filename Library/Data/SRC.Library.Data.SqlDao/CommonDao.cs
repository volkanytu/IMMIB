using Microsoft.Xrm.Sdk;
using SRC.Library.Data.Interfaces;
using SRC.Library.Data.SqlDao.Interfaces;
using SRC.Library.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SRC.Library.Data.SqlDao
{
    public class CommonDao : ICommonDao
    {
        private ISqlAccess _sqlAccess;
        private IMsCrmAccess _msCrmAccess;

        private string _sqlGetQuery;
        private string _sqlGetListQuery;

        public CommonDao(ISqlAccess sqlAccess, IMsCrmAccess msCrmAccess)
        {
            _sqlAccess = sqlAccess;
            _msCrmAccess = msCrmAccess;
        }

        public string GetEntityNameByCode(int objectTypeCode)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@objectTypeCode",objectTypeCode)
            };

            return _sqlAccess.ExecuteScalar("", parameters).ToString();
        }

        public object GetEntityFieldValue(string entityName, string fieldName)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@entityName",entityName),
                new SqlParameter("@fieldName",fieldName)
            };

            return _sqlAccess.ExecuteScalar("", parameters).ToString();
        }

        public void UpdateEntityField(EntityReferenceWrapper erEntity, KeyValuePair<string, object> value)
        {
            IOrganizationService service = _msCrmAccess.GetCrmService();

            Entity ent = new Entity(erEntity.LogicalName, erEntity.Id);
            ent.Attributes.Add(value);

            service.Update(ent);
        }
    }
}
