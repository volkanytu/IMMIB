﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.ConsoleApp.ScheduledJobs.Interfaces
{
    public interface IScheduledJob
    {
        void Start(string[] args);
    }
}
