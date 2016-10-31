using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRC.ConsoleApp.ScheduledJobs.Jobs;
using SRC.Library.LogManager.Interfaces;

namespace SAHIBINDEN.ConsoleApp.ScheduledJobs.Jobs
{
    public class TestJob : BaseJob
    {
        private ILogManager _logmanager;

        public TestJob(ILogManager logmanager)
        {
            _logmanager = logmanager;
        }

        protected override void DoWork(string[] args)
        {

        }
    }
}
