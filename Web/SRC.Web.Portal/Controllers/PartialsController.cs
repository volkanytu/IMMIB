using SRC.Web.Portal.MockData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SRC.Web.Portal.Controllers
{
    public class PartialsController : Controller
    {
        // GET: Partials
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

        public PartialViewResult EducationList(string month, string year)
        {
            var educations = EducationMock.GetEducations();

            return PartialView(educations);
        }

    }
}