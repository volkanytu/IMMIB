using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using SRC.ConsoleApp.ScheduledJobs.Jobs;

namespace SRC.ConsoleApp.ScheduledJobs
{
    public class Program    
    {
        static void Main(string[] args)
        {

            //if (args == null || args.Length == 0)
            //    return;

            //var firstArg = args.FirstOrDefault();
            var firstArg = "TestJob";
            var container = IocContainerConfig.BuildIocContainer();

            var job = container.ResolveKeyed<BaseJob>(firstArg);

            var argsExcept = Enumerable.Take(args.Skip(1), args.Length).ToArray();

            job.Start(argsExcept);
        }
    }
}
