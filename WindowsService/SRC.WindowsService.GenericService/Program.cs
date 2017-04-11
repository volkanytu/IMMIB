using System;
using System.Collections.Generic;
using System.Configuration.Install;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace SRC.WindowsService.GenericService
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var serviceTypes = Assembly.GetExecutingAssembly().GetTypes().Where(c => c.BaseType == typeof(BaseService));

            Dictionary<string, BaseService> baseServiceList = new Dictionary<string, BaseService>();

            foreach (var item in serviceTypes)
            {
                baseServiceList.Add(item.Name, Activator.CreateInstance(item) as BaseService);
            }

            if (Environment.UserInteractive)
            {
                string parameter = string.Concat(args);

                switch (parameter)
                {
                    case "--install":
                        ManagedInstallerClass.InstallHelper(new[] { Assembly.GetExecutingAssembly().Location });
                        break;
                    case "--uninstall":
                        ManagedInstallerClass.InstallHelper(new[] { "/u", Assembly.GetExecutingAssembly().Location });
                        break;
                    default:
                        var serviceInstance = baseServiceList[parameter];

                        if (serviceInstance != null)
                        {
                            serviceInstance.GetType().GetMethod("StartService").Invoke(serviceInstance, new object[] { null });
                        }
                        else
                        {
                            Console.WriteLine("Parametre olarak servis adı geçiniz.");
                        }
                        Console.ReadKey();
                        break;
                }
            }
            else
            {
                ServiceBase.Run(baseServiceList.Values.ToArray());
            }
        }
    }
}
