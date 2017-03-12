using SRC.Library.Business.Interfaces;
using SRC.Library.Domain.Business.Interfaces;
using SRC.Library.Domain.Facade.Interfaces;
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
using System.Web.Http;

namespace SRC.Web.NewPortal.Controllers
{
    public class ContactApiController : ApiController
    {
        private IContactBusiness _contactBusiness;
        private IContactFacade _contactFacade;

        public ContactApiController(IContactBusiness contactBusiness, IContactFacade contactFacade)
        {
            _contactBusiness = contactBusiness;
            _contactFacade = contactFacade;
        }

        [HttpPost]
        public ResponseContainer<Contact> CheckLogin(string userName, string password)
        {
            ResponseContainer<Contact> returnValue = new ResponseContainer<Contact>();

            Thread.Sleep(1000);

            //Contact loggedUser = _contactFacade.CheckLogin(userName, password, "192.168.2.1");
            Contact loggedUser = ContactMock.GetContact();
            returnValue.Result = loggedUser;
            returnValue.Success = true;
            returnValue.Message = "Hatalı kullanıcı veya şifre.";
            LoggedUser.Current = loggedUser;

            return returnValue;
        }

        [HttpPost]
        public ResponseContainer<bool> ExitProfile()
        {
            ResponseContainer<bool> returnValue = new ResponseContainer<bool>();

            Thread.Sleep(1000);

            LoggedUser.Current = null;

            returnValue.Success = true;
            returnValue.Result = true;

            return returnValue;
        }

        [AuthenticationFilter]
        public ResponseContainer<Contact> GetContact()
        {
            ResponseContainer<Contact> returnValue = new ResponseContainer<Contact>();

            Thread.Sleep(1000);

            returnValue.Result = LoggedUser.Current;
            returnValue.Success = true;


            return returnValue;
        }

        [HttpPost]
        public ResponseContainer<bool> SaveNewProfile(Contact contact)
        {
            ResponseContainer<bool> returnValue = new ResponseContainer<bool>();

            Thread.Sleep(1000);

            returnValue.Success = true;
            returnValue.Result = true;

            returnValue.Message = "Üyelik başvurusu başarı ile kaydedilmiştir.";
            //returnValue.Message = "Kayıt sırasında bir hata ile karşılaşıldı.";

            return returnValue;
        }
    }
}
