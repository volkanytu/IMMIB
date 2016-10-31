using System;
using System.Collections.Generic;
using System.Configuration.Install;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace SRC.WindowsService.TestService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            ServiceBase[] ServicesToRun;

            var service = new TestService();

            ServicesToRun = new ServiceBase[] 
            { 
                service
            };

            if (Environment.UserInteractive)
            {
                string parameter = string.Concat(args);

                switch (parameter)
                {

                    case "--install":

                        ManagedInstallerClass.InstallHelper(new string[] { Assembly.GetExecutingAssembly().Location });

                        break;

                    case "--uninstall":

                        ManagedInstallerClass.InstallHelper(new string[] { "/u", Assembly.GetExecutingAssembly().Location });

                        break;

                    case "":

                        service.DebugService(args);

                        break;
                }

            }
            else
            {
                ServiceBase.Run(ServicesToRun);
            }
        }
    }
}
