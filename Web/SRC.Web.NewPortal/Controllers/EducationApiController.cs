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
using SRC.Library.Entities;
using System.Configuration;
using SRC.Library.Common;

namespace SRC.Web.NewPortal.Controllers
{
    public class EducationApiController : ApiController
    {
        private IEducationBusiness _educationBusiness;
        private IEducationFacade _educationFacade;
        private IBaseBusiness<Education> _baseEducationBusiness;
        private IBaseBusiness<EducationAttendance> _educationAttendanceBaseBusiness;
        private IBaseBusiness<CreditCardLog> _creditCardLogBaseBusiness;

        private bool isMockActive = bool.Parse(ConfigurationManager.AppSettings["isMockActive"]);

        public EducationApiController(IEducationBusiness educationBusiness, IEducationFacade educationFacade
            , IBaseBusiness<Education> baseEducationBusiness
            , IBaseBusiness<EducationAttendance> educationAttendanceBaseBusiness
            , IBaseBusiness<CreditCardLog> creditCardLogBaseBusiness)
        {
            _educationBusiness = educationBusiness;
            _educationFacade = educationFacade;
            _baseEducationBusiness = baseEducationBusiness;
            _educationAttendanceBaseBusiness = educationAttendanceBaseBusiness;
            _creditCardLogBaseBusiness = creditCardLogBaseBusiness;
        }

        public ResponseContainer<List<Education>> GetComingEducationList()
        {
            ResponseContainer<List<Education>> returnValue = new ResponseContainer<List<Education>>();

            if (isMockActive)
            {
                returnValue.Result = EducationMock.GetComingEducations();
                returnValue.Success = true;
            }
            else
            {
                returnValue.Result = _educationBusiness.GetLastEducations().Where(p => p.IsExpired == false).Take(5).ToList();
                returnValue.Success = true;
                returnValue.Message = "Yaklaşan eğitimler çekildi.";

            }

            return returnValue;
        }

        public ResponseContainer<List<Education>> GetDoneEducationList()
        {
            ResponseContainer<List<Education>> returnValue = new ResponseContainer<List<Education>>();

            if (isMockActive)
            {
                returnValue.Result = EducationMock.GetDoneEducations();
                returnValue.Success = true;
            }
            else
            {
                returnValue.Result = _educationBusiness.GetLastEducations().Where(p => p.IsExpired
                                                                                    && p.StartDate != null && p.City != null).Take(5).ToList();
                returnValue.Success = true;
                returnValue.Message = "Tamamlanan eğitimler çekildi.";
            }

            return returnValue;
        }

        public ResponseContainer<List<Education>> GetEducations()
        {
            ResponseContainer<List<Education>> returnValue = new ResponseContainer<List<Education>>();

            if (isMockActive)
            {
                returnValue.Result = EducationMock.GetComingEducations();
                returnValue.Success = true;
            }
            else
            {
                returnValue.Result = _educationFacade.GetEducations(DateTime.Now.Month, DateTime.Now.Year);

                List<EducationAttendance> contactAttendanceList = null;

                if (LoggedUser.IsLoggedIn)
                {
                    contactAttendanceList = _educationFacade.GetContactAttendances(LoggedUser.Current.Id);

                    _educationFacade.SetEducationAttendance(returnValue.Result, contactAttendanceList);
                }

                returnValue.Success = true;
                returnValue.Message = "Eğitim listesi çekildi.";
            }

            return returnValue;
        }

        public ResponseContainer<List<Education>> GetList(string month, string year)
        {
            ResponseContainer<List<Education>> returnValue = new ResponseContainer<List<Education>>();

            int monthNow = int.Parse(month);
            int yearNow = int.Parse(year);

            if (isMockActive)
            {
                //returnValue.Result = _educationFacade.GetEducations(monthNow, yearNow);
                returnValue.Result = EducationMock.GetComingEducations().Where(e => e.StartDate.Value.Month == monthNow
                    && e.StartDate.Value.Year == yearNow).ToList();

                List<EducationAttendance> contactAttendanceList = null;

                if (LoggedUser.IsLoggedIn)
                {
                    contactAttendanceList = AttendanceMock.GetAttendances();

                    _educationFacade.SetEducationAttendance(returnValue.Result, contactAttendanceList);
                }
            }
            else
            {
                returnValue.Result = _educationFacade.GetEducations(monthNow, yearNow);

                List<EducationAttendance> contactAttendanceList = null;

                if (LoggedUser.IsLoggedIn)
                {
                    contactAttendanceList = _educationFacade.GetContactAttendances(LoggedUser.Current.Id);

                    _educationFacade.SetEducationAttendance(returnValue.Result, contactAttendanceList);
                }

                returnValue.Success = true;
                returnValue.Message = "Eğitim listesi çekildi.";
            }

            returnValue.Success = true;

            return returnValue;
        }

