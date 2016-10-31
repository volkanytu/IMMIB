using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRC.ConsoleApp.ScheduledJobs.Interfaces;

namespace SRC.ConsoleApp.ScheduledJobs.Jobs
{
    public abstract class BaseJob : IScheduledJob
    {
        public void Start(string[] args)
        {
            DoWork(args);
        }

        protected abstract void DoWork(string[] args);
    }
}
