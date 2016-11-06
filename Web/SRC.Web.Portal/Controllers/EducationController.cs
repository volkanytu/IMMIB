using SRC.Library.Entities.CrmEntities;
using SRC.Web.Portal.MockData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SRC.Web.Portal.Controllers
{
    public class EducationController : Controller
    {
        public EducationController()
        {

        }

        public ActionResult Index(List<Education> model)
        {
            model = new List<Education>();
            model = EducationMock.GetEducations();
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
    }
}