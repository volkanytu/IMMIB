using Microsoft.Xrm.Sdk;
using SRC.Library.Business.Interfaces;
using SRC.Library.Entities;
using SRC.Library.Entities.CrmEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.Plugins.CrmPlugin.PluginTasks
{
    public class CreditCardLogTask : BasePluginTask
    {
        private IBaseBusiness<CreditCardLog> _baseCreditCardLogBusiness;
        private IBaseBusiness<EducationAttendance> _baseEducationAttendanceBusiness;

        public CreditCardLogTask(IBaseBusiness<CreditCardLog> baseCreditCardLogBusiness, IBaseBusiness<EducationAttendance> baseEducationAttendanceBusiness)
        {
            _baseCreditCardLogBusiness = baseCreditCardLogBusiness;
            _baseEducationAttendanceBusiness = baseEducationAttendanceBusiness;
        }

        protected override void PreCreate()
        {
            throw new NotImplementedException();
        }

        protected override void PostCreate()
        {
            var targetEntity = EntityContainer.Input;

            if (targetEntity[CreditCardLog.KEY_RESULT_CODE].ToString() == "00")
            {
                EducationAttendance attendance = _baseEducationAttendanceBusiness.Get(((EntityReference)targetEntity[CreditCardLog.KEY_EDUCATION_ATTENDANCE_ID]).Id);
                attendance.CreditCardLog = targetEntity.Id.ToEntityReferenceWrapper(targetEntity.LogicalName);
                attendance.Status = EducationAttendance.StatusCode.REGISTRATION_CONFIRMED.ToOptionSetValueWrapper();
                _baseEducationAttendanceBusiness.Update(attendance);
            }
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
