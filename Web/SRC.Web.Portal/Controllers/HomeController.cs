using SRC.Library.Entities.CrmEntities;
using SRC.Web.Portal.MockData;
using SRC.Web.Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SRC.Web.Portal.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            //TEST için
            LoggedUser.Current = ContactMock.GetContact();
        }

        public ActionResult Index(HomePageModel model)
        {
            model = new HomePageModel();
            model.SliderData = DynamicPageMock.GetDynamicPages();
            model.ComingEducations = EducationMock.GetComingEducations();
            model.DoneEducations = EducationMock.GetDoneEducations();

            return View(model);
        }
    }
}