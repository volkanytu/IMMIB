using SRC.Library.Entities.CrmEntities;
using SRC.Web.Portal.MockData;
using SRC.Web.Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using SRC.Library.Domain.Business.Interfaces;
using SRC.Library.Domain.Facade.Interfaces;
using SRC.Library.Entities;

namespace SRC.Web.Portal.Controllers
{
    public class HomeController : Controller
    {

        private IContactBusiness _contactBusiness;
        private IContactFacade _contactFacade;


        public HomeController(IContactBusiness contactBusiness, IContactFacade contactFacade)
        {
            _contactBusiness = contactBusiness;
            _contactFacade = contactFacade;

            //TEST için
            //LoggedUser.Current = ContactMock.GetContact();
        }

        public ActionResult Index(HomePageModel model)
        {

            EntityReferenceWrapper r = _contactFacade.CheckLogin("ali", "veli", "120,");
            model = new HomePageModel();
            model.SliderData = DynamicPageMock.GetDynamicPages();
            model.ComingEducations = EducationMock.GetComingEducations();
            model.DoneEducations = EducationMock.GetDoneEducations();

            return View(model);
        }
    }
}