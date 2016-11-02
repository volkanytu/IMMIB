using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRC.Library.Data.SqlDao;
using SRC.Library.Domain.Business.Interfaces;
using SRC.Library.Entities;
using SRC.Library.Entities.CrmEntities;
using SRC.Library.Entities.CustomEntities;


namespace SRC.Library.Domain.Business
{
    public class SmsBusiness : ISmsBusiness
    {
        private BaseSqlDao<SmsEnt> _baseDao;
        private const string SUBJECT_REMEMBER_PASSWORD = "Şifre Hatırlatma Servisi";

        public SmsBusiness(BaseSqlDao<SmsEnt> baseDao)
        {
            _baseDao = baseDao;
        }

        public void CreateRememberPasswordSms(Contact contact, string password)
        {
            var sms = new SmsEnt
            {
                Contact = contact.ToEntityReferenceWrapper(), 
                PhoneNumber = contact.MobilePhone,
                Name = SUBJECT_REMEMBER_PASSWORD,
                Message = string.Format(SmsEnt.REMEMBER_PASSWORD_TEXT,contact.Name, password)
            };

            ValidateSms(sms);

            _baseDao.Insert(sms);
        }

        private void ValidateSms(SmsEnt smsEnt)
        {
            smsEnt.Contact.CheckNull("İlgili kullanıcı bilgisi boş!", "","");
            smsEnt.PhoneNumber.CheckNull("Telefon numarası boş!", "", smsEnt.Contact.Id.ToString());
            smsEnt.Message.CheckNull("Mesaj içeriği boş!","",smsEnt.Contact.Id.ToString());
        }
    }
}
