using SRC.Library.Data.SqlDao;
using SRC.Library.Data.SqlDao.Interfaces;
using SRC.Library.Domain.Business.Interfaces;
using SRC.Library.Entities.CrmEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.Library.Domain.Business
{
    public class ContactBusiness : IContactBusiness
    {
        private BaseSqlDao<Contact> _baseDao;
        private IContactDao _contactDao;

        public ContactBusiness(BaseSqlDao<Contact> baseDao, IContactDao contactDao)
        {
            _baseDao = baseDao;
            _contactDao = contactDao;
        }

        public Contact GetContact(string userName)
        {
            return _contactDao.GetContact(userName);
        }

        public Contact GetContact(string userName, string password)
        {
            return _contactDao.GetContact(userName, password);
        }
    }
}
