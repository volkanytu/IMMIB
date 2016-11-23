using SRC.Library.Entities.CrmEntities;
using SRC.Web.Portal.MockData;
using SRC.Web.Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SRC.Library.Business.Interfaces;
using SRC.Library.Domain.Facade.Interfaces;
using SRC.Library.Entities;
using SRC.Library.Entities.CustomEntities;

namespace SRC.Web.Portal.Controllers
{
    public class PartialsController : Controller
    {
        private IEducationFacade _educationFacade;
        private IBaseBusiness<GsmOperator> _gsmOperatorBusiness;
        private IBaseBusiness<InformedBy> _informedByBusiness;
        private IBaseBusiness<City> _cityBusiness;
        private IBaseBusiness<DynamicPage> _dynamicPageBaseBusiness;

        public PartialsController(IEducationFacade educationFacade
            , IBaseBusiness<GsmOperator> gsmOperatorBusiness
            , IBaseBusiness<InformedBy> informedByBusiness
            , IBaseBusiness<City> cityBusiness
            , IBaseBusiness<DynamicPage> dynamicPageBaseBusiness)
        {
            _educationFacade = educationFacade;
            _gsmOperatorBusiness = gsmOperatorBusiness;
            _informedByBusiness = informedByBusiness;
            _cityBusiness = cityBusiness;
            _dynamicPageBaseBusiness = dynamicPageBaseBusiness;
        }

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult ComingEducations()
        {
            var educations = EducationMock.GetComingEducations();

            return PartialView(educations);
        }

        public PartialViewResult DoneEducations()
        {
            var educations = EducationMock.GetDoneEducations();

            return PartialView(educations);
        }

        public PartialViewResult EducationList(EducationQueryModel querymodel)
        {
            EducationModel model = new EducationModel();

            //TODO: Burası ne işe yarıyor?
            if (LoggedUser.IsLoggedIn)
            {
                model.AttendanceList = _educationFacade.GetContactAttendances(LoggedUser.Current.Id).Where(a => a.Status.ToEnum<EducationAttendance.StatusCode>() != EducationAttendance.StatusCode.PARTICIPANT_CANCELED).ToList();
            }

            if (querymodel.EducationList != null)
            {
                model.EducationList = querymodel.EducationList;
            }

            _educationFacade.SetEducationAttendance(model.EducationList, model.AttendanceList);

            return PartialView(model);
        }

        public PartialViewResult HeaderMenu()
        {
            List<HeaderMenuItem> model = new List<HeaderMenuItem>();
            model.Add(new HeaderMenuItem() { Name = "Ana Sayfa", Link = "/", ControllerName = "Home" });
            model.Add(new HeaderMenuItem() { Name = "Eğitim Takvimi", Link = "/Education", ControllerName = "Education" });
            model.Add(new HeaderMenuItem() { Name = "Nasıl Başvurabilirim?", Link = "/Howto", ControllerName = "Howto" });
            model.Add(new HeaderMenuItem() { Name = "İletişim", Link = "/Contact", ControllerName = "Contact" });

            return PartialView(model);
        }

        public PartialViewResult ProfileMenu()
        {
            ProfilePageModel model = new ProfilePageModel();
            model.Contact = LoggedUser.Current;
            model.Attendances = _educationFacade.GetContactAttendances(LoggedUser.Current.Id);

            return PartialView(model);
        }

        public PartialViewResult ProfileInformation(Contact _model)
        {
            ViewBag.gsmOperatorId = _gsmOperatorBusiness.GetList().ToSelectList(_model.GsmOperator);
            ViewBag.informedById = _informedByBusiness.GetList().ToSelectList(_model.InformedBy);
            ViewBag.cityId = _cityBusiness.GetList().ToSelectList(_model.City);

            List<SelectListItem> educationLevels = GetEducationLevels();
            if (_model.EducationLevel != null)
            {
                educationLevels.FirstOrDefault(i => i.Value == _model.EducationLevel.AttributeValue.ToString()).Selected = true;
            }

            ViewBag.educationLevel = educationLevels;

            //_model = LoggedUser.Current;

            return PartialView(_model);
        }

        //TODO: bu da kaldırılabilir.
        private List<SelectListItem> GetEducationLevels()
        {
            List<SelectListItem> returnList = new List<SelectListItem>();
            returnList.Add(new SelectListItem() { Text = "İlköğretim", Value = "1" });
            returnList.Add(new SelectListItem() { Text = "Lise", Value = "2" });
            returnList.Add(new SelectListItem() { Text = "Lisans", Value = "3" });
            return returnList;
        }

        public PartialViewResult EducationAttendance(string id)
        {
            ResponseContainer<DynamicPage> model = new ResponseContainer<DynamicPage>();

            if (!LoggedUser.IsLoggedIn)
            {
                model.Message = "Başvuru için giriş yapmalısınız.";
            }
            else
            {
                model.Succes = true;
                model.Result = _dynamicPageBaseBusiness.GetList().FirstOrDefault(p => p.PageType.ToEnum<DynamicPage.PageTypeCode>() == DynamicPage.PageTypeCode.EDUCATION_APPLICATION_CONDITION);
                ViewBag.Id = id;
            }

            return PartialView(model);
        }

    }
}