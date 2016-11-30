using SRC.Library.Entities.CrmEntities;
using SRC.Web.Portal.MockData;
using SRC.Web.Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using SRC.Library.Business.Interfaces;
using SRC.Library.Domain.Business.Interfaces;
using SRC.Library.Domain.Facade.Interfaces;
using SRC.Library.Entities;

namespace SRC.Web.Portal.Controllers
{
    public class HomeController : Controller
    {

        private IContactBusiness _contactBusiness;
        private IContactFacade _contactFacade;
        private IBaseBusiness<DynamicPage> _dynamicPageBaseBusiness;


        public HomeController(IContactBusiness contactBusiness, IContactFacade contactFacade, IBaseBusiness<DynamicPage> dynamicPageBaseBusiness)
        {
            _contactBusiness = contactBusiness;
            _contactFacade = contactFacade;
            _dynamicPageBaseBusiness = dynamicPageBaseBusiness;
        }

        public ActionResult Index(HomePageModel model)
        {

            //EntityReferenceWrapper r = _contactFacade.CheckLogin("ali", "veli", "120,");
            model = new HomePageModel();

            model.SliderData =
                _dynamicPageBaseBusiness.GetList().Where(
                    p => p.PageType.ToEnum<DynamicPage.PageTypeCode>() == DynamicPage.PageTypeCode.ROTATOR).ToList();

            return View(model);
        }
    }
}