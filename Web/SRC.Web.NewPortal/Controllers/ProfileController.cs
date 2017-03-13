using SRC.Web.NewPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SRC.Web.NewPortal.Controllers
{
    public class ProfileController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Profil";

            return View();
        }

        public ActionResult New()
        {
            ViewBag.Title = "Yeni Profil";

            return View();
        }

        public ActionResult Edit()
        {
            ViewBag.Title = "Profil Düzenle";

            return View();
        }

        public ActionResult Education()
        {
            ViewBag.Title = "Eğitimlerim";

            return View();
        }
    }
}