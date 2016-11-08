using SRC.Library.Entities.CrmEntities;
using SRC.Web.Portal.MockData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SRC.Web.Portal.Controllers
{
    public class ProfileController : Controller
    {
        public ProfileController()
        {

        }

        public ActionResult Index(Contact model)
        {
            model = new Contact();
            model = ContactMock.GetContact();
            return View(model);
        }

        public ActionResult Edit(Contact model)
        {
            model = new Contact();
            model = ContactMock.GetContact();
            return View(model);
        }

        public ActionResult ChangePassword(Contact model)
        {
            model = new Contact();
            model = ContactMock.GetContact();
            return RedirectToAction("Edit");
        }
    }
}