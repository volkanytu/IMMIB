using Microsoft.Xrm.Sdk;
using SRC.Library.Constants.SqlQueries;
using SRC.Library.Data.Interfaces;
using SRC.Library.Data.SqlDao.Interfaces;
using SRC.Library.Entities.CrmEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.Library.Data.SqlDao
{
    public class SmsDao : BaseSqlDao<SmsEnt>, ISmsDao
    {
        private ISqlAccess _sqlAccess;
        private IMsCrmAccess _msCrmAccess;

        public SmsDao(ISqlAccess sqlAccess, IMsCrmAccess msCrmAccess)
            : base(sqlAccess, msCrmAccess, SmsQueries.GET_SMS, SmsQueries.GET_SMS_LIST)
        {
            _sqlAccess = sqlAccess;
            _msCrmAccess = msCrmAccess;
        }


        public void UpdateSmsResult(SmsEnt sms)
        {
            IOrganizationService service = _msCrmAccess.GetCrmService();

            Entity ent = new Entity("new_sms");
            ent.Id = sms.Id;
            ent["new_messageid"] = sms.MessageID;
            ent["new_messagestatustext"] = sms.MessageStatus;
            ent["statuscode"] = new OptionSetValue(sms.Status.AttributeValue.Value);
            service.Update(ent);
        }
    }
}
