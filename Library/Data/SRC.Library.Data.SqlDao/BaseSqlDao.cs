using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using SRC.Library.Data.Interfaces;
using SRC.Library.Data.SqlDao.Interfaces;
using SRC.Library.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SRC.Library.Data.SqlDao
{
    public class BaseSqlDao<TEntity> : IBaseDao<TEntity>
        where TEntity : new()
    {
        private ISqlAccess _sqlAccess;
        private IMsCrmAccess _msCrmAccess;

        private string _sqlGetQuery;
        private string _sqlGetListQuery;

        public BaseSqlDao(ISqlAccess sqlAccess, IMsCrmAccess msCrmAccess
            , string sqlGetQuery, string sqlGetListQuery)
        {
            _sqlAccess = sqlAccess;
            _msCrmAccess = msCrmAccess;
            _sqlGetQuery = sqlGetQuery;
            _sqlGetListQuery = sqlGetListQuery;
        }

        public Guid Insert(TEntity entity)
        {
            IOrganizationService service = _msCrmAccess.GetCrmService();

            Entity ent = entity.ToCrmEntity();

            return service.Create(ent);
        }

        public void Update(TEntity entity)
        {
            IOrganizationService service = _msCrmAccess.GetCrmService();

            Entity ent = entity.ToCrmEntity();

            service.Update(ent);
        }

        public void Delete(Guid Id)
        {
            IOrganizationService service = _msCrmAccess.GetCrmService();

            string entityName = GetEntityName();

            service.Delete(entityName, Id);
        }

        public virtual TEntity Get(Guid Id)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id",Id)
            };

            DataTable dt = _sqlAccess.GetDataTable(_sqlGetQuery, parameters);

            return dt.ToList<TEntity>().FirstOrDefault();
        }

        public virtual List<TEntity> GetList()
        {
            DataTable dt = _sqlAccess.GetDataTable(_sqlGetListQuery);

            return dt.ToList<TEntity>();
        }

        public void SetState(Guid Id, int stateCode, int statusCode)
        {
            IOrganizationService service = _msCrmAccess.GetCrmService();
            string entityName = GetEntityName();

            SetStateRequest setStateReq = new SetStateRequest();

            setStateReq.EntityMoniker = new EntityReference(entityName, Id);
            setStateReq.State = new OptionSetValue(stateCode);
            setStateReq.Status = new OptionSetValue(statusCode);

            SetStateResponse response = (SetStateResponse)service.Execute(setStateReq);
        }

        public void AssociateTo(Guid Id, EntityReferenceWrapper targetEntity, string relationShipName)
        {
            IOrganizationService service = _msCrmAccess.GetCrmService();
            string entityName = GetEntityName();

            AssociateRequest request = new AssociateRequest
            {
                Target = targetEntity.ToCrmEntityReference(),
                RelatedEntities = new EntityReferenceCollection
                {
                    new EntityReference(entityName, Id)
                },
                Relationship = new Relationship(relationShipName)
            };

            service.Execute(request);
        }

        public void AssociateIn(Guid Id, EntityReferenceWrapper sourceEntity, string relationShipName)
        {
            IOrganizationService service = _msCrmAccess.GetCrmService();
            string entityName = GetEntityName();

            AssociateRequest request = new AssociateRequest
            {
                Target = new EntityReference(entityName, Id),
                RelatedEntities = new EntityReferenceCollection
                {
                    sourceEntity.ToCrmEntityReference()
                },
                Relationship = new Relationship(relationShipName)
            };

            service.Execute(request);
        }

        #region | PRIVATE METHODS |

        public static string GetEntityName()
        {
            MemberInfo info = typeof(TEntity);

            var schemaAttr = info.GetCustomAttributes(typeof(CrmSchemaName), false).OfType<CrmSchemaName>().FirstOrDefault();

            if (schemaAttr != null)
            {
                string entityName = schemaAttr.SchemaName;

                return entityName;
            }

            return null;
        }
        #endregion
    }
}
