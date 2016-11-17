using SRC.Library.Entities.CrmEntities;
using SRC.Web.Portal.MockData;
using SRC.Web.Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SRC.Library.Entities;

namespace SRC.Web.Portal.Controllers
{
    public class ProfileController : Controller
    {
        public ProfileController()
        {

        }

        public ActionResult Index()
        {
            ProfilePageModel model = new ProfilePageModel();
            model.Contact = LoggedUser.Current;
            model.Attendances = AttendanceMock.GetAttendances();

            return View(model);
        }

        public ActionResult Edit()
        {
            ProfilePageModel model = new ProfilePageModel();
            model.Contact = LoggedUser.Current;
            model.Attendances = AttendanceMock.GetAttendances();

            return View(model);
        }

        public ActionResult Education(int? type)
        {
            ProfilePageModel model = new ProfilePageModel();
            model.Contact = LoggedUser.Current;
            model.Attendances = AttendanceMock.GetAttendances()
                .Where(a => a.Status.ToEnum<EducationAttendance.StatusCode>() == (EducationAttendance.StatusCode)type).ToList();

            model.EducationList = EducationMock.GetEducations().Where(e => e.Status != null
                                        && model.Attendances.Select(m => m.Education.Id).ToList().Contains(e.Id)).ToList();

            return View(model);
        }

        public ActionResult ChangePassword(Contact model)
        {
            model = new Contact();
            model = LoggedUser.Current;
            return RedirectToAction("Edit");
        }

        public ActionResult SignUp(Contact model)
        {
            //model = LoggedUser.Current;
            return View(model);
        }

        public PartialViewResult EducationList(List<EducationAttendance> model)
        {

            var returnValue = EducationMock.GetDoneEducations().Where(e => e.Status != null
                && model.Select(m => m.Education.Id).ToList().Contains(e.Id)).ToList();

            return PartialView(returnValue);
        }
    }
}