using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using SRC.Library.Constants.SqlQueries;
using SRC.Library.Data.Interfaces;
using SRC.Library.Data.SqlDao.Interfaces;
using SRC.Library.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

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

            return _sqlAccess.ExecuteScalar(CommonQueries.GET_ENTITY_NAME_BY_CODE, parameters).ToString();
        }

        public object GetEntityFieldValue(Guid id, string entityName, string fieldName)
        {
            IOrganizationService service = _msCrmAccess.GetCrmService();

            var orgContext = new OrganizationServiceContext(service);

            string pkName = string.Concat(entityName, "id");

            var entity = (from a in orgContext.CreateQuery(entityName)
                     where
                     (Guid)a[pkName] == id
                     select a).FirstOrDefault();

            if (entity.Contains(fieldName))
            {
                return entity[fieldName];
            }

            return null;
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
