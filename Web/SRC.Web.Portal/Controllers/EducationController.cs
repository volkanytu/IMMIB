using SRC.Library.Entities.CrmEntities;
using SRC.Web.Portal.MockData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SRC.Library.Business.Interfaces;
using SRC.Library.Domain.Facade.Interfaces;
using SRC.Library.Entities;
using SRC.Library.Entities.CustomEntities;
using SRC.Web.Portal.Models;

namespace SRC.Web.Portal.Controllers
{
    public class EducationController : Controller
    {
        private IEducationFacade _educationFacade;
        private IBaseBusiness<EducationAttendance> _educationAttendanceBaseBusiness;
        private IBaseBusiness<DynamicPage> _dynamicPageBaseBusiness;

        public EducationController(IEducationFacade educationFacade, IBaseBusiness<EducationAttendance> educationAttendanceBaseBusiness, IBaseBusiness<DynamicPage> dynamicPageBaseBusiness)
        {
            _educationFacade = educationFacade;
            _educationAttendanceBaseBusiness = educationAttendanceBaseBusiness;
            _dynamicPageBaseBusiness = dynamicPageBaseBusiness;
        }

        public ActionResult Index(string month, string year)
        {
            //TODO:Yeni eklendi. Değiştirilebilir.
            int monthNow = string.IsNullOrWhiteSpace(month) ? DateTime.Now.Month : Convert.ToInt32(month);
            int yearNow = string.IsNullOrWhiteSpace(year) ? DateTime.Now.Year : Convert.ToInt32(year);

            List<SelectListItem> months = GetMonths();
            months.FirstOrDefault(i => i.Value == monthNow.ToString()).Selected = true;
            ViewBag.month = months;

            List<SelectListItem> years = GetYears();
            years.FirstOrDefault(i => i.Value == yearNow.ToString()).Selected = true;
            ViewBag.year = years;


            List<Education> educations = _educationFacade.GetEducations(monthNow, yearNow);
            EducationQueryModel model = new EducationQueryModel {EducationList = educations};
            return View(model);
        }

        public PartialViewResult Detail(string id)
        {
            Education model = new Education();

            if (!string.IsNullOrWhiteSpace(id))
            {
                model = EducationMock.GetEducations().Where(e => e.Id == Guid.Parse(id)).FirstOrDefault();
            }

            return PartialView(model);
        }

        public PartialViewResult EducationAttendance(string id)
        {
            DynamicPage model = _dynamicPageBaseBusiness.GetList().FirstOrDefault(p => p.PageType == DynamicPage.PageTypeCode.EDUCATION_APPLICATION_CONDITION.ToOptionSetValueWrapper());
            ViewBag.Id = id;
            return PartialView(model);
        }

        public ResponseContainer<string> CreateEducationAttendance(string educationId)
        {
            educationId.CheckNull("Lütfen eğitim seçiniz!");

            ResponseContainer<string> retunValue = new ResponseContainer<string>();

            EducationAttendance model = new EducationAttendance();
            model.Contact = LoggedUser.Current.ToEntityReferenceWrapper();
            model.Education = Guid.Parse(educationId).ToEntityReferenceWrapper<Education>();
            model.Code = "123456";
            var attendanceId = _educationAttendanceBaseBusiness.Insert(model);
            model = _educationAttendanceBaseBusiness.Get(attendanceId);
            retunValue.Id = model.Id;
            retunValue.Result = model.Code;

            return retunValue;
        }

        //TODO:Bunlar başka yere alınır
        private List<SelectListItem> GetMonths()
        {
            List<SelectListItem> returnList = new List<SelectListItem>();
            returnList.Add(new SelectListItem() { Text = "1", Value = "1" });
            returnList.Add(new SelectListItem() { Text = "2", Value = "2" });
            returnList.Add(new SelectListItem() { Text = "3", Value = "3" });
            returnList.Add(new SelectListItem() { Text = "4", Value = "4" });
            returnList.Add(new SelectListItem() { Text = "5", Value = "5" });
            returnList.Add(new SelectListItem() { Text = "6", Value = "6" });
            returnList.Add(new SelectListItem() { Text = "7", Value = "7" });
            returnList.Add(new SelectListItem() { Text = "8", Value = "8" });
            returnList.Add(new SelectListItem() { Text = "9", Value = "9" });
            returnList.Add(new SelectListItem() { Text = "10", Value = "10" });
            returnList.Add(new SelectListItem() { Text = "11", Value = "11" });
            returnList.Add(new SelectListItem() { Text = "12", Value = "12" });
            return returnList;
        }

        private List<SelectListItem> GetYears()
        {
            List<SelectListItem> returnList = new List<SelectListItem>();
            returnList.Add(new SelectListItem() { Text = "2016", Value = "2016" });
            returnList.Add(new SelectListItem() { Text = "2017", Value = "2017" });
            returnList.Add(new SelectListItem() { Text = "2018", Value = "2018" });
            returnList.Add(new SelectListItem() { Text = "2019", Value = "2019" });
            returnList.Add(new SelectListItem() { Text = "2020", Value = "2020" });
            return returnList;
        }
    }
}