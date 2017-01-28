using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRC.Library.Business.Interfaces;
using SRC.Library.Common;
using SRC.Library.Constants.LogKey;
using SRC.Library.Domain.Business.Interfaces;
using SRC.Library.Domain.Facade.Interfaces;
using SRC.Library.Entities;
using SRC.Library.Entities.CrmEntities;
using SRC.Library.Entities.CustomEntities;

namespace SRC.Library.Domain.Facade
{
    public class ContactFacade : IContactFacade
    {
        private IContactBusiness _contactBusiness;
        private ISmsBusiness _smsBusiness;
        private IBaseBusiness<LoginLog> _baseBusiness;
        private IBaseBusiness<Contact> _baseContactBusiness;
        public ContactFacade(IContactBusiness contactBusiness, ISmsBusiness smsBusiness,
            IBaseBusiness<LoginLog> baseBusiness, IBaseBusiness<Contact> baseContactBusiness)
        {
            _contactBusiness = contactBusiness;
            _smsBusiness = smsBusiness;
            _baseBusiness = baseBusiness;
            _baseContactBusiness = baseContactBusiness;
        }

        public Contact CheckLogin(string userName, string password, string ipAddress)
        {
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
            {
                throw new CustomException("Kullanıcı adı ve şifre alanları dolu olmalıdır!", ContactLogKeys.MISSING_PARAMETER_USERNAME_PASSWORD);
            }

            string hashedPassword = password.ToSHA1();
            var contact = _contactBusiness.GetContact(userName, hashedPassword);
            if (contact == null)
            {
                throw new CustomException("Hatalı kullanıcı adı veya şifre!", ContactLogKeys.INVALID_USERNAME_OR_PASSWORD);
            }

            this.CreateLoginLog(contact.ToEntityReferenceWrapper(), ipAddress);

            return contact;
        }

        public void RememberPassWord(string userName)
        {
            var contact = _contactBusiness.GetContact(userName);

            contact.CheckNull("Bu kullanıcı adına ait üye bulunamadı!", ContactLogKeys.USER_NOT_FOUND, userName);

            string generatedPassword = "";
            string hashedPassword = Encryption.SHA1Hash(generatedPassword);

            _contactBusiness.UpdatePassword(contact.Id, hashedPassword);
            _smsBusiness.CreateRememberPasswordSms(contact, generatedPassword);
        }

        public void UpdatePassWord(Guid? contactId, string password)
        {
            contactId.CheckNull("Üye bilgisi boş olamaz!", ContactLogKeys.CONTACT_ID_NULL);
            password.CheckNull("Eski şifre boş olamaz!", ContactLogKeys.PASSWORD_NULL, contactId.ToString());
           
            _contactBusiness.UpdatePassword((Guid)contactId, password);
        }

        public Guid? CreateContact(Contact contact)
        {
            contact.CheckNull("Üye bilgileri boş olamaz!", ContactLogKeys.CONTACT_NULL);
            return _baseContactBusiness.Insert(contact);
        }

        public Contact GetContact(Guid? contactId)
        {
            contactId.CheckNull("Üye bilgisi boş olamaz!", ContactLogKeys.CONTACT_ID_NULL);

            return _baseContactBusiness.Get((Guid)contactId);
        }

        public void UpdateContact(Contact contact)
        {
            contact.CheckNull("Üye bilgileri boş olamaz!", ContactLogKeys.CONTACT_NULL);
            _baseContactBusiness.Update(contact);
        }

        public void CreateLoginLog(EntityReferenceWrapper contact, string ipAddress)
        {
            ipAddress.CheckNull("Ip adresi boş!", LoginLogKeys.IP_ADDRESS_NULL, contact.Id.ToString());

            var log = new LoginLog
            {
                Contact = contact.ToEntityReferenceWrapper(),
                IpAddress = ipAddress,
                LoginDate = DateTime.Now,
                Name = DateTime.Now.ToShortDateString()
            };

            _baseBusiness.Insert(log);
        }


    }
}
