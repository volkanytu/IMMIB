using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SRC.Web.NewPortal.Controllers
{
    public class EducationController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Eğitimler";

            return View();
        }
	}
}