        public ResponseContainer<Education> GetEducation(string id)
        {
            ResponseContainer<Education> returnValue = new ResponseContainer<Education>();

            if (isMockActive)
            {
                returnValue.Result = EducationMock.GetEducations().Where(e => e.Id == Guid.Parse(id)).FirstOrDefault();

                List<EducationAttendance> contactAttendanceList = null;

                if (LoggedUser.IsLoggedIn)
                {
                    contactAttendanceList = AttendanceMock.GetAttendances();

                    _educationFacade.SetEducationAttendance(returnValue.Result, contactAttendanceList);
                }

                returnValue.Success = true;
            }
            else
            {
                returnValue.Result = _baseEducationBusiness.Get(Guid.Parse(id));

                List<EducationAttendance> contactAttendanceList = null;

                if (LoggedUser.IsLoggedIn)
                {
                    contactAttendanceList = _educationFacade.GetContactAttendances(LoggedUser.Current.Id);

                    _educationFacade.SetEducationAttendance(returnValue.Result, contactAttendanceList);
                }

                returnValue.Success = true;
                returnValue.Message = "Eğitim detayı çekildi.";
            }


            return returnValue;
        }

        [HttpPost]
        [AuthenticationFilter]
        public ResponseContainer<EducationAttendance> ApplyEducation(string id)
        {
            ResponseContainer<EducationAttendance> returnValue = new ResponseContainer<EducationAttendance>();

            if (isMockActive)
            {
                Thread.Sleep(1000);

                returnValue.Result = AttendanceMock.GetAttendances().FirstOrDefault();
                returnValue.Message = "İşlem sırasında bir hata ile karşılaşıldı.";
                returnValue.Success = true;
            }
            else
            {
                var attendance = new EducationAttendance
                {
                    Contact = LoggedUser.Current.ToEntityReferenceWrapper(),
                    Education = Guid.Parse(id).ToEntityReferenceWrapper<Education>(),
                    Name = string.Format("{0} {1}|{2}", LoggedUser.Current.FirstName, LoggedUser.Current.LastName, DateTime.Now.ToString("dd.MM.yyyy HH:mm"))
                };

                var attendanceId = _educationAttendanceBaseBusiness.Insert(attendance);

                returnValue.Result = _educationAttendanceBaseBusiness.Get(attendanceId);
                returnValue.Success = true;
                returnValue.Message = "Eğitim katılımı talebiniz başarıyla alınmıştır.";
            }

            return returnValue;
        }

        [HttpPost]
        [AuthenticationFilter]
        public ResponseContainer<bool> CancelAttendance(string id)
        {
            ResponseContainer<bool> returnValue = new ResponseContainer<bool>();

            if (isMockActive)
            {
                Thread.Sleep(1000);

                returnValue.Result = true;
                returnValue.Message = "İşlem sırasında bir hata ile karşılaşıldı.";
                returnValue.Success = true;
            }
            else
            {
                _educationFacade.CancelEducationAttendance(new Guid(id));
                returnValue.Success = true;
                returnValue.Result = true;
                returnValue.Message = "Eğitim katılımı iptali başarıyla tamamlanmıştır.";
            }

            return returnValue;
        }

        [HttpPost]
        [AuthenticationFilter]
        public ResponseContainer<bool> PayEducation(CreditCardLog creditCardData)
        {
            ResponseContainer<bool> returnValue = new ResponseContainer<bool>();

            if (isMockActive)
            {
                Thread.Sleep(1000);

                returnValue.Result = true;
                returnValue.Success = true;
                returnValue.Message = "Ödeme başarılı bir şekilde alınmıştır.";
            }
            else
            {
                if (creditCardData.AttendanceId != null)
                {
                    creditCardData.EducationAttendance = creditCardData.AttendanceId.Value.ToEntityReferenceWrapper<EducationAttendance>();
                }

                var creditCardLogId = _creditCardLogBaseBusiness.Insert(creditCardData);

                //TODO: Servis call yapılacak kredi kartı çekimi için
                EducationAttendance attendance = new EducationAttendance
                {
                    Id = creditCardData.AttendanceId.Value,
                    CreditCardLog = creditCardLogId.ToEntityReferenceWrapper<CreditCardLog>(),
                    Status = EducationAttendance.StatusCode.REGISTRATION_CONFIRMED.ToOptionSetValueWrapper(),
                    IsPaymentDone = true
                };

                _educationAttendanceBaseBusiness.Update(attendance);

                returnValue.Result = true;
                returnValue.Success = true;
                returnValue.Message = "Ödeme başarılı bir şekilde alınmıştır.";
            }

            return returnValue;
        }

