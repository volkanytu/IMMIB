using SRC.Library.Data.SqlDao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRC.Library.Constants.LogKey;
using SRC.Library.Domain.Business.Interfaces;
using SRC.Library.Entities;
using SRC.Library.Entities.CrmEntities;

namespace SRC.Library.Domain.Business
{
    public class LoginLogBusiness : ILoginLogBusiness
    {
        private BaseSqlDao<LoginLog> _baseDao;

        public LoginLogBusiness(BaseSqlDao<LoginLog> baseDao)
        {
            _baseDao = baseDao;
        }

        public void Create(EntityReferenceWrapper contact, string ipAddress)
        {
            ipAddress.CheckNull("Ip adresi boş!", LoginLogKeys.IP_ADDRESS_NULL, contact.Id.ToString());

            var log = new LoginLog
            {
                Contact =  contact.ToEntityReferenceWrapper(),
                IpAddress = ipAddress,
                LoginDate = DateTime.Now,
                Name = DateTime.Now.ToShortDateString()
            };

            _baseDao.Insert(log);
        }
    }
}
