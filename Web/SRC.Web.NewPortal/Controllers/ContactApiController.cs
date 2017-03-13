using SRC.Library.Business.Interfaces;
using SRC.Library.Domain.Business.Interfaces;
using SRC.Library.Domain.Facade.Interfaces;
using SRC.Library.Entities;
using SRC.Library.Entities.CrmEntities;
using SRC.Library.Entities.CustomEntities;
using SRC.Web.NewPortal.filters;
using SRC.Web.NewPortal.MockData;
using SRC.Web.NewPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web;
using System.Web.Http;
using SRC.Library.Common;
using System.Configuration;

namespace SRC.Web.NewPortal.Controllers
{
    public class ContactApiController : ApiController
    {
        private IContactBusiness _contactBusiness;
        private IContactFacade _contactFacade;
        private IAccountBusiness _accountBusiness;

        private bool isMockActive = bool.Parse(ConfigurationManager.AppSettings["isMockActive"]);

        public ContactApiController(IContactBusiness contactBusiness, IContactFacade contactFacade
            , IAccountBusiness accountBusiness)
        {
            _contactBusiness = contactBusiness;
            _contactFacade = contactFacade;
            _accountBusiness = accountBusiness;
        }

        [HttpPost]
        public ResponseContainer<Contact> CheckLogin(string userName, string password)
        {
            ResponseContainer<Contact> returnValue = new ResponseContainer<Contact>();

            Contact loggedUser = null;

            if (isMockActive)
            {
                Thread.Sleep(1000);

                loggedUser = ContactMock.GetContact();
                returnValue.Result = loggedUser;
                returnValue.Success = true;
                //returnValue.Message = "Hatalı kullanıcı veya şifre.";
                LoggedUser.Current = loggedUser;
            }
            else
            {
                try
                {
                    loggedUser = _contactFacade.CheckLogin(userName, password, HttpContext.Current.Request.UserHostAddress);
                    LoggedUser.Current = loggedUser;

                    returnValue.Result = loggedUser;
                    returnValue.Success = true;
                    returnValue.Message = "Üye girişi başarılı.";
                }
                catch (Exception ex)
                {

                    returnValue.Message = ex.Message;
                }
            }

            return returnValue;
        }

        [HttpPost]
        public ResponseContainer<bool> ExitProfile()
        {
            ResponseContainer<bool> returnValue = new ResponseContainer<bool>();

            LoggedUser.Current = null;
            returnValue.Success = true;
            returnValue.Result = true;
            returnValue.Message = "Üye çıkışı başarılı";

            return returnValue;
        }

        [AuthenticationFilter]
        public ResponseContainer<Contact> GetContact()
        {
            ResponseContainer<Contact> returnValue = new ResponseContainer<Contact>();

            returnValue.Result = _contactFacade.GetContact(LoggedUser.Current.Id);
            returnValue.Success = true;
            returnValue.Message = "Üye bilgisi çekildi.";

            LoggedUser.Current = returnValue.Result;

            return returnValue;
        }

        [HttpPost]
        public ResponseContainer<bool> SaveNewProfile(Contact contact)
        {
            ResponseContainer<bool> returnValue = new ResponseContainer<bool>();

            if (isMockActive)
            {
                Thread.Sleep(1000);

                returnValue.Success = true;
                returnValue.Result = true;

                returnValue.Message = "Üyelik başvurusu başarı ile kaydedilmiştir.";
                //returnValue.Message = "Kayıt sırasında bir hata ile karşılaşıldı.";
            }
            else
            {
                if (!_contactFacade.CheckUserExists(contact.EmailAddress))
                {
                    contact.UserName = contact.EmailAddress;
                    contact.Password = contact.Password.ToSHA1();
                    var newContactId = _contactFacade.CreateContact(contact);

                    returnValue.Success = true;
                    returnValue.Result = true;
                    returnValue.Message = "Üyelik başvurusu tamamlanmıştır.";
                }
                else
                {
                    returnValue.Message = "Girmiş olduğunuz email adresi başka bir üye tarafından kullanılmaktadır.";
                }
            }

            return returnValue;
        }

        [HttpPost]
        [AuthenticationFilter]
        public ResponseContainer<bool> UpdateProfile(Contact contact)
        {
            ResponseContainer<bool> returnValue = new ResponseContainer<bool>();

            if (isMockActive)
            {
                Thread.Sleep(1000);

                returnValue.Success = true;
                returnValue.Result = true;

                returnValue.Message = "Üyelik bilgileri başarı ile güncellenmiştir.";
                //returnValue.Message = "Güncelleme sırasında bir hata ile karşılaşıldı.";
            }
            else
            {
                contact.Id = LoggedUser.Current.Id;
                _contactFacade.UpdateContact(contact);

                returnValue.Success = true;
                returnValue.Result = true;
                returnValue.Message = "Üyelik bilgileri güncellendi.";
            }

            return returnValue;
        }

        [HttpPost]
        [AuthenticationFilter]
        public ResponseContainer<bool> ChangePassword(string oldPassword, string newPassword, string reNewPassword)
        {
            ResponseContainer<bool> returnValue = new ResponseContainer<bool>();

            if (isMockActive)
            {
                Thread.Sleep(1000);

                returnValue.Success = true;
                returnValue.Result = true;

                returnValue.Message = "Şifreniz başarı ile güncellenmiştir.";
                //returnValue.Message = "Şifre güncelleme sırasında bir hata ile karşılaşıldı.";
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(oldPassword) && !string.IsNullOrWhiteSpace(newPassword) && !string.IsNullOrWhiteSpace(reNewPassword))
                {
                    string hashedOldPassword = oldPassword.ToSHA1();

                    if (newPassword != reNewPassword)
                    {
                        returnValue.Message = "Girilen şifreler uyuşmamaktadır.";
                    }
                    else if (LoggedUser.Current.Password != hashedOldPassword)
                    {
                        returnValue.Message = "Hatalı eksi şifre bilgisi.";
                    }
                    else
                    {
                        _contactFacade.UpdatePassWord(LoggedUser.Current.Id, newPassword.ToSHA1());

                        returnValue.Success = true;
                        returnValue.Result = true;
                        returnValue.Message = "Şifre değişikliği gerçekleşmiştir.";
                    }
                }
            }

            return returnValue;
        }

        public ResponseContainer<EntityReferenceWrapper> GetCompany(string taxNumber)
        {
            ResponseContainer<EntityReferenceWrapper> returnValue = new ResponseContainer<EntityReferenceWrapper>();

            if (isMockActive)
            {
                Thread.Sleep(1000);

                returnValue.Success = true;
                returnValue.Result = new EntityReferenceWrapper { Id = Guid.NewGuid(), Name = "VOLKAN A.Ş", LogicalName = "account" };

                //returnValue.Message = "Firma arama sırasında hata ile karşılaşıldı.";
            }
            else
            {
                var account = _accountBusiness.GetAccount(taxNumber);

                if (account != null)
                {
                    returnValue.Result = account.ToEntityReferenceWrapper();
                    returnValue.Success = true;
                    returnValue.Message = "Vergi numarası ile eşleşen firma kaydı bulundu.";
                }
                else
                {
                    returnValue.Message = "İlgili vergi numarası ile eşleşen bir firma kaydı bulunamadı.";
                }
            }

            return returnValue;
        }
    }
}
