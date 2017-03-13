using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using SRC.Library.Business.Interfaces;
using SRC.Library.Domain.Business.Interfaces;
using SRC.Library.Entities.CrmEntities;

namespace SRC.Plugins.CrmPlugin.PluginTasks
{
    public class EducationAttendanceTask : BasePluginTask
    {
        private readonly IBaseBusiness<EducationAttendance> _baseEducationAttendanceBusiness;
        private readonly IEducationAttendanceBusiness _educationAttendanceBusiness;
        private readonly IBaseBusiness<Contact> _baseContactBusiness;
        private readonly IBaseBusiness<Education> _baseEducationBusiness;

        public EducationAttendanceTask(IBaseBusiness<EducationAttendance> baseEducationAttendanceBusiness, IEducationAttendanceBusiness educationAttendanceBusiness, IBaseBusiness<Contact> baseContactBusiness, IBaseBusiness<Education> baseEducationBusiness)
        {
            _baseEducationAttendanceBusiness = baseEducationAttendanceBusiness;
            _educationAttendanceBusiness = educationAttendanceBusiness;
            _baseContactBusiness = baseContactBusiness;
            _baseEducationBusiness = baseEducationBusiness;
        }

        protected override void PreCreate()
        {
            var targetEntity = EntityContainer.Input;

            Education education = _baseEducationBusiness.Get(((EntityReference)targetEntity.Attributes[EducationAttendance.KEY_EDUCATION_ID]).Id);
            Contact contact = _baseContactBusiness.Get(((EntityReference)targetEntity.Attributes[EducationAttendance.KEY_CONTACT_ID]).Id);



            if (contact.CustomerType.AttributeValue == (int)Contact.CustomerTypeCode.STUDENT)
            {
                if(!(bool)education.IsStudentCanAttend)
                    throw new Exception("Bu eğitime öğrenciler katılamaz!");

                if(!education.IsStudentAcceptable)
                    throw new Exception("Öğrenci kontenjanı dolmuştur!");

                int attendanceCount = _educationAttendanceBusiness.GetEducationAttendancesCountByMonth(contact.Id, education.StartDate.Value);
                if (attendanceCount == 2)
                    throw new Exception("Aynı ay içerisinde en fazla 2 eğitime katılabilirsiniz!");
            }
            else
            {
                if (!education.IsParticipantAcceptable)
                    throw new Exception("Kontenjan dolmuştur!");
            }

            targetEntity[EducationAttendance.KEY_EDUCATION_START_DATE] = education.StartDate.Value;
            targetEntity[EducationAttendance.KEY_CODE] = _educationAttendanceBusiness.GetEducationAttendanceCode(education.Id,education.Code);
        }

        protected override void PostCreate()
        {
            var targetEntity = EntityContainer.Input;

            Education education = _baseEducationBusiness.Get(((EntityReference)targetEntity.Attributes[EducationAttendance.KEY_EDUCATION_ID]).Id);
            Contact contact = _baseContactBusiness.Get(((EntityReference)targetEntity.Attributes[EducationAttendance.KEY_CONTACT_ID]).Id);

            if (contact.CustomerType.AttributeValue == (int) Contact.CustomerTypeCode.STUDENT)
                education.StudentLeftQuota--;
            else
                education.LeftQuota--;

            _baseEducationBusiness.Update(education);
        }

        protected override void PreUpdate()
        {
            throw new NotImplementedException();
        }

        protected override void PostUpdate()
        {
            var targetEntity = EntityContainer.Input;
            var preImage = EntityContainer.PreImage;

            if (targetEntity.Contains("statuscode") && ((OptionSetValue)targetEntity["statuscode"]).Value == (int)EducationAttendance.StatusCode.REGISTRATION_NOT_CONFIRMED)
            {
                Education education = _baseEducationBusiness.Get(((EntityReference)preImage.Attributes[EducationAttendance.KEY_EDUCATION_ID]).Id);
                Contact contact = _baseContactBusiness.Get(((EntityReference)preImage.Attributes[EducationAttendance.KEY_CONTACT_ID]).Id);

                if (contact.CustomerType.AttributeValue == (int)Contact.CustomerTypeCode.STUDENT)
                    education.StudentLeftQuota++;
                else
                    education.LeftQuota++;

                _baseEducationBusiness.Update(education);
            }
            
        }

        protected override void PreDelete()
        {
            throw new NotImplementedException();
        }

        protected override void PostDelete()
        {
            throw new NotImplementedException();
        }

        protected override void SetState()
        {
            throw new NotImplementedException();
        }
    }
}
