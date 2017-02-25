using Microsoft.Xrm.Sdk;
using SRC.Library.Domain.Business.Interfaces;
using System;
using System.Collections.Generic;
using SRC.Library.Entities.CrmEntities;
using SRC.Library.Business.Interfaces;

namespace SRC.Plugins.CrmPlugin.PluginTasks
{
    public class EducationTask : BasePluginTask
    {
        private IEducationBusiness _educationBusiness;
        private IEducationAttendanceBusiness _educationAttendanceBusiness;
        private IBaseBusiness<EducationAttendance> _baseEducationAttendanceBusiness;

        public EducationTask(IEducationBusiness educationBusiness, IEducationAttendanceBusiness educationAttendanceBusiness, IBaseBusiness<EducationAttendance> baseEducationAttendanceBusiness)
        {
            _educationBusiness = educationBusiness;
            _educationAttendanceBusiness = educationAttendanceBusiness;
            _baseEducationAttendanceBusiness = baseEducationAttendanceBusiness;
        }

        protected override void PreCreate()
        {
            throw new NotImplementedException();
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
            var targetEntity = (EntityReference)EntityContainer.SetStateInput.EntityMoniker;
            OptionSetValue statusCode = (OptionSetValue)EntityContainer.SetStateInput.Status;

            if (statusCode.Value == (int)Library.Entities.CrmEntities.Education.StatusCode.CANCELED)
            {
                _educationAttendanceBusiness.CancelAllEducationAttendaces(targetEntity.Id);
            }
        }
    }
}
