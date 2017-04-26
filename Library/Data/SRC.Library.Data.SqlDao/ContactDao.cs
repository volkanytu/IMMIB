using Microsoft.Xrm.Sdk;
using SRC.Library.Constants.SqlQueries;
using SRC.Library.Data.Interfaces;
using SRC.Library.Data.SqlDao.Interfaces;
using SRC.Library.Entities;
using SRC.Library.Entities.CrmEntities;
using SRC.Library.Entities.CustomEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.Library.Data.SqlDao
{
    public class ContactDao : BaseSqlDao<Contact>, IContactDao
    {
        private ISqlAccess _sqlAccess;
        private IMsCrmAccess _msCrmAccess;

        public ContactDao(ISqlAccess sqlAccess, IMsCrmAccess msCrmAccess)
            : base(sqlAccess, msCrmAccess, ContactQueries.GET_CONTACT, ContactQueries.GET_CONTACT_LIST)
        {
            _sqlAccess = sqlAccess;
            _msCrmAccess = msCrmAccess;
        }

        public Contact GetContact(string userName)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@userName",userName)
            };

            DataTable dt = _sqlAccess.GetDataTable(ContactQueries.GET_CONTACT_BY_USERNAME, parameters);

            return dt.ToList<Contact>().FirstOrDefault();
        }

        public Contact GetContact(string userName, string password)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@userName",userName),
                new SqlParameter("@password",password)
            };

            DataTable dt = _sqlAccess.GetDataTable(ContactQueries.GET_CONTACT_BY_USERNAME_PASSWORD, parameters);

            return dt.ToList<Contact>().FirstOrDefault();
        }

        public Guid CreateAttachment(Attachment attacment)
        {
            IOrganizationService service = _msCrmAccess.GetCrmService();

            Entity attach = new Entity("annotation");

            attach["filename"] = attacment.FileName;
            attach["mimetype"] = attacment.MimeType;
            attach["filesize"] = attacment.FileSize.Value;
            attach["subject"] = "Kişi Doküman";
            attach["documentbody"] = attacment.Base64Data;
            attach["objecttypecode"] = attacment.ObjectTypeCode;
            attach["isdocument"] = true;
            attach["objectid"] = attacment.ObjectId.ToCrmEntityReference();

            return service.Create(attach);
        }
    }
}
