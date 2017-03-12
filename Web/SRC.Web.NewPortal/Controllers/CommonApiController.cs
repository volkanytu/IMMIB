using SRC.Library.Business.Interfaces;
using SRC.Library.Entities;
using SRC.Library.Entities.CrmEntities;
using SRC.Library.Entities.CustomEntities;
using SRC.Web.NewPortal.filters;
using SRC.Web.NewPortal.MockData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace SRC.Web.NewPortal.Controllers
{
    public class CommonApiController : ApiController
    {
        private IBaseBusiness<City> _cityBusiness;

        public CommonApiController(IBaseBusiness<City> cityBusiness)
        {
            _cityBusiness = cityBusiness;
        }

        public ResponseContainer<List<EntityReferenceWrapper>> GetCities()
        {
            ResponseContainer<List<EntityReferenceWrapper>> returnValue = new ResponseContainer<List<EntityReferenceWrapper>>();

            Thread.Sleep(1000);

            //returnValue.Result = _cityBusiness.GetList();
            returnValue.Result = ContactMock.GetCities();
            returnValue.Success = true;


            return returnValue;
        }

        public ResponseContainer<List<OptionSetValueWrapper>> GetEducationLevels()
        {
            ResponseContainer<List<OptionSetValueWrapper>> returnValue = new ResponseContainer<List<OptionSetValueWrapper>>();

            Thread.Sleep(1000);

            returnValue.Result = ContactMock.GetEducationLevels();
            returnValue.Success = true;


            return returnValue;
        }

        public ResponseContainer<List<OptionSetValueWrapper>> GetGenderCodes()
        {
            ResponseContainer<List<OptionSetValueWrapper>> returnValue = new ResponseContainer<List<OptionSetValueWrapper>>();

            Thread.Sleep(1000);

            returnValue.Result = ContactMock.GetGenderCodes();
            returnValue.Success = true;


            return returnValue;
        }

    }
}