        [AuthenticationFilter]
        public ResponseContainer<List<Education>> GetContactEducationByStatus(int status)
        {
            ResponseContainer<List<Education>> returnValue = new ResponseContainer<List<Education>>();

            if (isMockActive)
            {
                returnValue.Result = EducationMock.GetComingEducations();

                List<EducationAttendance> contactAttendanceList = null;

                if (LoggedUser.IsLoggedIn)
                {
                    contactAttendanceList = AttendanceMock.GetAttendances();

                    _educationFacade.SetEducationAttendance(returnValue.Result, contactAttendanceList);
                }

                returnValue.Success = true;
            }
            else
            {
                var attendances = _educationFacade.GetContactAttendances(LoggedUser.Current.Id)
                    .Where(a => a.Status.ToEnum<EducationAttendance.StatusCode>() == (EducationAttendance.StatusCode)status).ToList();

                if (attendances.Count > 0)
                {
                    var educationList = _educationFacade.GetEducationsOfAttendances(attendances);

                    _educationFacade.SetEducationAttendance(educationList, attendances);

                    returnValue.Result = educationList;
                }

                returnValue.Success = true;
                returnValue.Message = "Üye eğitim ve eğitim katılımları çekildi.";
            }

            return returnValue;
        }

        [AuthenticationFilter]
        public ResponseContainer<ContactAttendanceSummary> GetContactAttendanceSummary()
        {
            ResponseContainer<ContactAttendanceSummary> returnValue = new ResponseContainer<ContactAttendanceSummary>();

            if (isMockActive)
            {
                var attendances = AttendanceMock.GetAttendances();

                ContactAttendanceSummary summary = new ContactAttendanceSummary();
                summary.Contact = LoggedUser.Current.ToEntityReferenceWrapper();

                if (attendances != null && attendances.Count > 0)
                {
                    summary.ConfirmedCount = attendances.Where(a => a.Status.ToEnum<EducationAttendance.StatusCode>() == EducationAttendance.StatusCode.REGISTRATION_CONFIRMED).ToList().Count;
                    summary.JoinedCount = attendances.Where(a => a.Status.ToEnum<EducationAttendance.StatusCode>() == EducationAttendance.StatusCode.JOINED).ToList().Count;
                    summary.WaitingPaymentCount = attendances.Where(a => a.Status.ToEnum<EducationAttendance.StatusCode>() == EducationAttendance.StatusCode.WAITING_PAYMENT).ToList().Count;
                }

                returnValue.Result = summary;
                returnValue.Success = true;

                returnValue.Message = "Üye eğitim katılım özeti çekildi.";
            }
            else
            {
                var attendances = _educationFacade.GetContactAttendances(LoggedUser.Current.Id);

                ContactAttendanceSummary summary = new ContactAttendanceSummary();
                summary.Contact = LoggedUser.Current.ToEntityReferenceWrapper();

                if (attendances != null && attendances.Count > 0)
                {
                    summary.ConfirmedCount = attendances.Where(a => a.Status.ToEnum<EducationAttendance.StatusCode>() == EducationAttendance.StatusCode.REGISTRATION_CONFIRMED).ToList().Count;
                    summary.JoinedCount = attendances.Where(a => a.Status.ToEnum<EducationAttendance.StatusCode>() == EducationAttendance.StatusCode.JOINED).ToList().Count;
                    summary.WaitingPaymentCount = attendances.Where(a => a.Status.ToEnum<EducationAttendance.StatusCode>() == EducationAttendance.StatusCode.WAITING_PAYMENT).ToList().Count;
                }

                returnValue.Result = summary;
                returnValue.Success = true;

                returnValue.Message = "Üye eğitim katılım özeti çekildi.";
            }

            return returnValue;
        }
    }
}
