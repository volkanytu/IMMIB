using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRC.Library.Business.Interfaces;
using SRC.Library.Common;
using SRC.Library.Constants.LogKey;
using SRC.Library.Domain.Business.Interfaces;
using SRC.Library.Entities;
using SRC.Library.Entities.CrmEntities;
using SRC.Library.Entities.CustomEntities;

namespace SRC.Library.Domain.Facade
{
    public class ContactFacade
    {
        private IContactBusiness _contactBusiness;
        private ISmsBusiness _smsBusiness;
        private ILoginLogBusiness _loginLogBusiness;
        public ContactFacade(IContactBusiness contactBusiness, ISmsBusiness smsBusiness, ILoginLogBusiness loginLogBusiness)
        {
            _contactBusiness = contactBusiness;
            _smsBusiness = smsBusiness;
            _loginLogBusiness = loginLogBusiness;
        }

        public EntityReferenceWrapper CheckLogin(string userName, string password, string ipAddress)
        {
            string hashedPassword = password.ToSHA1();
            var contact = _contactBusiness.GetContact(userName, hashedPassword);
            if (contact == null)
            {
                throw new CustomException("Hatalı kullanıcı adı veya şifre!", ContactLogKeys.INVALID_USERNAME_OR_PASSWORD);
            }

            _loginLogBusiness.Create(contact.ToEntityReferenceWrapper(), ipAddress);

            return contact.ToEntityReferenceWrapper();
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
    }
}
