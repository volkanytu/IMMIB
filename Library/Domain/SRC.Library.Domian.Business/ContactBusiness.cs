using SRC.Library.Data.SqlDao;
using SRC.Library.Data.SqlDao.Interfaces;
using SRC.Library.Domain.Business.Interfaces;
using SRC.Library.Entities.CrmEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRC.Library.Constants.LogKey;
using SRC.Library.Entities.CustomEntities;
using SRC.Library.Common;
using SRC.Library.Data.Interfaces;

namespace SRC.Library.Domain.Business
{
    public class ContactBusiness : IContactBusiness
    {
        private IBaseDao<Contact> _baseDao;
        private IContactDao _contactDao;

        public ContactBusiness(IBaseDao<Contact> baseDao, IContactDao contactDao)
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

        public void UpdatePassword(Guid contactId, string password, string newPassword)
        {
            var contact = _baseDao.Get(contactId);
            if (contact.Password != password)
            {
                throw new CustomException("Eski parola uyuşmuyor!",ContactLogKeys.INVALID_PASSWORD,contactId.ToString());
            }

            string hashedPassword = Encryption.SHA1Hash(newPassword);
            Contact entity = new Contact
            {
                Id = contactId,
                Password = hashedPassword
            };

            _baseDao.Update(entity);

        }

        public void UpdatePassword(Guid contactId, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new CustomException("Şifre boş olamaz!", ContactLogKeys.PASSWORD_NULL, contactId.ToString());
            }

            Contact entity = new Contact
            {
                Id = contactId,
                Password = password
            };

            _baseDao.Update(entity);

        }

        public string RememberPassword(string userName)
        {
            var contact = this.GetContact(userName);

            if (contact == null)
            {
                throw new CustomException("Bu kullanıcı adına ait üye bulunamadı!", ContactLogKeys.USER_NOT_FOUND, userName); 
            }

            //TODO: Generate

            string generatedPassword = "";
            string hashedPassword = Encryption.SHA1Hash(generatedPassword);

            Contact entity = new Contact
            {
                Id = contact.Id,
                Password = hashedPassword
            };

            _baseDao.Update(entity);

            return generatedPassword;
        }
    }
}
