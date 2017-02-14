using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRC.ConsoleApp.ScheduledJobs.Jobs;
using SRC.Library.LogManager.Interfaces;
using SRC.Library.Business.Interfaces;
using SRC.Library.Entities.CrmEntities;
using Autofac;
using SRC.Library.Domain.Business.Interfaces;
using SRC.ConsoleApp.ScheduledJobs.Model;
using Common=SRC.Library.Common.Extensions;

namespace SAHIBINDEN.ConsoleApp.ScheduledJobs.Jobs
{
    /// <summary>
    /// PassiveUnPaidAttendance RemainDay=3
    /// </summary>
    public class PassiveUnPaidAttendance : BaseJob
    {
        private ILogManager _logmanager;
        private IEducationAttendanceBusiness _educationBusiness;
        private IBaseBusiness<EducationAttendance> _baseBusiness;

        private PassiveUnPaidAttendanceModel _model;

        public PassiveUnPaidAttendance(ILogManager logmanager, IBaseBusiness<EducationAttendance> baseBusiness, IEducationAttendanceBusiness educationBusiness)
        {
            _logmanager = logmanager;
            _baseBusiness = baseBusiness;
            _educationBusiness = educationBusiness;
            
        }

        protected override void DoWork(string[] args)
        {
            _model = Common.ArgsToClass<PassiveUnPaidAttendanceModel>(args);

            if (_model == null)
            {
                return;
            }

            List<EducationAttendance> educationAttendances = _educationBusiness.GetEducationAttendancesForExpectedPayments(_model.RemainDayValue);

            foreach (var item in educationAttendances)
            {
                _baseBusiness.SetState(item.Id, (int)EducationAttendance.StateCode.PASSIVE, (int)EducationAttendance.StatusCode.DID_NOT_JOINED);
            }
        }
    }
}
