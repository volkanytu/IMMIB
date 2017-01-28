using SRC.Library.Entities.CrmEntities;
using SRC.Web.Portal.MockData;
using SRC.Web.Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SRC.Library.Business.Interfaces;
using SRC.Library.Common;
using SRC.Library.Domain.Business.Interfaces;
using SRC.Library.Domain.Facade;
using SRC.Library.Domain.Facade.Interfaces;
using SRC.Library.Entities;
using SRC.Web.Portal.Filters;

namespace SRC.Web.Portal.Controllers
{
    [ErrorAttribute]
    public class ProfileController : Controller
    {
        private IContactFacade _contactFacade;
        private IEducationFacade _educationFacade;

        public ProfileController(IContactFacade contactFacade, IEducationFacade educationFacade)
        {
            _contactFacade = contactFacade;
            _educationFacade = educationFacade;
        }

        public ActionResult Index()
        {
            ProfilePageModel model = new ProfilePageModel();
            model.Contact = LoggedUser.Current;
            //model.Attendances = _educationFacade.GetContactAttendances(LoggedUser.Current.Id);//AttendanceMock.GetAttendances();

            return View(model);
        }

        public ActionResult Edit()
        {
            ProfilePageModel model = new ProfilePageModel();
            model.Contact = LoggedUser.Current;
            //model.Attendances = _educationFacade.GetContactAttendances(model.Contact.Id);
            //model.Attendances = AttendanceMock.GetAttendances();

            return View(model);
        }

        public ActionResult Education(int? type)
        {
            ProfilePageModel model = new ProfilePageModel();
            model.Contact = LoggedUser.Current;
            model.Attendances = _educationFacade.GetContactAttendances(LoggedUser.Current.Id).Where(a => a.Status.ToEnum<EducationAttendance.StatusCode>() == (EducationAttendance.StatusCode)type).ToList();

            if (model.Attendances.Count > 0)
            {
                model.EducationList = _educationFacade.GetEducationsOfAttendances(model.Attendances).Where(e => e.Status != null
                            && model.Attendances.Select(m => m.Education.Id).ToList().Contains(e.Id)).ToList();
            }

            return View(model);
        }

        //TODO: Burada şimdilik 2 ayrı metod yaptım
        public ActionResult SignUp(Contact model)
        {

            //model = LoggedUser.Current;

            return View(model);
        }

        public ActionResult Exit()
        {

            LoggedUser.Current = null;

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Kaydet(Contact model, string gsmOperatorId, string informedById, string cityId, string educationLevel, string genderCode)
        {

            model.GsmOperator = gsmOperatorId.ToEntityReferenceWrapper("new_gsmoperator");
            model.InformedBy = informedById.ToEntityReferenceWrapper("new_informedby");
            model.City = cityId.ToEntityReferenceWrapper("new_city");
            model.EducationLevel = new OptionSetValueWrapper() { AttributeValue = Convert.ToInt32(educationLevel) };
            model.Gender = new OptionSetValueWrapper() { AttributeValue = Convert.ToInt32(genderCode) };

            if (LoggedUser.Current == null)
            {
                Guid? contactId = _contactFacade.CreateContact(model);
                LoggedUser.Current = _contactFacade.GetContact(contactId);
            }
            else
            {
                model.Id = LoggedUser.Current.Id;
                _contactFacade.UpdateContact(model);
                LoggedUser.Current = _contactFacade.GetContact(model.Id);
            }

            //model = LoggedUser.Current;

            return RedirectToAction("Index");
        }

        public ActionResult CheckLogin(string userName, string password)
        {
            Contact loggedUser = _contactFacade.CheckLogin(userName, password, "192.168.2.1");

            LoggedUser.Current = loggedUser;

            return RedirectToAction("Index");
        }

        public ActionResult ChangePassword(string oldPassword, string newPassword, string reNewPassword)
        {
            if (!string.IsNullOrWhiteSpace(oldPassword) && !string.IsNullOrWhiteSpace(newPassword) && !string.IsNullOrWhiteSpace(reNewPassword))
            {
                if (newPassword != reNewPassword)
                {
                    //hata
                }

                string hashedOldPassword = oldPassword.ToSHA1();
                if (LoggedUser.Current.Password != hashedOldPassword)
                {
                    //Hata
                }

                _contactFacade.UpdatePassWord(LoggedUser.Current.Id, newPassword.ToSHA1());

                // LoggedUser.Current = loggedUser;
            }

            return RedirectToAction("Index");
        }

        public PartialViewResult EducationList(List<EducationAttendance> model)
        {

            var returnValue = EducationMock.GetDoneEducations().Where(e => e.Status != null
                && model.Select(m => m.Education.Id).ToList().Contains(e.Id)).ToList();

            return PartialView(returnValue);
        }


    }
}