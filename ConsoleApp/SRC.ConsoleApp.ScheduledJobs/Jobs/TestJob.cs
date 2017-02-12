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

namespace SAHIBINDEN.ConsoleApp.ScheduledJobs.Jobs
{
    public class TestJob : BaseJob
    {
        private ILogManager _logmanager;
        private IEducationAttendanceBusiness _educationBusiness;
        private IBaseBusiness<EducationAttendance> _baseBusiness;

        public TestJob(ILogManager logmanager, IBaseBusiness<EducationAttendance> baseBusiness, IEducationAttendanceBusiness educationBusiness)
        {
            _logmanager = logmanager;
            _baseBusiness = baseBusiness;
            _educationBusiness = educationBusiness;
            
        }

        protected override void DoWork(string[] args)
        {
            List<EducationAttendance> educationAttendances = _educationBusiness.GetEducationAttendancesForExpectedPayments();

            foreach (var item in educationAttendances)
            {
                _baseBusiness.SetState(item.Id, (int)EducationAttendance.StateCode.PASSIVE, (int)EducationAttendance.StatusCode.DID_NOT_JOINED);
            }
        }
    }
}
