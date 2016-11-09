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
    public class ProfileController : Controller
    {
        public ProfileController()
        {

        }

        public ActionResult Index(Guid? id)
        {
            ProfilePageModel model = new ProfilePageModel();
            model.Contact = ContactMock.GetContact();
            model.Attendances = AttendanceMock.GetAttendances();

            return View(model);
        }

        public ActionResult Edit(Guid? id)
        {
            ProfilePageModel model = new ProfilePageModel();
            model.Contact = ContactMock.GetContact();
            model.Attendances = AttendanceMock.GetAttendances();

            return View(model);
        }

        public ActionResult ChangePassword(Contact model)
        {
            model = new Contact();
            model = ContactMock.GetContact();
            return RedirectToAction("Edit");
        }

        public PartialViewResult EducationList(List<EducationAttendance> model)
        {

            var returnValue = EducationMock.GetComingEducations().Where(e => e.Status != null
                && model.Select(m => m.Education.Id).ToList().Contains(e.Id)).ToList();

            return PartialView(returnValue);
        }

        [HttpPost]
        public ActionResult Test(List<EducationAttendance> model)
        {
            var returnValue = EducationMock.GetComingEducations().Where(e => e.Status != null
                && model.Select(m => m.Education.Id).ToList().Contains(e.Id)).ToList();

            return View(returnValue);
        }
    }
}