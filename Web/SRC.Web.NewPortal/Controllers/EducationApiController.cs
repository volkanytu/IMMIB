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
    public class EducationApiController : ApiController
    {
        private IEducationBusiness _educationBusiness;
        private IEducationFacade _educationFacade;

        public EducationApiController(IEducationBusiness educationBusiness, IEducationFacade educationFacade)
        {
            _educationBusiness = educationBusiness;
            _educationFacade = educationFacade;
        }

        public ResponseContainer<List<Education>> GetComingEducationList()
        {
            ResponseContainer<List<Education>> returnValue = new ResponseContainer<List<Education>>();

            //returnValue.Result = _educationBusiness.GetLastEducations().Where(p => p.IsExpired == false).ToList();
            returnValue.Result = EducationMock.GetComingEducations();
            returnValue.Success = true;

            return returnValue;
        }

        public ResponseContainer<List<Education>> GetDoneEducationList()
        {
            ResponseContainer<List<Education>> returnValue = new ResponseContainer<List<Education>>();

            //returnValue.Result = _educationBusiness.GetLastEducations().Where(p => p.IsExpired
            //                        && p.StartDate != null && p.City != null).Take(5).ToList();
            returnValue.Result = EducationMock.GetDoneEducations();
            returnValue.Success = true;

            return returnValue;
        }

        public ResponseContainer<List<Education>> GetEducations()
        {
            ResponseContainer<List<Education>> returnValue = new ResponseContainer<List<Education>>();

            returnValue.Result = EducationMock.GetComingEducations();
            returnValue.Success = true;

            return returnValue;
        }

        public ResponseContainer<List<Education>> GetList(string month, string year)
        {
            ResponseContainer<List<Education>> returnValue = new ResponseContainer<List<Education>>();

            int monthNow = int.Parse(month);
            int yearNow = int.Parse(year);

            //returnValue.Result = _educationFacade.GetEducations(monthNow, yearNow);
            returnValue.Result = EducationMock.GetComingEducations().Where(e => e.StartDate.Value.Month == monthNow
                && e.StartDate.Value.Year == yearNow).ToList();

            List<EducationAttendance> contactAttendanceList = null;

            if (LoggedUser.IsLoggedIn)
            {
                contactAttendanceList = AttendanceMock.GetAttendances();

                _educationFacade.SetEducationAttendance(returnValue.Result, contactAttendanceList);
            }

            returnValue.Success = true;

            return returnValue;
        }

        public ResponseContainer<Education> GetEducation(string id)
        {
            ResponseContainer<Education> returnValue = new ResponseContainer<Education>();

            returnValue.Result = EducationMock.GetEducations().Where(e => e.Id == Guid.Parse(id)).FirstOrDefault();

            List<EducationAttendance> contactAttendanceList = null;

            if (LoggedUser.IsLoggedIn)
            {
                contactAttendanceList = AttendanceMock.GetAttendances();

                _educationFacade.SetEducationAttendance(returnValue.Result, contactAttendanceList);
            }

            returnValue.Success = true;

            return returnValue;
        }

        [HttpPost]
        [AuthenticationFilter]
        public ResponseContainer<EducationAttendance> ApplyEducation(string id)
        {
            ResponseContainer<EducationAttendance> returnValue = new ResponseContainer<EducationAttendance>();

            Thread.Sleep(2000);

            returnValue.Result = AttendanceMock.GetAttendances().FirstOrDefault();
            returnValue.Message = "İşlem sırasında bir hata ile karşılaşıldı.";
            returnValue.Success = true;

            return returnValue;
        }

        [HttpPost]
        [AuthenticationFilter]
        public ResponseContainer<bool> CancelAttendance(string id)
        {
            ResponseContainer<bool> returnValue = new ResponseContainer<bool>();

            Thread.Sleep(1000);

            returnValue.Result = true;
            returnValue.Message = "İşlem sırasında bir hata ile karşılaşıldı.";
            returnValue.Success = true;

            return returnValue;
        }

        [HttpPost]
        [AuthenticationFilter]
        public ResponseContainer<bool> PayEducation(CreditCardLog creditCardData)
        {
            ResponseContainer<bool> returnValue = new ResponseContainer<bool>();

            Thread.Sleep(1000);

            returnValue.Result = true;
            returnValue.Success = true;
            returnValue.Message = "Ödeme başarılı bir şekilde alınmıştır.";

            return returnValue;
        }

        [AuthenticationFilter]
        public ResponseContainer<List<Education>> GetEducationByStatus(int status)
        {
            ResponseContainer<List<Education>> returnValue = new ResponseContainer<List<Education>>();

            //returnValue.Result = _educationBusiness.GetLastEducations().Where(p => p.IsExpired
            //                        && p.StartDate != null && p.City != null).Take(5).ToList();
            returnValue.Result = EducationMock.GetComingEducations();

            List<EducationAttendance> contactAttendanceList = null;

            if (LoggedUser.IsLoggedIn)
            {
                contactAttendanceList = AttendanceMock.GetAttendances();

                _educationFacade.SetEducationAttendance(returnValue.Result, contactAttendanceList);
            }

            returnValue.Success = true;

            return returnValue;
        }
    }
}
