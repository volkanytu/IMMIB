using SRC.Library.Business.Interfaces;
using SRC.Library.Entities.CrmEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SRC.WebService.CrmService.Controllers
{
    public class TestController : ApiController
    {
        private IBaseBusiness<Contact> _baseContactBusiness;

        public TestController()
        {

        }

        //public TestController(IBaseBusiness<Contact> baseContactBusiness)
        //{
        //    _baseContactBusiness = baseContactBusiness;
        //}

        [HttpGet]
        public string TestGet(string Id)
        {
            return Id;
        }

        public string TestPost(Contact contact)
        {
            return contact.Name;
        }

    }
}
