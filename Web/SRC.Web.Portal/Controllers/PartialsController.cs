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
    public class PartialsController : Controller
    {
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

        public PartialViewResult EducationList(EducationQueryModel querymodel)
        {
            EducationModel model = new EducationModel();

            if (LoggedUser.IsLoggedIn)
            {
                model.AttendanceList = AttendanceMock.GetAttendances().Where(a => a.Contact.Id == LoggedUser.Current.Id).ToList();
            }

            if (querymodel.EducationList != null)
            {
                model.EducationList = querymodel.EducationList;
            }
            else
            {
                model.EducationList = EducationMock.GetEducations();
            }

            return PartialView(model);
        }

        public PartialViewResult HeaderMenu()
        {
            List<HeaderMenuItem> model = new List<HeaderMenuItem>();
            model.Add(new HeaderMenuItem() { Name = "Ana Sayfa", Link = "/", ControllerName = "Home" });
            model.Add(new HeaderMenuItem() { Name = "Eğitim Takvimi", Link = "/Education", ControllerName = "Education" });
            model.Add(new HeaderMenuItem() { Name = "Nasıl Başvurabilirim?", Link = "/Howto", ControllerName = "Howto" });
            model.Add(new HeaderMenuItem() { Name = "İletişim", Link = "/Contact", ControllerName = "Contact" });

            return PartialView(model);
        }

        public PartialViewResult ProfileMenu()
        {
            ProfilePageModel model = new ProfilePageModel();
            model.Contact = LoggedUser.Current;
            model.Attendances = AttendanceMock.GetAttendances();

            return PartialView(model);
        }

    }
}