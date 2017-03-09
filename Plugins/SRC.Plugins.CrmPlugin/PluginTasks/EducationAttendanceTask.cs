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
        private readonly IEducationAttendanceBusiness _educationAttendanceBusiness;
        private readonly IBaseBusiness<Contact> _baseContactBusiness;
        private readonly IBaseBusiness<Education> _baseEducationBusiness;

        public EducationAttendanceTask(IEducationAttendanceBusiness educationAttendanceBusiness, IBaseBusiness<Contact> baseContactBusiness, IBaseBusiness<Education> baseEducationBusiness)
        {
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
                int attendanceCount = _educationAttendanceBusiness.GetEducationAttendancesCountByMonth(contact.Id, education.StartDate.Value);
                if (attendanceCount == 2)
                    throw new Exception("Aynı ay içerisinde en fazla 2 eğitime katılabilirsiniz!");
            }

            targetEntity[EducationAttendance.KEY_EDUCATION_START_DATE] = education.StartDate.Value;
            targetEntity[EducationAttendance.KEY_CODE] = _educationAttendanceBusiness.GetEducationAttendanceCode(education.Id,education.Code);
        }

        protected override void PostCreate()
        {
            throw new NotImplementedException();
        }

        protected override void PreUpdate()
        {
            throw new NotImplementedException();
        }

        protected override void PostUpdate()
        {
            throw new NotImplementedException();
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
