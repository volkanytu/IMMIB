using SRC.Library.Business.Interfaces;
using SRC.Library.Entities;
using SRC.Library.Entities.CrmEntities;
using SRC.Library.Entities.CustomEntities;
using SRC.Web.NewPortal.filters;
using SRC.Web.NewPortal.MockData;
using System;
using System.Collections.Generic;
using System.Configuration;
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
        private IBaseBusiness<University> _universityBusiness;
        private bool isMockActive = bool.Parse(ConfigurationManager.AppSettings["isMockActive"]);

        public CommonApiController(IBaseBusiness<City> cityBusiness, IBaseBusiness<University> universityBusiness)
        {
            _cityBusiness = cityBusiness;
            _universityBusiness = universityBusiness;
        }

        public ResponseContainer<List<EntityReferenceWrapper>> GetCities()
        {
            ResponseContainer<List<EntityReferenceWrapper>> returnValue = new ResponseContainer<List<EntityReferenceWrapper>>();

            if (isMockActive)
            {
                Thread.Sleep(1000);

                returnValue.Result = ContactMock.GetCities();
                returnValue.Success = true;
            }
            else
            {
                var cityList = _cityBusiness.GetList().Select(c => c.ToEntityReferenceWrapper()).ToList();
                returnValue.Result = cityList;
                returnValue.Success = true;
                returnValue.Message = "İl listesi çekildi.";
            }

            return returnValue;
        }

        public ResponseContainer<List<OptionSetValueWrapper>> GetEducationLevels()
        {
            ResponseContainer<List<OptionSetValueWrapper>> returnValue = new ResponseContainer<List<OptionSetValueWrapper>>();

            if (isMockActive)
            {
                Thread.Sleep(1000);

                returnValue.Result = ContactMock.GetEducationLevels();
                returnValue.Success = true;
            }
            else
            {
                returnValue.Result = Contact.GetEducationLevels();
                returnValue.Success = true;
                returnValue.Message = "Eğitim seviyeleri çekildi.";
            }

            return returnValue;
        }

        public ResponseContainer<List<OptionSetValueWrapper>> GetGenderCodes()
        {
            ResponseContainer<List<OptionSetValueWrapper>> returnValue = new ResponseContainer<List<OptionSetValueWrapper>>();

            if (isMockActive)
            {
                Thread.Sleep(1000);

                returnValue.Result = ContactMock.GetGenderCodes();
                returnValue.Success = true;
            }
            else
            {
                returnValue.Result = Contact.GetGenderCodes();
                returnValue.Success = true;
                returnValue.Message = "Cinsiyet listesi çekildi.";
            }

            return returnValue;
        }

        public ResponseContainer<List<OptionSetValueWrapper>> GetInstallmentTypes()
        {
            ResponseContainer<List<OptionSetValueWrapper>> returnValue = new ResponseContainer<List<OptionSetValueWrapper>>();

            if (isMockActive)
            {
                Thread.Sleep(1000);

                returnValue.Result = AttendanceMock.GetInstallmentTypes();
                returnValue.Success = true;
            }
            else
            {
                returnValue.Result = CreditCardLog.GetInstallmentTypes();
                returnValue.Success = true;
                returnValue.Message = "Taksit sayıları çekildi.";
            }

            return returnValue;
        }

        public ResponseContainer<List<EntityReferenceWrapper>> GetUniversities()
        {
            ResponseContainer<List<EntityReferenceWrapper>> returnValue = new ResponseContainer<List<EntityReferenceWrapper>>();

            if (isMockActive)
            {
                Thread.Sleep(1000);

                returnValue.Result = ContactMock.GetCities();
                returnValue.Success = true;
            }
            else
            {
                var cityList = _universityBusiness.GetList().Select(c => c.ToEntityReferenceWrapper()).ToList();
                returnValue.Result = cityList;
                returnValue.Success = true;
                returnValue.Message = "Üniversite listesi çekildi.";
            }

            return returnValue;
        }

    }
}
