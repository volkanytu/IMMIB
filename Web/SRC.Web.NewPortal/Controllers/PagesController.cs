using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SRC.Web.NewPortal.Controllers
{
    public class PagesController : Controller
    {
        public ActionResult HowTo()
        {
            ViewBag.Title = "Nasıl Başvurabilirim?";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Title = "İletişim";

            return View();
        }
	}
}